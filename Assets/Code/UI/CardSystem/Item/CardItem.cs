using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Argali.Game.CardSystem.UI
{

	public class CardItem : MonoBehaviour
	{
		#region Element
		private TMP_Text _cardNameText;
		#endregion

		#region Property
		/// <summary>
		/// 卡片数据
		/// </summary>
		public CardBase Card;
		#endregion

		public void InitCardItem(CardBase card)
		{
			Card = card;
			_cardNameText.text = card.GetCardName();
		}
		public void OnSelect()
		{
			Card.SelectCard();
		}

		public void OnUse(params object[] args)
		{
			Card.UseCard();
		}
		
		public void OnDeSelect()
		{
			Card.UnselectCard();
		}
		
		public void OnHover()
		{
			// TODO
			// 悬浮时显示卡片信息
		}


		private void Awake()
		{
			InitElement();
		}
		private void InitElement()
		{
			_cardNameText = transform.Find("CardNameText").GetComponent<TMP_Text>();
		}
		
	}

}
