using Argali.Game.CardSystem;
using Argali.Game.CardSystem.UI;
using Argali.Game.RouletteSystem;
using Argali.Module.Singleton;
using Argali.UI.Pop;
using MEC;
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
			// TODO
			// 未来需要将Loading异步处理
			// 初始化卡片系统
			CardSystemConfigLoader.Instance.LoadMode("base", () =>
			{
				CardSystemController.Instance.InitSystemWithDeck("base", CardSystemConfigLoader.Instance.ModeLoader.GetInfo("base"));

				// 初始化转盘系统
				RouletteSystemConfigLoader.Instance.LoadMode("base", () =>
				{
					RouletteSystemController.Instance.InitSystem("base", RouletteSystemConfigLoader.Instance.ModeLoader.GetInfo("base"));
					// 开始回合
					CardSystemController.Instance.CreateRound(PopRoundPanelAndStart);
				});
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
