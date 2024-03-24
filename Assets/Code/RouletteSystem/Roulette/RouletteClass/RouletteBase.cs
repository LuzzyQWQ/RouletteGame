using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.RouletteSystem
{

	/// <summary>
	/// 轮盘抽象类， 数据层
	/// </summary>
	public abstract class RouletteBase
	{
		#region 属性

		/// <summary>
		/// 轮盘名字
		/// </summary>
		protected string _rouletteName;
		/// <summary>
		/// 轮盘插槽
		/// </summary>
		protected List<ISlot> _slotList;
		
		/// <summary>
		/// 插槽数量
		/// </summary>
		public int SlotCount { get { return _slotList.Count; } }

		#endregion
		
		#region 初始化

		public RouletteBase(string rouletteName) 
		{ 
			_rouletteName = rouletteName;
			InitSlots();
		}

		/// <summary>
		/// 初始化各个插槽
		/// </summary>
		private void InitSlots()
		{
			RouletteData data = GetRouletteData();
			_slotList = new List<ISlot>();
			foreach (var slotName in data.InitSlotNames)
			{
				_slotList.Add(RouletteSystemConfigLoader.Instance.SpawnSlot(slotName));
			}
			for (int i = 0; i < data.InitSlotItemNames.Count; i++)
			{
				if (i >= SlotCount)
				{
					Debug.LogError("转盘初始SlotItem个数超过插槽个数： "+_rouletteName);
					continue;
				}
				if (data.InitSlotItemNames[i] == "")
				{
					continue;
				}
				_slotList[i].RegisterSlotItem(RouletteSystemConfigLoader.Instance.SpawnSlotItem(data.InitSlotItemNames[i]));
			}
		}
		#endregion


		#region 访问
		/// <summary>
		/// 访问转盘的插槽
		/// </summary>
		/// <param name="index">下标</param>
		/// <returns></returns>
		public ISlot GetSlot(int index)
		{
			if (index < 0 || index >= _slotList.Count)
			{
				Debug.LogError("插槽下标错误：" +index.ToString());
				return null;
			}
			return _slotList[index];
		}
		
		/// <summary>
		/// 获得下一个插槽的下标
		/// </summary>
		/// <param name="currentindex"></param>
		/// <param name="isForward"></param>
		/// <param name="roundCountChange">圈数改变数量</param>
		/// <returns></returns>
		public int GetNextIndex(int currentindex, bool isForward,out int roundCountChange)
		{
			roundCountChange = 0;
			int nextIndex = isForward ? (currentindex + 1) % SlotCount : (currentindex - 1 + SlotCount) % SlotCount;
			if(isForward && nextIndex == 0)
			{
				roundCountChange = 1;
			}
			if(!isForward && nextIndex == SlotCount - 1)
			{
				roundCountChange = -1;
			}
			return nextIndex;
		}
		/// <summary>
		/// 获得转盘的数据
		/// </summary>
		/// <returns></returns>
		public RouletteData GetRouletteData()
		{
			return RouletteSystemConfigLoader.Instance.RouletteLoader.GetInfo(_rouletteName).RouletteData;
		}
		
		/// <summary>
		/// 计算旋转步数
		/// </summary>
		/// <param name="beforeIndex"></param>
		/// <param name="afterIndex"></param>
		/// <param name="beforeRound"></param>
		/// <param name="afterRound"></param>
		/// <returns></returns>
		public int CalculateStep(int beforeIndex, int afterIndex,int beforeRound,int afterRound)
		{
			int step = (afterRound - beforeRound) * SlotCount +afterIndex -beforeIndex;
			Debug.LogWarning(string.Format("移动步数为 {0}",step.ToString()));
			return step;
		}

		#endregion


	}
}
