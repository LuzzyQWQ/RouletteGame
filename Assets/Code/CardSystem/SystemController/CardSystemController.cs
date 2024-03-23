using Argali.Module.Singleton;
using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CardSystem
{

	/// <summary>
	/// 卡片系统控制器
	/// </summary>
	public class CardSystemController : Singleton<CardSystemController> , ISystemController
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
		public CardSystemRoundController RoundController { get; private set; }
		#endregion


		#region 方法

		#region 初始化方法
		/// <summary>
		/// 初始化系统
		/// </summary>
		public void InitSystem(CardSystemModeInfo config)
		{
			InitSystemWithDeck(config.PreDefinedCardDeckName, config);
		}
		public void InitSystemWithDeck(string deckName, CardSystemModeInfo config)
		{
			SystemInGameData = new CardSystemInGameData(config);
			// 生成用户卡组
			UserCardDeck = new CardDeck(CardSystemConfigLoader.Instance.GetInitCardDeck(deckName));
		}

		#endregion


		#region 回合相关方法
		public async UniTask CreateRound()
		{
			RoundController = await CardSystemRoundController.Create();
		}
		public async UniTask LoadRound()
		{
			await UniTask.Yield();
		}
		
		public void EndRound()
		{
			RoundController.Destroy();
			RoundController = null;
		}
		#endregion

		#endregion
	}

}
