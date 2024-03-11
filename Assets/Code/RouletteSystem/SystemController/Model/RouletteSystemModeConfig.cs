using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.RouletteSystem
{
	/// <summary>
	/// 轮盘系统游戏模式配置表
	/// 用于一些全局通用的规则，如 可以出现的插槽、插槽物品等等
	/// </summary>
	[CreateAssetMenu(fileName ="Roulette System Config", menuName = "Roulette System/Roulette System Config",order = 0)]
	public class RouletteSystemModeConfig :ScriptableObject
	{
		public List<RouletteSystemModeInfo> data;
	}

	/// <summary>
	/// 轮盘游戏模式信息
	/// </summary>
	[Serializable]
	public struct RouletteSystemModeInfo
	{
		/// <summary>
		/// 使用的插槽物品配置
		/// </summary>
		public string SlotItemConfigPath;
		
		
	}
}
