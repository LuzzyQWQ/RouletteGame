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

}
