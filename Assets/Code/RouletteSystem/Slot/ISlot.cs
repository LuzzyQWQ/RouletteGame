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

		public void Trigger(SlotItemTriggerType triggerType);
	}
}
