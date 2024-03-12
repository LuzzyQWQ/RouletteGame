using Argali.Module.DataBase.ConfigLoader;
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
	[CreateAssetMenu(fileName ="Roulette System Mode Config", menuName = "Roulette System/Roulette System Mode Config",order = 0)]
	public class RouletteSystemModeConfig :ScriptableObject
	{
		public List<RouletteSystemModeInfo> data;
	}

	/// <summary>
	/// 轮盘游戏模式信息
	/// </summary>
	[Serializable]
	public class RouletteSystemModeInfo: IConfigInfo
	{
		/// <summary>
		/// 模式名称
		/// </summary>
		public string ModeName;
		/// <summary>
		/// 使用的插槽物品配置
		/// </summary>
		public string SlotItemConfigPath;

		public string GetGUID()
		{
			return ModeName;
		}
	}
}
