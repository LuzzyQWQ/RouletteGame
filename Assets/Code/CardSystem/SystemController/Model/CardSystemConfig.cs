using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CardSystem
{
	/// <summary>
	/// 卡牌系统初始配置
	/// </summary>
	public class CardSystemConfig : ScriptableObject
	{
		[Header("预设卡组名")]
		public string PreDefinedCardDeckName;

		[Header("最大手牌数")]
		public int MaxHandCount;
		[Header("弃牌数量")]
		public int DropCount;
	}
	
}
