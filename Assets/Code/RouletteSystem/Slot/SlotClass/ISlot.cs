using Argali.Game.CharacterSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.RouletteSystem
{
	/// <summary>
	/// 轮盘插槽类
	/// </summary>
	public interface ISlot
	{
		public bool IsAvailable();
		public void Activate(bool active);

		public bool IsDestroyed();
		public void Destroy();

		public List<ISlotItem> GetSlotItems();

		public void RegisterSlotItem(ISlotItem slotItem);
		public void RemoveSlotItem(ISlotItem slotItem);
		
		/// <summary>
		/// 按照触发类型触发插槽物品，并对用户的属性进行修改
		/// </summary>
		/// <param name="characterData"></param>
		/// <param name="triggerType"></param>
		public CharacterInRoundData Trigger(CharacterInRoundData characterData, SlotItemTriggerType triggerType);
	}
}
