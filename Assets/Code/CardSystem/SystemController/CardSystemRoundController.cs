using Argali.Game.CardSystem.UI;
using Argali.UI.Pop;
using Cysharp.Threading.Tasks;
using MEC;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Argali.Game.CardSystem
{

	/// <summary>
	/// 卡片系统回合控制器
	/// </summary>
	/// <remarks>用于控制当前回合的卡组行为</remarks>
	public class CardSystemRoundController
	{
		#region 属性
		/// <summary>
		/// 局内数据
		/// </summary>
		public CardSystemInRoundData InRoundData { get; private set; }
		private CardDeck _userDeck => CardSystemController.Instance.UserCardDeck;
		
		/// <summary>
		/// 初始化完成事件
		/// </summary>
		private System.Action _onInitFinish;
		#endregion

		#region 子控制器
		// UI相关
		public InRoundCardItemController CardItemController { get; private set; }

		public InRoundCardItemSpawner CardItemSpawner { get; private set; }
		#endregion


		#region Event
		/// <summary>
		/// 当前回合剩余丢弃次数变更
		/// </summary>
		public event ValueChangeDelegated OnRestDropCountChanged;
		#endregion

		#region 构造
		private CardSystemRoundController(CardSystemInRoundData inRoundData):this()
		{
			InRoundData = inRoundData;
		}
		private CardSystemRoundController() 
		{
			InRoundData = new CardSystemInRoundData(CardSystemController.Instance.SystemInGameData.GetCurrentDropCount());
			CardItemController = new InRoundCardItemController();
		}

		/// <summary>
		/// 创建回合控制器
		/// </summary>
		/// <returns></returns>
		public static async UniTask<CardSystemRoundController> Create()
		{
			CardSystemRoundController intance = new CardSystemRoundController();
			intance.CardItemSpawner = await InRoundCardItemSpawner.Create();
			return intance;
		}
		#endregion


		/// <summary>
		/// 开始回合
		/// </summary>
		public void StartRound()
		{
			// 初始化卡组
			_userDeck.Init(CardSystemController.Instance.SystemInGameData.GetCurrentHashSeed());

		}



		/// <summary>
		/// 结束回合
		/// </summary>
		public void EndRound()
		{
			// 清除资源引用
			CardItemSpawner.Destroy();
			// 暂时回到首页
			PopPanelManager.Instance.ClosePopPanel<InRoundCardSystemPopPanel>();
		}
		
		/// <summary>
		/// 抽取初始的卡组
		/// </summary>
		public void DrawInitCards()
		{
			// 抽n张牌
			int drawCount = CardSystemController.Instance.SystemInGameData.GetCurrentHandCount();
			for (int i = 0; i < drawCount; i++)
			{
				_userDeck.Draw();
			}
		}


		/// <summary>
		/// 使用卡牌
		/// </summary>
		/// <param name="card"></param>
		public void UseCard(ICard card, params object[] args)
		{
			card.UseCard(args);
			CardSystemController.Instance.UserCardDeck.Drop(card);
		}

		/// <summary>
		/// 弃置卡牌,并抽取一张新的放入手牌
		/// </summary>
		/// <param name="card"></param>
		public void DropAndDrawCard(ICard card)
		{
			InRoundData.UseDropCount();
			OnRestDropCountChanged?.Invoke(InRoundData.RestDropCount);
			_userDeck.Drop(card);
			_userDeck.Draw();
		}
	}

}
