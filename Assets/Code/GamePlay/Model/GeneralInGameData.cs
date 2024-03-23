using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game
{
	[Serializable]
	/// <summary>
	/// 通用局内数据
	/// </summary>
	public class GeneralInGameData 
	{
		/// <summary>
		/// 随机种子字符
		/// </summary>
		public string HashSeed;
		/// <summary>
		/// 当前回合数
		/// </summary>
		public int CurrentRound;

		
		private GeneralInGameData()
		{
			CurrentRound = 1;
			HashSeed = DateTime.UtcNow.ToString();
		}
		
		/// <summary>
		/// 初始化一个局内数据
		/// </summary>
		/// <returns></returns>
		public static GeneralInGameData Create()
		{
			GeneralInGameData data = new GeneralInGameData();
			return data;
		}


		/// <summary>
		/// 获得当前回合的HashCode
		/// </summary>
		/// <returns></returns>
		public int GetCurrentHashCode()
		{
			return HashSeed.ToLower().GetHashCode() + GamePlayManager.Instance.GeneralInGameData.CurrentRound;
		}
	}


}
