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
		private InRoundHandCardArea _handCardArea;
		#endregion

		#region Property
		/// <summary>
		/// 卡片数据
		/// </summary>
		private CardBase Card;

		#endregion

		public void InitCardItem(CardBase card)
		{
			Card = card;
			_cardNameText.text = card.GetCardName();
		}
		private void OnSelect(InRoundCardItem lastItem, InRoundCardItem currentItem)
		{
			if (lastItem != this)
			{
				if (currentItem == this)
				{
					// 选择此卡片事件
					// TODO
					ChangeBGColor(true);
					Card.SelectCard();
				}
			}
			else
			{
				// 取消选择该卡片事件
				// TODO
				ChangeBGColor(false);
				Card.UnselectCard();
			}
		}

		private	 void OnUse(InRoundCardItem item, params object[] args)
		{
			if(item == this) 
			{
				CardSystemController.Instance.CurrentRoundController.UseCard(Card,args);
				Destroy(gameObject);
			}
		}

		private void OnDrop(InRoundCardItem item)
		{
			if (item == this)
			{
				CardSystemController.Instance.CurrentRoundController.DropCard(Card);
				Destroy(gameObject);
			}
		}

		public void OnHover(InRoundCardItem cardItem)
		{
			// TODO
			// 悬浮时显示卡片信息
		}
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
			var handCardArea = PopPanelManager.Instance.GetPopPanel<InRoundCardSystemPopPanel>().CardDeckArea.HandCardArea;
			_handCardArea.OnHoverCard += OnHover;
			_handCardArea.OnSelectCard += OnSelect;
			_handCardArea.OnUseCard += OnUse;
			_handCardArea.OnDropCard += OnDrop;
		}
		private void OnDisable()
		{
			_handCardArea.OnHoverCard -= OnHover;
			_handCardArea.OnSelectCard -= OnSelect;
			_handCardArea.OnUseCard -= OnUse;
			_handCardArea.OnDropCard -= OnDrop;
		}
		private void InitElement()
		{
			_handCardArea = PopPanelManager.Instance.GetPopPanel<InRoundCardSystemPopPanel>().CardDeckArea.HandCardArea;
			_bg = transform.Find("CardBG").GetComponent<Image>();
			_cardNameText = transform.Find("CardNameText").GetComponent<TMP_Text>();
			_selectButton = transform.Find("SelectButton").GetComponent<Button>();
			_selectButton.onClick.AddListener(() => { _handCardArea.SelectCard(this); });
		}

	}

}
