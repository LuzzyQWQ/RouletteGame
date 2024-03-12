using Argali.Module.DataBase.ConfigLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CardSystem
{
	[CreateAssetMenu(fileName = "Card System Mode Config", menuName = "Card System/Card System Mode Config",order = 0)]
	/// <summary>
	/// 卡牌系统模式配置
	/// </summary>
	public class CardSystemModeConfig : ScriptableObject
	{
		public List<CardSystemModeInfo> data;
	}
	/// <summary>
	/// 卡牌系统模式信息
	/// </summary>
	[Serializable]
	public class CardSystemModeInfo : IConfigInfo
	{
		/// <summary>
		/// 模式名称
		/// </summary>
		public string ModeName;

		/// <summary>
		/// 预定义卡组名
		/// </summary>
		public string PreDefinedCardDeckName;

		/// <summary>
		/// 卡片范围配置路径
		/// </summary>
		public string CardConfigPath;

		/// <summary>
		/// 最大手牌数
		/// </summary>
		public int MaxHandCount;
		/// <summary>
		/// 初始弃牌数量
		/// </summary>
		public int DropCount;

		public string GetGUID()
		{
			return ModeName;
		}
	}
}
