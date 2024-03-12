using Argali.Game.CardSystem;
using Argali.Game.CardSystem.UI;
using Argali.Game.RouletteSystem;
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

			// 初始化转盘系统
			RouletteSystemConfigLoader.Instance.LoadMode("base", () =>
			{
				RouletteSystemController.Instance.InitSystem("base", RouletteSystemConfigLoader.Instance.ModeLoader.GetInfo("base"));
				// 开始回合
				CardSystemController.Instance.CreateRound(PopRoundPanelAndStart);
			});


			
		}
		/// <summary>
		/// 弹出回合游戏界面， 开始游戏
		/// </summary>
		private void PopRoundPanelAndStart()
		{
			CardSystemController.Instance.CurrentRoundController.StartRound();
			var panel = PopPanelManager.Instance.OpenPopPanel<InRoundCardSystemPopPanel>();
			panel.Init(CardSystemController.Instance.CurrentRoundController);
		}
	}

}
