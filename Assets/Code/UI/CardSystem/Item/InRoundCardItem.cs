using Argali.UI.Pop;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Argali.Game.CardSystem.UI
{
	/// <summary>
	/// 局内卡片Item UI
	/// </summary>
	public class InRoundCardItem : MonoBehaviour
	{
		#region Element
		private Image _bg;
		private TMP_Text _cardNameText;
		private Button _selectButton;
		private InRoundCardItemController _cardItemController;

		// 选择后展开区域
		private GameObject _selectedArea;
		private Button _dropButton;
		private Button _tryUseButton;
		#endregion

		#region Property
		/// <summary>
		/// 卡片数据
		/// </summary>
		private CardBase Card;

		#endregion

		/// <summary>
		/// 生成初始化
		/// </summary>
		/// <param name="card"></param>
		public void InitCardItem(CardBase card)
		{
			Card = card;
			_cardNameText.text = card.GetCardName();
			_selectedArea.SetActive(false);
			OnDropCountChange(CardSystemController.Instance.CurrentRoundController.InRoundData.RestDropCount);
		}

		#region  卡片事件委托
		private void OnSelect(InRoundCardItem lastItem, InRoundCardItem currentItem)
		{
			if (lastItem != this)
			{
				if (currentItem == this)
				{
					// 选择此卡片事件
					// TODO
					ChangeBGColor(true);
					_selectedArea.SetActive(true);
					Card.SelectCard();
				}
			}
			else
			{
				// 取消选择该卡片事件
				// TODO
				ChangeBGColor(false);
				_selectedArea.SetActive(false);
				Card.UnselectCard();
			}
		}

		private void OnUse(InRoundCardItem item, params object[] args)
		{
			if (item == this)
			{
				CardSystemController.Instance.CurrentRoundController.UseCard(Card, args);
				Destroy(gameObject);
			}
		}

		private void OnDrop(InRoundCardItem item)
		{
			if (item == this)
			{
				CardSystemController.Instance.CurrentRoundController.DropAndDrawCard(Card);
				Destroy(gameObject);
			}
		}
		private void OnHover(InRoundCardItem cardItem)
		{
			// TODO
			// 悬浮时显示卡片信息
		}
		private void OnDropCountChange(int count)
		{
			_dropButton.interactable = count > 0;
		}
		#endregion

		private void ChangeBGColor(bool selected)
		{
			_bg.color = selected ? Color.blue : Color.white;
		}


		private void Awake()
		{
			InitElement();
		}
		private void Start()
		{
			_cardItemController.OnHoverCardItem += OnHover;
			_cardItemController.OnSelectCardItem += OnSelect;
			_cardItemController.OnUseCardItem += OnUse;
			_cardItemController.OnDropCardItem += OnDrop;
			CardSystemController.Instance.CurrentRoundController.OnRestDropCountChanged += OnDropCountChange;
		}
		private void OnDisable()
		{
			_cardItemController.OnHoverCardItem -= OnHover;
			_cardItemController.OnSelectCardItem -= OnSelect;
			_cardItemController.OnUseCardItem -= OnUse;
			_cardItemController.OnDropCardItem -= OnDrop;
			if (CardSystemController.Instance != null)
			{
				CardSystemController.Instance.CurrentRoundController.OnRestDropCountChanged -= OnDropCountChange;
			}
		}
		private void InitElement()
		{
			_cardItemController = CardSystemController.Instance.CurrentRoundController.CardItemController;
			_bg = transform.Find("CardBG").GetComponent<Image>();
			_cardNameText = transform.Find("CardNameText").GetComponent<TMP_Text>();
			_selectButton = transform.Find("SelectButton").GetComponent<Button>();
			_selectButton.onClick.AddListener(() => { _cardItemController.SelectCard(this); });

			// 选择扩展区域
			_selectedArea = transform.Find("SelectedArea").gameObject;
			_dropButton = _selectedArea.transform.Find("DropButton").GetComponent<Button>();
			_tryUseButton = _selectedArea.transform.Find("TryUseButton").GetComponent<Button>();

			_dropButton.onClick.AddListener(OnDropButtonClick);
			_tryUseButton.onClick.AddListener(OnTryUseButtonClick);
		}

		#region 按钮事件

		private void OnDropButtonClick()
		{
			_cardItemController.DropCard();
		}
		private void OnTryUseButtonClick()
		{
			if (Card == null)
			{
				Debug.LogError("卡片数据为空");
				return;
			}
			Card.ShowArgsPanel();
		}
		#endregion
	}

}
