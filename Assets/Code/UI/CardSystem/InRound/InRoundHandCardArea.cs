using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Argali.Game.CardSystem.UI
{
	/// <summary>
	/// 局内手牌 UI 
	/// </summary>
	public class InRoundHandCardArea : MonoBehaviour
	{
		#region Element
		[SerializeField]
		private GameObject _cardItemPrefab;

		private RectTransform _handCardContainer;
		#endregion

		#region Parameter
		private InRoundCardItem _currentCardItem;
		#endregion

		#region Event
		public delegate void SelectCardItemDelegate(InRoundCardItem lastItem, InRoundCardItem currentItem);
		public delegate void HoverCardItemDelegate(InRoundCardItem item);
		public delegate void UseCardItemDelegate(InRoundCardItem item, params object[] args);
		public delegate void DropCardItemDelegate(InRoundCardItem item);

		public event SelectCardItemDelegate OnSelectCard;
		public event HoverCardItemDelegate OnHoverCard;
		public event UseCardItemDelegate OnUseCard;
		public event DropCardItemDelegate OnDropCard;
		#endregion



		/// <summary>
		/// 选择卡片
		/// </summary>
		public void SelectCard(InRoundCardItem cardItem)
		{
			OnSelectCard?.Invoke(_currentCardItem, cardItem);
			if (_currentCardItem == cardItem)
			{
				_currentCardItem = null;
			}
			else
			{
				_currentCardItem = cardItem;
			}
		}
		/// <summary>
		/// 取消选择
		/// </summary>
		public void UnSelect()
		{
			if (_currentCardItem !=null)
			{
				OnSelectCard?.Invoke(_currentCardItem, _currentCardItem);
				_currentCardItem = null;
			}
		}

		/// <summary>
		/// 使用当前选中卡片
		/// </summary>
		/// <param name="carditem"></param>
		/// <param name="args"></param>
		public void UseCurrentCard(params object[] args)
		{
			if (_currentCardItem == null)
			{
				Debug.LogError("当前未选中任何卡片，但是依然在使用卡片");
				return;
			}
			OnUseCard?.Invoke(_currentCardItem, args);
			_currentCardItem = null;
		}
		/// <summary>
		/// 弃牌，并通知所有弃牌事件
		/// </summary>
		public void DropCard()
		{
			OnDropCard?.Invoke(_currentCardItem);
			_currentCardItem = null;
		}
		/// <summary>
		/// 悬停卡片
		/// </summary>
		/// <param name="carditem"></param>
		public void HoverCard(InRoundCardItem carditem)
		{
			OnHoverCard?.Invoke(carditem);
		}

		/// <summary>
		/// 初始化手牌区域
		/// </summary>
		/// <param name="cards"></param>
		public void Init()
		{
			ClearDeckArea();
		}
		private void ClearDeckArea()
		{
			for (int i = 0; i < _handCardContainer.childCount; i++)
			{
				Destroy(_handCardContainer.GetChild(i));
			}
		}
		private void SpawnCard(ICard card)
		{
			InRoundCardItem item = Instantiate(_cardItemPrefab, _handCardContainer).GetComponent<InRoundCardItem>();
			item.InitCardItem(card as CardBase);
		}

		private void OnEnable()
		{
			if (CardSystemController.Instance != null)
			{
				if (CardSystemController.Instance.UserCardDeck != null)
				{
					CardSystemController.Instance.UserCardDeck.OnDrawCard += SpawnCard;
				}
			}
		}


		private void OnDisable()
		{
			if (CardSystemController.Instance != null)
			{
				if (CardSystemController.Instance.UserCardDeck != null)
				{
					CardSystemController.Instance.UserCardDeck.OnDrawCard -= SpawnCard;
				}
			}
		}
		private void Awake()
		{
			InitElement();
		}
		private void InitElement()
		{
			_handCardContainer = transform.Find("Container").GetComponent<RectTransform>();

		}


	}

}
