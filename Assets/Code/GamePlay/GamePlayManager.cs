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
		#region 属性
		
		/// <summary>
		/// 通用局内数据
		/// </summary>
		public GeneralInGameData GeneralInGameData { get; private set; }
		#endregion



		/// <summary>
		/// 开始一局新游戏
		/// </summary>
		/// <remarks>加载所有前置系统</remarks>
		public async void StartNewGame()
		{
			// 初始化单局数据
			GeneralInGameData = GeneralInGameData.Create();
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

			// 暂时进入回合选择界面
			PopPanelManager.Instance.OpenPopPanel<RoundSelectPanel>();
			
			// 暂时直接开始回合
			//StartRound().Forget();
		}


		
		/// <summary>
		/// 开始回合
		/// </summary>
		/// <returns></returns>
		public async UniTaskVoid StartRound()
		{
			// 卡片系统 开始回合
			await CardSystemController.Instance.CreateRound();
			//CardSystemController.Instance.RoundController.StartRound();

			// 角色系统 开始回合
			await CharacterSystemController.Instance.CreateRound();
			//CharacterSystemController.Instance.PlayerRoundController.StartRound();

			// 最后加载面板
			PopRoundPanel();
		}

		/// <summary>
		/// 尝试结束回合
		/// </summary>
		/// <returns></returns>
		public async UniTaskVoid TryEndRound()
		{
			bool success = false;
			// 结算时逻辑
			// 角色的攻击力大于敌人的攻击力
			success = CharacterSystemController.Instance.PlayerRoundController.PlayerRoundData.Attack >= CharacterSystemController.Instance.EnemyRoundController.EnemyRoundData.Attack;


			if (success)
			{
				Debug.Log(string.Format("成功通过第 {0} 关",GeneralInGameData.CurrentRound));
				// TODO: 成功通过结算后的逻辑
				GeneralInGameData.CurrentRound++;

				PopPanelManager.Instance.ClosePopPanel<InRoundCardSystemPopPanel>();
			}
			else
			{
				Debug.LogError(string.Format("第 {0} 关 通关失败", GeneralInGameData.CurrentRound));
				// TODO: 失败后的逻辑

				// 回到主界面
				PopPanelManager.Instance.ClosePopPanel<InRoundCardSystemPopPanel>();
				PopPanelManager.Instance.ClosePopPanel<RoundSelectPanel>();
			}
			// TODO: 需要抽象一个SystemController类出来
			// TODO: 需要在EndRound之中，Dispose掉RoundController
			// TODO: 需要提取一个RoundController 抽象类， 用于快速处理析构函数
			CharacterSystemController.Instance.EndRound();
			CardSystemController.Instance.EndRound();
		}
		/// <summary>
		/// 弹出回合游戏界面
		/// </summary>
		private void PopRoundPanel()
		{
			//CardSystemController.Instance.RoundController.StartRound();
			var panel = PopPanelManager.Instance.OpenPopPanel<InRoundCardSystemPopPanel>();
			panel.Init(CardSystemController.Instance.RoundController).Forget();
		}

	}

}
