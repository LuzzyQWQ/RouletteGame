﻿using Argali.Game.CardSystem;
using Argali.Game.CardSystem.UI;
using Argali.Module.Singleton;
using Argali.UI.Pop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game
{
	/// <summary>
	/// 主游玩管理器
	/// </summary>
	public class GamePlayManager : Singleton<GamePlayManager> 
	{

		public void StartNewGame()
		{
			// 初始化卡片系统
			CardSystemController.Instance.InitSystemWithDeck("base", new CardSystemConfig() { PreDefinedCardDeckName = "",MaxHandCount = 5,DropCount = 2});
			CardSystemController.Instance.CreateRound();
			CardSystemController.Instance.CurrentRoundController.StartRound();
			var panel = PopPanelManager.Instance.OpenPopPanel<InRoundCardSystemPopPanel>();
			panel.Init(CardSystemController.Instance.CurrentRoundController);
		}
	}

}
