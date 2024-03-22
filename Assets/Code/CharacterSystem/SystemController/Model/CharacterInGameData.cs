using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CharacterSystem
{
	/// <summary>
	/// 角色在整局游戏中的数据
	/// </summary>
	public class CharacterInGameData 
	{
		#region 移动相关
		/// <summary>
		/// 当前朝向
		/// </summary>
		/// <remarks>true 为朝前， false 为朝后</remarks>
		public bool CurrentForward;

		/// <summary>
		/// 当前所在插槽下标
		/// </summary>
		public int CurrentIndex;
		#endregion


		#region 战斗相关 
		/// <summary>
		/// 基础攻击力
		/// </summary>
		public float BaseAttack;

		#endregion


		#region 构造函数
		public CharacterInGameData()
		{
		}
		public CharacterInGameData(CharacterInGameData data)
		{
			CurrentForward = data.CurrentForward;
			CurrentIndex = data.CurrentIndex;
			BaseAttack = data.BaseAttack;
		}
		/// <summary>
		/// 使用配置数据初始化
		/// </summary>
		/// <param name="data"></param>
		public CharacterInGameData(CharacterConfigData data)
		{
			BaseAttack = data.InitAttack;
			CurrentForward = true;
			CurrentIndex = 0;
		}
		#endregion

	}
}
