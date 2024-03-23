using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CardSystem
{
	/// <summary>
	/// 卡牌系统局内数据
	/// </summary>
	public class CardSystemInGameData
	{
		#region 数据

		/// <summary>
		/// 模式信息
		/// </summary>
		public CardSystemModeInfo ModeInfo;


		/// <summary>
		/// 额外手牌数量
		/// </summary>
		public int ExtraHandCount;

		/// <summary>
		/// 额外弃牌数量
		/// </summary>
		public int ExtraDropCount;
		#endregion
		
		public int GetCurrentHandCount()
		{
			return ModeInfo.MaxHandCount + ExtraHandCount;
		}

		public int GetCurrentDropCount()
		{
			return ModeInfo.DropCount + ExtraDropCount;
		}


		public CardSystemInGameData(CardSystemModeInfo modeInfo)
		{
			ModeInfo = modeInfo;
			ExtraHandCount = 0;
			ExtraDropCount = 0;
		}
	}
}

