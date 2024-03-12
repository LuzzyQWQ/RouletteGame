using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.RouletteSystem
{
	/// <summary>
	/// 插槽抽象类
	/// </summary>
	public abstract class SlotBase : ISlot
	{
		#region 属性
		protected string _slotName;
		protected bool _active;
		protected bool _destroyed;
		protected List<ISlotItem> _slotItems;
		#endregion

		#region 委托
		protected event SlotItemHandleDelegate _onSlotItemAdd;
		protected event SlotItemHandleDelegate _onSlotItemRemove;
		#endregion
		public SlotBase(string slotName)
		{
			_slotName = slotName;
			_active = true;
			_destroyed = false;
			_slotItems = new List<ISlotItem>();
		}

		#region ISlot 继承
		public bool IsAvailable(){	return _active; }
		public virtual void Activate(bool active) { _active = active; }
		public bool IsDestroyed(){ return _destroyed; }
		public virtual void Destroy() { _destroyed = true;}

		public List<ISlotItem> GetSlotItems() { return _slotItems; }
		public void RegisterSlotItem(ISlotItem slotItem)
		{
			_slotItems.Add(slotItem);
			_onSlotItemAdd?.Invoke(slotItem);
		}
		public void RemoveSlotItem(ISlotItem slotItem)
		{
			_slotItems.Remove(slotItem);
			_onSlotItemRemove?.Invoke(slotItem);
		}

		public virtual void Trigger(SlotItemTriggerType triggerType) 
		{
			foreach (var slotitem in _slotItems)
			{
				if (slotitem.GetSlotItemData().TriggerType == triggerType)
				{
					slotitem.Trigger();
				}
			}
		}
		#endregion
	}

}
