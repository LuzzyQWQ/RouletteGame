using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CharacterSystem
{
	/// <summary>
	/// 敌人数据成长参数
	/// </summary>
	/// <remarks>敌人随着回合数增长的参数</remarks>
	public class EnemyGrowFactor
	{
		private const float baseRoundFacter = 1.5f;

		/// <summary>
		/// 回合所对应得战力乘数
		/// </summary>
		/// <param name="round"></param>
		/// <returns></returns>
		private static float RoundFacter(int round)
		{
			return round == 1 ? 1 : baseRoundFacter * (round - 1);
		}

		/// <summary>
		/// 生成当前敌人的回合数据
		/// </summary>
		/// <param name="enemyInfo">敌人配置数据</param>
		/// <param name="round">当前回合</param>
		/// <returns></returns>
		public static CharacterInRoundData CreateEnemyRoundData(CharacterInfo enemyInfo,int round)
		{
			CharacterInRoundData enemyData = new CharacterInRoundData(enemyInfo);
			enemyData.Attack *= RoundFacter(round);
			return enemyData;
		}
	}

}
