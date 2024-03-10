using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.RouletteSystem
{
	[CreateAssetMenu(fileName ="Slot Map Config",menuName = "Roulette System/Slot Map Config",order = 5)]
	public class SlotMapConfig : ScriptableObject
	{
		public List<SlotInfo> data;
	}

}
