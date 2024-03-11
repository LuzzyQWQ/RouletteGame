using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.RouletteSystem
{

	[Serializable]
	public class RouletteData 
	{
		/// <summary>
		/// 转盘名称
		/// </summary>
		public string RouletteName;

		/// <summary>
		/// 初始插槽名称 一一对应
		/// </summary>
		public List<string> InitSlotNames;

		/// <summary>
		/// 初始插槽物品名称 一一对应
		/// </summary>
		public List<string> InitSlotItemNames;
	}

}
