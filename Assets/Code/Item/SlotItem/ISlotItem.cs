using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game
{
	/// <summary>
	/// 插槽物品接口
	/// </summary>
	public interface ISlotItem
	{
		#region 判断

		public bool IsAvailable();
		#endregion

		#region 能力
		/// <summary>
		/// 触发能力
		/// </summary>
		public void Trigger();
		#endregion
	}
}
