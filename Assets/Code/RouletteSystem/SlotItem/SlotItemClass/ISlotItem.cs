using Argali.Game.CharacterSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.RouletteSystem
{


	/// <summary>
	/// 插槽物品接口
	/// </summary>
	public interface ISlotItem
	{
		public bool IsAvailable();
		public void Activate(bool active);
		public SlotItemData GetSlotItemData();

		/// <summary>
		/// 设置至插槽
		/// </summary>
		public void SettleSlot(ISlot slot);
		public void Destory();
		/// <summary>
		/// 触发能力
		/// </summary>
		public CharacterInRoundData Trigger(CharacterInRoundData characterInRoundData);
	}
}
