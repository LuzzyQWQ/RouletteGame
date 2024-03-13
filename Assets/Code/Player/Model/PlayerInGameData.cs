using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.Player
{
	/// <summary>
	/// 角色在游戏中的数据
	/// </summary>
	public class PlayerInGameData 
	{
		/// <summary>
		/// 基础攻击力
		/// </summary>
		public float BaseAttack;

		/// <summary>
		/// 当前朝向
		/// </summary>
		/// <remarks>true 为朝前， false 为朝后</remarks>
		public bool CurrentForward;

	}
}
