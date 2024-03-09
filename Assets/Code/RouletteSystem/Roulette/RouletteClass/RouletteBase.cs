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
		/// 轮盘插槽
		/// </summary>
		protected List<ISlot> _slotList;
		
		/// <summary>
		/// 插槽数量
		/// </summary>
		public int SlotCount { get { return _slotList.Count; } }

		#endregion
		public RouletteBase() 
		{ 
		
		}


		#region 能力
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
		
		#endregion



	}
}
