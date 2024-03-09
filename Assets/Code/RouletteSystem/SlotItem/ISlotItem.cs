using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.RouletteSystem
{
	/// <summary>
	/// 插槽物品类型
	/// </summary>
	public enum SlotItemTriggerType
	{
		Enter,	// 进入触发
		Stay,	// 停留触发
	}

	/// <summary>
	/// 插槽物品接口
	/// </summary>
	public interface ISlotItem
	{
		public bool IsAvailable();
		public void Activate(bool active);
		public SlotItemTriggerType GetTriggerType();

		/// <summary>
		/// 设置至插槽
		/// </summary>
		public void SettleSlot(ISlot slot);
		public void Destory();
		/// <summary>
		/// 触发能力
		/// </summary>
		public void Trigger();
	}
}
