using Argali.Module.Singleton;
using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CharacterSystem
{
	/// <summary>
	/// 角色控制器
	/// </summary>
	public class CharacterSystemController :Singleton<CharacterSystemController> , ISystemController
	{

		#region 属性
		/// <summary>
		/// 玩家角色局内属性
		/// </summary>
		public CharacterInGameData PlayerInGameData { get; private set; }

		#endregion

		#region 子控制器
		/// <summary>
		/// 角色回合控制器
		/// </summary>
		public PlayerRoundController PlayerRoundController { get; private set; }
		
		/// <summary>
		/// 敌人回合控制器
		/// </summary>
		public EnemyRoundController EnemyRoundController { get; private set; }
		#endregion

		#region 初始化
		/// <summary>
		/// 初始化系统
		/// </summary>
		/// <param name="playerName"></param>
		public void InitSystem(string playerName)
		{
			// 初始化玩家角色数据
			PlayerInGameData = CharacterSystemConfigLoader.Instance.GeneratePlayerData(playerName);
		}

		#endregion 

		#region 回合相关
		/// <summary>
		/// 创建一个回合
		/// </summary>
		public async UniTask CreateRound()
		{
			var playerTask = UniTask.Create(async () =>
			{
				PlayerRoundController = await PlayerRoundController.Create();
			});
			var enemyTask = UniTask.Create(async () =>
			{
				EnemyRoundController = await EnemyRoundController.Create("base_enemy");
			});
			await UniTask.WhenAll(playerTask, enemyTask);
		}

		/// <summary>
		/// 载入一个回合
		/// </summary>
		public async UniTask LoadRound()
		{
			await UniTask.Yield();
			throw new NotImplementedException();
		}
		/// <summary>
		/// 结束回合
		/// </summary>
		public void EndRound()
		{
			// 清空回合控制器
			PlayerRoundController = null;
			EnemyRoundController = null;
		}
		#endregion
	}

}
