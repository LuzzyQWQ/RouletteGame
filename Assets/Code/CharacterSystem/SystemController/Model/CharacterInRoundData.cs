using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CharacterSystem
{
	/// <summary>
	/// 角色在单回合的数据
	/// </summary>
	public class CharacterInRoundData
	{
		#region 战斗相关
		/// <summary>
		/// 攻击力
		/// </summary>
		public float Attack;
		#endregion

		#region 移动相关

		/// <summary>
		/// 当前插槽下标
		/// </summary>
		public int CurrentIndex;
		/// <summary>
		/// 当前朝向
		/// </summary>
		public bool CurrentForward;
		#endregion

		/// <summary>
		/// 通过局内数据生成初始回合数据
		/// </summary>
		/// <param name="data"></param>
		public CharacterInRoundData(CharacterInGameData data)
		{
			Attack = data.BaseAttack;
			CurrentIndex = data.CurrentIndex;
			CurrentForward = data.CurrentForward;
		}
		
		/// <summary>
		/// 拷贝数据
		/// </summary>
		/// <param name="data"></param>
		public CharacterInRoundData(CharacterInRoundData data)
		{
			Attack = data.Attack;
			CurrentIndex = data.CurrentIndex;
			CurrentForward = data.CurrentForward;
		}
	}

}
