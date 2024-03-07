using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Argali.Game.CardSystem
{
	/// <summary>
	/// 卡牌抽象基类
	/// </summary>

	public abstract class CardBase : ICard
	{
		protected string _cardName;

		public CardBase(){}

		public void SetCardName(string guid)
		{
			_cardName = guid;
		}
		public string GetCardName()
		{
			return _cardName;
		}	
		public CardData GetCardData()
		{
			return CardConfigLoader.Instance.FindCardDataByID(_cardName);
		}

		public abstract void SelectCard();

		public abstract void UnselectCard();

		public abstract void UseCard(params object[] args);
		
		/// <summary>
		/// 展示参数界面
		/// </summary>
		public abstract void ShowArgsPanel();
	}
}
