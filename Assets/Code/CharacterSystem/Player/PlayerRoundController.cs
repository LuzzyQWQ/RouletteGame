using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

namespace Argali.Game.CharacterSystem
{
	/// <summary>
	/// 角色系统 回合内控制器
	/// </summary>
	/// <remarks>用于角色在单回合内的逻辑控制</remarks>
	public class PlayerRoundController
	{
		#region 数据
		/// <summary>
		/// 回合内数据
		/// </summary>
		public CharacterInRoundData PlayerRoundData;

		/// <summary>
		/// 角色移动指令执行器
		/// </summary>
		public MovementCommandExecuter Commander;
		#endregion

		#region 事件
		#endregion

		#region  初始化
		/// <summary>
		/// 创建角色回合控制器
		/// </summary>
		/// <remarks>使用保存的数据</remarks>
		/// <param name="loadData"></param>
		/// <param name="onFinish"></param>
		private PlayerRoundController(CharacterInRoundData loadData) : this()
		{
			PlayerRoundData = loadData;
		}

		private PlayerRoundController()
		{
			PlayerRoundData = new CharacterInRoundData(CharacterSystemController.Instance.PlayerInGameData);
			Commander = new MovementCommandExecuter();
		}

		/// <summary>
		/// 创建角色回合控制器
		/// </summary>
		/// <param name="onFinish"></param>
		public static async UniTask<PlayerRoundController> Create()
		{
			PlayerRoundController instance = new PlayerRoundController();
			await UniTask.Yield();
			return instance;
		}
		#endregion
		
		/// <summary>
		/// 开始回合
		/// </summary>
		public void StartRound()
		{

		}
	}

}
