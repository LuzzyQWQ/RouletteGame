using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CardSystem
{
	[SerializeField]
	/// <summary>
	/// 卡牌接口
	/// </summary>
	public interface ICard
	{
		/// <summary>
		/// 获得卡片属性
		/// </summary>
		public CardData GetCardData();

		/// <summary>
		/// 使用卡片
		/// </summary>
		public void UseCard(params object[] args);
		/// <summary>
		/// 选择卡片的事件
		/// </summary>
		public void SelectCard();

		/// <summary>
		/// 取消选择卡片事件
		/// </summary>
		public void UnselectCard();

	}
	/// <summary>
	/// 卡牌抽象基类
	/// </summary>
	public abstract class CardBase : MonoBehaviour, ICard
	{
		protected string _cardGuid;


		public CardBase(string cardId) 
		{
			_cardGuid = cardId;
		}
		public CardData GetCardData()
		{
			return CardConfigLoader.Instance.FindCardDataByID(_cardGuid);
		}

		public abstract void SelectCard();

		public abstract void UnselectCard();

		public abstract void UseCard(params object[] args);
	}
}
