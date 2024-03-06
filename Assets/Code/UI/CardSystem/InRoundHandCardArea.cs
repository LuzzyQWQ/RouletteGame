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

		private RectTransform _buttonField;
		/// <summary>
		/// 弃牌按钮
		/// </summary>
		private Button _dropButton;
		/// <summary>
		/// 使用按钮
		/// </summary>
		private Button _useButton;
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
			UpdateButtonState();
		}

		/// <summary>
		/// 使用卡片
		/// </summary>
		/// <param name="carditem"></param>
		/// <param name="args"></param>
		public void UseCard(InRoundCardItem carditem, params object[] args)
		{
			OnUseCard?.Invoke(carditem, args);
			_currentCardItem = null;
			UpdateButtonState();
		}
		private void DropCard()
		{
			OnDropCard?.Invoke(_currentCardItem);
			_currentCardItem = null;
			UpdateButtonState();
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

			UpdateButtonState();
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
			_buttonField = transform.Find("ButtonField").GetComponent<RectTransform>();

			_dropButton = _buttonField.Find("DropButton").GetComponent<Button>();
			_useButton = _buttonField.Find("UseButton").GetComponent<Button>();
			// 暂定null
			_useButton.onClick.AddListener(() =>
			{
				UseCard(_currentCardItem, null);
			});
			_dropButton.onClick.AddListener(DropCard);
		}


		private void UpdateButtonState()
		{
			var data = CardSystemController.Instance.CurrentRoundController.InRoundData;
			_dropButton.interactable = _currentCardItem != null && data.RestDropCount > 0;
			_useButton.interactable = _currentCardItem != null && CardSystemController.Instance.UserCardDeck._handCards.Count > 0;
		}

	}

}
