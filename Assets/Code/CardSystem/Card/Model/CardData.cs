using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CardSystem
{
	/// <summary>
	/// 卡片数据层
	/// </summary>
	[Serializable]
	public class CardData 
	{
		public string CardName;
	}
	[Serializable]
	public struct CardInfo
	{
		public int index;
		public CardData CardData;
		public string CardClassName;
	}
}
