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
		
		#endregion

		#region 构造
		private EnemyRoundController()
		{
			
		}
		
		/// <summary>
		/// 创建敌人回合控制器
		/// </summary>
		/// <returns></returns>
		public static async UniTask<EnemyRoundController> Create()
		{
			EnemyRoundController instance = new EnemyRoundController();
			await UniTask.Yield();
			return instance;
		}
		#endregion



		#region 结算

		#endregion
	}

}
