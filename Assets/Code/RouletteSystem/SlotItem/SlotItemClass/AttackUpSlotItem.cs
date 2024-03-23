using Argali.Game.CharacterSystem;
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
		public override CharacterInRoundData Trigger(CharacterInRoundData characterInRoundData)
		{
			int attackUpCount = 10;
			characterInRoundData.Attack += attackUpCount;
			Debug.Log(string.Format("触发第 {0} 格攻击增加物品，攻击力增加了{1}, 当前攻击力为 {2}",characterInRoundData.CurrentIndex,attackUpCount, characterInRoundData.Attack));
			Debug.Log(string.Format("当前敌人攻击力 {0}",CharacterSystemController.Instance.EnemyRoundController.EnemyRoundData.Attack));
			return characterInRoundData;
		}
	}

}
