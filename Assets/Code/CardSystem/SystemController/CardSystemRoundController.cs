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
		/// 局内数据
		/// </summary>
		public CardSystemInRoundData InRoundData { get; private set; }
		private CardDeck _userDeck => CardSystemController.Instance.UserCardDeck;
		#endregion

		#region Event
		/// <summary>
		/// 当前回合剩余丢弃次数变更
		/// </summary>
		public event ValueChangeDelegated OnRestDropCountChanged;
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
		}
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
		/// 结束回合
		/// 开始结算
		/// </summary>
		public void EndRound()
		{
			// TODO
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
		public void DropCard(ICard card)
		{
			InRoundData.UseDropCount();
			OnRestDropCountChanged?.Invoke(InRoundData.RestDropCount);
			_userDeck.Drop(card);
			_userDeck.Draw();
		}
	}

}
