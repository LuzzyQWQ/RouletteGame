using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CharacterSystem
{

	/// <summary>
	/// 敌人回合控制器
	/// </summary>
	public class EnemyRoundController
	{
		#region 属性
		/// <summary>
		/// 敌人回合内数据
		/// </summary>
		public CharacterInRoundData EnemyRoundData;
		#endregion

		#region 构造
		private EnemyRoundController(string enemyName)
		{
			// 根据敌人名字初始化敌人数据
			EnemyRoundData = EnemyGrowFactor.CreateEnemyRoundData(CharacterSystemConfigLoader.Instance.GetEnemyInfo(enemyName), GamePlayManager.Instance.GeneralInGameData.CurrentRound);
		}
		
		/// <summary>
		/// 创建敌人回合控制器
		/// </summary>
		/// <returns></returns>
		public static async UniTask<EnemyRoundController> Create(string enemyName = "")
		{
			EnemyRoundController instance = new EnemyRoundController(enemyName);
			await UniTask.Yield();
			return instance;
		}
		#endregion

	}

}
