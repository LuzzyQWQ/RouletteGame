using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CharacterSystem
{
	/// <summary>
	/// 角色系统 回合内控制器
	/// </summary>
	/// <remarks>用于角色在单回合内的逻辑控制</remarks>
	public class CharacterSystemRoundController
	{
		#region 数据
		/// <summary>
		/// 回合内数据
		/// </summary>
		public CharacterInRoundData RoundData;
		#endregion

		#region 事件
		private System.Action _onFinishLoad;
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
		public CharacterSystemRoundController(CharacterInRoundData loadData, System.Action onFinish):this(onFinish)
		{
			RoundData = loadData;
		}
		
		/// <summary>
		/// 创建角色回合控制器
		/// </summary>
		/// <param name="onFinish"></param>
		public CharacterSystemRoundController(System.Action onFinish)
		{
			RoundData = new CharacterInRoundData(CharacterSystemController.Instance.InGameData);
			_onFinishLoad = onFinish;

		}
		#endregion

		#region 控制
		/// <summary>
		/// 角色转向
		/// </summary>
		public void TurnBack()
		{
			RoundData.CurrentForward = !RoundData.CurrentForward;
		}

		/// <summary>
		/// 向前移动
		/// </summary>
		public void MoveForward()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 停留
		/// </summary>
		public void Stay()
		{
			throw new NotImplementedException();
		}
		#endregion



	}

}
