using Argali.Module.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CharacterSystem
{
	/// <summary>
	/// 角色控制器
	/// </summary>
	public class CharacterSystemController :Singleton<CharacterSystemController> 
	{
		#region 属性
		/// <summary>
		/// 角色局内属性
		/// </summary>
		public CharacterInGameData InGameData { get; private set; }

		#endregion

		#region 子控制器
		/// <summary>
		/// 回合控制器
		/// </summary>
		public CharacterSystemRoundController RoundController { get; private set; }

		#endregion

		/// <summary>
		/// 创建一个回合
		/// </summary>
		public void CreateRound(System.Action onFinish)
		{
			RoundController = new CharacterSystemRoundController(onFinish);
		}

		/// <summary>
		/// 载入一个回合
		/// </summary>
		public void LoadRound()
		{
			throw new NotImplementedException();
		}
		/// <summary>
		/// 结束回合
		/// </summary>
		public void EndRound()
		{
			throw new NotImplementedException();
		}
	}

}
