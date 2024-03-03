using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Argali.Game.CardSystem
{

	/// <summary>
	/// 用于控制当前回合的卡组行为
	/// </summary>
	public class CardSystemRoundController
	{
		#region 属性
		/// <summary>
		/// 当前选择的卡片
		/// </summary>
		public ICard CurrentSelectedCard { get; private set; }
		/// <summary>
		/// 局内数据
		/// </summary>
		public CardSystemInRoundData InRoundData { get; private set; }
		private CardDeck _userDeck => CardSystemController.Instance.UserCardDeck;
		#endregion

		#region 构造
		public CardSystemRoundController(CardSystemInRoundData inRoundData)
		{
			InRoundData = inRoundData;
		}
		public CardSystemRoundController() 
		{
			InRoundData = new CardSystemInRoundData(CardSystemController.Instance.SystemInGameData.GetCurrentDropCount());
		}
		#endregion

		/// <summary>
		/// 开始回合
		/// </summary>
		public void StartRound()
		{
			// 初始化卡组
			_userDeck.Init(CardSystemController.Instance.SystemInGameData.GetCurrentHashSeed());
			// 抽n张牌
			int drawCount = CardSystemController.Instance.SystemInGameData.GetCurrentHandCount();
			for (int i = 0; i < drawCount; i++)
			{
				_userDeck.Draw();
			}
		}
		/// <summary>
		/// 结束回合
		/// 开始结算
		/// </summary>
		public void EndRound()
		{
			// TODO
		}

		/// <summary>
		/// 选择卡牌
		/// </summary>
		/// <param name="card"></param>
		public void SelectCard(ICard card)
		{
			if (card == CurrentSelectedCard)
			{
				card.UnselectCard();
				CurrentSelectedCard = null;
				return;
			}
			if (CurrentSelectedCard != null)
			{
				CurrentSelectedCard.UnselectCard();
			}
			card.SelectCard();
			CurrentSelectedCard = card;
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
		/// 弃置卡牌
		/// </summary>
		/// <param name="card"></param>
		public void DropCard(ICard card)
		{
			InRoundData.UseDropCount();
			_userDeck.Drop(card);
			_userDeck.Draw();
		}
	}

}
