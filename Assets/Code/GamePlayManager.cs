using Argali.Game.CardSystem;
using Argali.Game.CardSystem.UI;
using Argali.Game.CharacterSystem;
using Argali.Game.RouletteSystem;
using Argali.Module.Singleton;
using Argali.UI.Pop;
using Cysharp.Threading.Tasks;
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
		
		/// <summary>
		/// 开始一局新游戏
		/// </summary>
		/// <remarks>加载所有前置系统</remarks>
		public async void StartNewGame()
		{
			// 初始化卡片系统
			var loadCardSystem = UniTask.Create(async () =>
			{
				// 加载卡片模式，各个配置信息
				await CardSystemConfigLoader.Instance.LoadMode("base");
				// 初始化牌组
				CardSystemController.Instance.InitSystemWithDeck("base", CardSystemConfigLoader.Instance.ModeLoader.GetInfo("base"));
			});

			// 初始化转盘系统
			var loadRouletteSystem = UniTask.Create(async () =>
			{
				// 加载转盘模式，各个配置信息
				await RouletteSystemConfigLoader.Instance.LoadMode("base");
				// 初始化转盘系统
				RouletteSystemController.Instance.InitSystem("base", RouletteSystemConfigLoader.Instance.ModeLoader.GetInfo("base"));
			});

			// 初始化角色系统
			var loadCharacterSystem = UniTask.Create(async () =>
			{
				await CharacterSystemConfigLoader.Instance.LoadMode("base");
				// 初始化角色系统
				CharacterSystemController.Instance.InitSystem("normal");
			});
			
			// 等待所有加载完毕
			await UniTask.WhenAll(
				loadCardSystem,
				loadRouletteSystem,
				loadCharacterSystem
				);
			// 暂时直接开始回合
			StartRound().Forget();
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
		
		/// <summary>
		/// 开始回合
		/// </summary>
		/// <returns></returns>
		private async UniTaskVoid StartRound()
		{
			// 卡片系统 开始回合
			await CardSystemController.Instance.CreateRound();

			// 角色系统 开始回合
			await CharacterSystemController.Instance.CreateRound();

			// 最后加载面板
			PopRoundPanelAndStart();
		}


	}

}
