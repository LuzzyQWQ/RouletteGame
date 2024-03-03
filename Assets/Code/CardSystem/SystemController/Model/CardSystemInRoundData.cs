using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CardSystem
{
	/// <summary>
	/// 卡牌系统 单回合内数据
	/// </summary>
	public class CardSystemInRoundData 
	{
		/// <summary>
		/// 剩余弃牌次数
		/// </summary>
		public int RestDropCount {  get; private set; }

		public CardSystemInRoundData(int dropCount) 
		{ 
			RestDropCount = dropCount;
		}
		/// <summary>
		/// 增加丢弃的次数
		/// </summary>
		public void AddDropCount()
		{
			RestDropCount++;
		}
		/// <summary>
		/// 使用丢弃次数
		/// </summary>
		public void UseDropCount()
		{
			if (RestDropCount == 0)
			{
				Debug.LogError("在弃牌次数为 0 时，使用了弃牌。");
				return;
			}
			RestDropCount--;
		}

	}

}
