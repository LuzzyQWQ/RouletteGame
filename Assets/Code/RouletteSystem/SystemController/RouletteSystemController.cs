using Argali.Module.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Argali.Game.RouletteSystem
{

	/// <summary>
	/// 转盘系统控制器
	/// </summary>
	public class RouletteSystemController : Singleton<RouletteSystemController> 
	{
		#region 属性
		/// <summary>
		/// 转盘
		/// </summary>
		public RouletteBase Roulette;

		#endregion

		#region 方法

		#region 初始化
		/// <summary>
		/// 初始化系统
		/// </summary>
		public void InitSystem()
		{
			// 给一个新的 转盘类
		}
		#endregion

		#endregion


	}

}
