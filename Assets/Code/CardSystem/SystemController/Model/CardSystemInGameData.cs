﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CardSystem
{
	/// <summary>
	/// 卡牌系统局内数据
	/// </summary>
	public class CardSystemInGameData
	{
		#region 数据
		/// <summary>
		/// 随机种子
		/// </summary>
		public string SeedName;

		/// <summary>
		/// 初始配置
		/// </summary>
		public CardSystemConfig InitConfig;

		/// <summary>
		/// 回合数
		/// </summary>
		public int RoundCount;

		/// <summary>
		/// 额外手牌数量
		/// </summary>
		public int ExtraHandCount;

		/// <summary>
		/// 额外弃牌数量
		/// </summary>
		public int ExtraDropCount;
		#endregion

		public int GetCurrentHashSeed()
		{
			return SeedName.ToLower().GetHashCode() + RoundCount;
		}
		
		public int GetCurrentHandCount()
		{
			return InitConfig.MaxHandCount + ExtraHandCount;
		}

		public int GetCurrentDropCount()
		{
			return InitConfig.DropCount + ExtraDropCount;
		}


		public CardSystemInGameData(CardSystemConfig config,string seed)
		{
			SeedName = seed;
			InitConfig = config;
			RoundCount = 0;
			ExtraHandCount = 0;
			ExtraDropCount = 0;
		}
	}
}

