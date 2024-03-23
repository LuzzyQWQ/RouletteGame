using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Argali.Game.CardSystem.UI
{
	/// <summary>
	/// 局内卡组信息 UI
	/// </summary>
	public class InRoundCardDeckInfoArea : MonoBehaviour
	{
		#region Element
		private TMP_Text _drawCountText;
		private TMP_Text _usedCountText;
		private TMP_Text _restDropCountText;
		#endregion


		private void UpdateDrawCount(int count)
		{
			_drawCountText.text = "Draw Deck: " + count.ToString();
		}

		private void UpdateUsedCount(int count)
		{
			_usedCountText.text = "Used Deck: " + count.ToString();
		}

		private void UpdateRestDropCount(int count)
		{
			_restDropCountText.text = "Rest Drop Count: " + count.ToString();
		}

		private void OnEnable()
		{
			if (CardSystemController.Instance != null)
			{
				if (CardSystemController.Instance.UserCardDeck != null)
				{
					CardSystemController.Instance.UserCardDeck.OnDrawCardsCountChange += UpdateDrawCount;
					UpdateDrawCount(CardSystemController.Instance.UserCardDeck._drawCardsList.Count);
					CardSystemController.Instance.UserCardDeck.OnUsedCardsCountChange += UpdateUsedCount;
					UpdateUsedCount(CardSystemController.Instance.UserCardDeck._usedCardsList.Count);
				}
				if (CardSystemController.Instance.RoundController != null)
				{
					CardSystemController.Instance.RoundController.OnRestDropCountChanged += UpdateRestDropCount;
					UpdateRestDropCount(CardSystemController.Instance.RoundController.InRoundData.RestDropCount);
				}
			}
		}

		private void OnDisable()
		{
			if (CardSystemController.Instance != null)
			{
				if (CardSystemController.Instance.UserCardDeck != null)
				{
					CardSystemController.Instance.UserCardDeck.OnDrawCardsCountChange -= UpdateDrawCount;
					CardSystemController.Instance.UserCardDeck.OnUsedCardsCountChange -= UpdateUsedCount;
				}
				if (CardSystemController.Instance.RoundController != null)
				{
					CardSystemController.Instance.RoundController.OnRestDropCountChanged -= UpdateRestDropCount;
				}
			}
		}
		private void Awake()
		{
			InitElement();
		}

		private void InitElement()
		{
			var infoContainer = transform.Find("InfoContainer");
			_drawCountText = infoContainer.Find("DrawCountText").GetComponent<TMP_Text>();
			_usedCountText = infoContainer.Find("UsedCountText").GetComponent<TMP_Text>();
			_restDropCountText = infoContainer.Find("RestDropCountText").GetComponent<TMP_Text>();
		}
	}

}
