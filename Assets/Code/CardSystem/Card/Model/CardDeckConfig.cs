using Argali.Module.DataBase.ConfigLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CardSystem
{
	/// <summary>
	/// 初始牌组的组成配置
	/// </summary>
	[CreateAssetMenu(fileName ="Card Deck Config",menuName ="Card System/Card Deck Config",order = 2)]
	public class CardDeckConfig :ScriptableObject
	{
		public List<CardDeckInfo> data;
	}

	[Serializable]
	public class CardDeckInfo: IConfigInfo
	{
		public string CardDeckName;
		public List<string> CardsGUIDs;
		public string GetGUID()
		{
			return CardDeckName;
		}
	}
}
