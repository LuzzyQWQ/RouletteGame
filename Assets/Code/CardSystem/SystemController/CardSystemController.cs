using Argali.Module.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CardSystem
{

	public enum CardSystemState
	{
		InRound,		// 在局内
		NotInRound,		// 在局外
	}

	/// <summary>
	/// 卡片系统控制器
	/// </summary>
	public class CardSystemController : Singleton<CardSystemController> 
	{
		#region 属性
		/// <summary>
		/// 用户卡组
		/// </summary>
		public CardDeck UserCardDeck {  get; private set; }
		
		/// <summary>
		/// 系统数据
		/// </summary>
		public CardSystemInGameData SystemInGameData { get; private set; }

		/// <summary>
		/// 回合控制器
		/// </summary>
		public CardSystemRoundController CurrentRoundController { get; private set; }
		#endregion

		/// <summary>
		/// 初始化系统
		/// </summary>
		public void InitSystem(CardSystemConfig config)
		{
			InitSystem(config, DateTime.UtcNow.ToString());
		}
		public void InitSystem(CardSystemConfig config, string seed)
		{
			InitSystemWithDeck(config.PreDefinedCardDeckName, config, seed);
		}
		public void InitSystemWithDeck(string deckName, CardSystemConfig config, string seed)
		{
			SystemInGameData = new CardSystemInGameData(config, seed);
			SpawnCardDeck(deckName);
		}
		public void InitSystemWithDeck(string deckName, CardSystemConfig config)
		{
			InitSystemWithDeck(deckName,config, DateTime.UtcNow.ToString());
		}


		/// <summary>
		/// 生成用户卡组，仅在游戏开始时生成
		/// </summary>
		private void SpawnCardDeck(string name) { 
			// 使用预设的初始卡组
			UserCardDeck = new CardDeck(CardConfigLoader.Instance.GetInitialDeckCards(name));
		}

		/// <summary>
		/// 创建回合控制器
		/// 需要初始化牌组
		/// </summary>
		public void CreateRound(System.Action onFinish)
		{
			SystemInGameData.RoundCount++;
			CurrentRoundController = new CardSystemRoundController(onFinish);
		}
		/// <summary>
		/// 加载回合控制器
		/// </summary>
		public void LoadRound()
		{
			// TODO
		}
		
		/// <summary>
		/// 结束回合，传入是否过关
		/// </summary>
		public void EndRound()
		{

		}

	}

}
