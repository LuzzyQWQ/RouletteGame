using Argali.Game.CharacterSystem;
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
		/// <summary>
		/// 插槽物品名字
		/// </summary>
		protected string _slotItemName;

		protected bool _active;
		protected ISlot _locateSlot;
		#endregion
		public SlotItemBase(string slotItemName)
		{
			_slotItemName = slotItemName;
			_active = true;
			_locateSlot = null;
		}


		public SlotItemData GetSlotItemData()
		{
			return RouletteSystemConfigLoader.Instance.SlotItemLoader.GetInfo(_slotItemName).SlotItemData;
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
		public abstract CharacterInRoundData Trigger(CharacterInRoundData characterInRoundData);


	}

}
