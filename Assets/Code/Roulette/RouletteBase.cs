using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game
{
	/// <summary>
	/// 轮盘抽象类
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

		#region 能力

		#endregion
	}
}
