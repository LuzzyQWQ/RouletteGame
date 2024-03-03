using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

namespace Argali.Game.CardSystem.Util
{
	public static class CardShuffle
	{
		/// <summary>
		/// 根据随机种子洗牌
		/// </summary>
		/// <param name="cards"></param>
		/// <param name="randomSeed"></param>
		public static void ShuffleCards(ref List<ICard> cards, int randomSeed)
		{
			Random.InitState(randomSeed);
			for (int i = 0; i < cards.Count; i++)
			{
				ICard temp = cards[i];
				int randomIndex = Random.Range(i,cards.Count);
				cards[i] = cards[randomIndex];
				cards[randomIndex] = temp;
			}
		}

	}
}
