using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CardSystem
{
	/// <summary>
	/// 初始牌组的组成配置
	/// </summary>
	[CreateAssetMenu(fileName ="Initial CardDeck Config",menuName ="Card System/Initial CardDeck Config",order = 2)]
	public class InitialCardDeckConfig :ScriptableObject
	{
		public List<InitialCardDeckData> data;
	}

	[Serializable]
	public struct InitialCardDeckData
	{
		public string CardDeckName;
		public List<string> CardsGUIDs;
	}
}
