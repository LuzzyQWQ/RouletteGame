using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.RouletteSystem
{
	/// <summary>
	/// 攻击力增加的插槽物品
	/// </summary>
	public class AttackUpSlotItem : SlotItemBase
	{
		public AttackUpSlotItem(string slotItemName) : base(slotItemName)
		{
		}
		
		/// <summary>
		/// 增加攻击力
		/// </summary>
		public override void Trigger()
		{
			Debug.Log("攻击力增加了");
		}
	}

}
