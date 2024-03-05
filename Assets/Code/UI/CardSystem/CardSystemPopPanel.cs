using Argali.UI.Pop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CardSystem.UI
{

	public class CardSystemPopPanel :BasePopPanel 
	{
		#region Element
		[SerializeField]
		private GameObject _cardItemPrefab;

		private RectTransform _deckArea;
		#endregion


		public void ClearDeckArea()
		{
			for(int i =0;i< _deckArea.childCount;i++)
			{
				Destroy(_deckArea.GetChild(i));
			}
		}
		public void SpawnCard(ICard card)
		{
			CardItem item = Instantiate(_cardItemPrefab, _deckArea).GetComponent<CardItem>();
			item.InitCardItem(card as CardBase);
		}
		
		protected override void Awake()
		{
			base.Awake();
			InitElement();
		}
		private void InitElement()
		{
			_deckArea = transform.Find("Content/DeckArea").GetComponent<RectTransform>();
		}

	}

}
