using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.RouletteSystem
{
	/// <summary>
	/// 插槽物品抽象类
	/// </summary>
	public abstract class SlotItemBase : ISlotItem
	{

		#region Element
		protected SlotItemTriggerType _triggerType;
		protected bool _active;
		protected ISlot _locateSlot;
		#endregion
		public SlotItemBase()
		{
			_active = true;
		}


		public SlotItemTriggerType GetTriggerType()
		{
			return _triggerType;
		}
		public bool IsAvailable() { return _active; }
		public void Activate(bool active) {  _active = active; }
		public void SettleSlot(ISlot slot)
		{
			_locateSlot = slot;
		}
		public virtual void Destory() 
		{ 
			if (_locateSlot != null)
			{
				_locateSlot.RemoveSlotItem(this);
			}
		}
		public abstract void Trigger();


	}

}
