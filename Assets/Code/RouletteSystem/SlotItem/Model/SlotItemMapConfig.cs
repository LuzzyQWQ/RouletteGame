using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.RouletteSystem
{
	/// <summary>
	/// 插槽物品配置表
	/// </summary>
	[CreateAssetMenu(fileName ="Slot Item Map Config",menuName = "Roulette System/Slot Item Map Config",order = 1)]
	public class SlotItemMapConfig :ScriptableObject 
	{
		public List<SlotItemInfo> data;
	}

}
