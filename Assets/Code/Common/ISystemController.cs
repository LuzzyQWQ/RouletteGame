using Argali.Module.Singleton;
using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game
{
	
	/// <summary>
	/// 系统控制器接口
	/// </summary>
	/// <remarks>各个系统的总控制器</remarks>
	public interface ISystemController 
	{
		/// <summary>
		/// 创建回合
		/// </summary>
		/// <remarks>创建相应的回合控制器</remarks>
		public UniTask CreateRound();

		/// <summary>
		/// 载入回合
		/// </summary>
		/// <returns></returns>
		/// <remarks>>创建相应的回合控制器</remarks>
		public UniTask LoadRound();


		/// <summary>
		/// 结束回合，销毁回合控制器
		/// </summary>
		public void EndRound();
	}

}
