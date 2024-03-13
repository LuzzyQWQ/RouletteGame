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


		public CharacterInGameData()
		{
			CurrentIndex = 0;
			CurrentForward = true;
			BaseAttack = 5;
		}


	}
}
