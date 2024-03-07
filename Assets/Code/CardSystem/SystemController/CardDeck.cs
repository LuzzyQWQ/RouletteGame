using Argali.Game.CardSystem.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Argali.Game.CardSystem
{

	/// <summary>
	/// 卡堆类
	/// </summary>
	public class CardDeck
	{
		#region 属性
		public  List<ICard> _allCardsList;
		public  List<ICard> _drawCardsList;
		public List<ICard> _usedCardsList;
		public List<ICard> _handCards;

		#endregion

		#region Delegate

		/// <summary>
		/// 使用牌堆的数量变化事件
		/// </summary>
		public event ValueChangeDelegated OnUsedCardsCountChange;
		/// <summary>
		/// 手牌数量变化事件
		/// </summary>
		public event ValueChangeDelegated OnHandCardsCountChange;
		/// <summary>
		/// 抽牌堆数量变化事件
		/// </summary>
		public event ValueChangeDelegated OnDrawCardsCountChange;
		/// <summary>
		/// 所拥有的卡组数量变化事件
		/// </summary>
		public event ValueChangeDelegated OnAllCardsCountChange;

		public event CardChangeDelegated OnDrawCard;
		public event CardChangeDelegated OnDropCard;
		#endregion


		#region 构造
		/// <summary>
		/// 创建卡组
		/// </summary>
		/// <param name="initialCard"></param>
		public CardDeck(List<ICard> initialCard)
		{
			_allCardsList = initialCard;
			_drawCardsList = new();
			_usedCardsList = new();
			_handCards = new();
		}
		#endregion

		/// <summary>
		/// 初始化牌堆，填充抽牌库，清空弃牌库，初始化手牌。
		/// 用于每回合开始时
		/// </summary>
		/// <param name="seed">随机种子</param>
		public void Init(int seed)
		{
			_drawCardsList = new List<ICard>(_allCardsList);
			CardShuffle.ShuffleCards(ref _drawCardsList,seed);
			_usedCardsList.Clear();
			_handCards.Clear();
		}
		
		/// <summary>
		/// 从卡堆中抽一张卡
		/// </summary>
		public void Draw()
		{
			ICard card = _drawCardsList[0];
			_handCards.Add(card);
			_drawCardsList.RemoveAt(0);
			OnDrawCard?.Invoke(card);
			OnDrawCardsCountChange?.Invoke(_drawCardsList.Count);
			OnHandCardsCountChange?.Invoke(_handCards.Count);
			CheckDrawList();
		}

		/// <summary>
		/// 从手牌中丢弃一张牌
		/// </summary>
		/// <param name="card"></param>
		public void Drop(ICard card)
		{
			_handCards.Remove(card);
			_usedCardsList.Add(card);
			OnDropCard?.Invoke(card);
			OnUsedCardsCountChange?.Invoke(_usedCardsList.Count);
		}

		/// <summary>
		/// 添加一张卡到卡组中
		/// </summary>
		/// <param name="card"></param>
		public void AddCardToDeck(ICard card)
		{
			_allCardsList.Add(card);
			OnAllCardsCountChange?.Invoke(_allCardsList.Count);
		}
		/// <summary>
		/// 从卡组销毁一张卡
		/// </summary>
		/// <param name="card"></param>
		public void RemoveCardFromDeck(ICard card)
		{
			_allCardsList.Remove(card);
			OnAllCardsCountChange?.Invoke(_allCardsList.Count);
		}
		/// <summary>
		/// 检查抽卡堆是否空
		/// </summary>
		private void CheckDrawList()
		{
			if (_drawCardsList.Count == 0 && _usedCardsList.Count > 0)
			{
				_drawCardsList = new List<ICard>(_usedCardsList);
				_usedCardsList.Clear();
				CardShuffle.ShuffleCards(ref _drawCardsList, 0);
				OnDrawCardsCountChange?.Invoke(_drawCardsList.Count);
				OnUsedCardsCountChange?.Invoke(_usedCardsList.Count);
			}
		}

	}
}
