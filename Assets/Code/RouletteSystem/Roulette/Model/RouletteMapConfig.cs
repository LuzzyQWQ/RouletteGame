using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.RouletteSystem
{
	/// <summary>
	/// 转盘初始配置
	/// </summary>
	[CreateAssetMenu(fileName ="Roulette Map Config",menuName = "Roulette System/Roulette Map Config",order = 5)]
	public class RouletteMapConfig :ScriptableObject
	{
		public List<RouletteInfo> data;
	}


	/// <summary>
	/// 初始转盘信息
	/// </summary>
	[Serializable]
	public struct RouletteInfo
	{
		public int Index;
		public RouletteData RouletteData;
		public string ClassName;
	}
}
