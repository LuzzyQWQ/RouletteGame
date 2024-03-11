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
				_slotList.Add(SlotConfigLoader.Instance.SpawnSlot(slotName));
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
				_slotList[i].RegisterSlotItem(SlotItemConfigLoader.Instance.SpawnSlotItem(data.InitSlotItemNames[i]));
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
		/// 获得转盘的数据
		/// </summary>
		/// <returns></returns>
		public RouletteData GetRouletteData()
		{
			return RouletteConfigLoader.Instance.GetRouletteData(_rouletteName);
		}

		#endregion


	}
}
