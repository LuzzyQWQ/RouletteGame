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

		/// <summary>
		/// 轮盘系统局内数据
		/// </summary>
		public RouletteSystemInGameData InGameData;

		#endregion

		#region 方法

		#region 初始化
		/// <summary>
		/// 初始化系统，每次开始一局游戏时，进行初始化。
		/// </summary>
		/// <param name="rouletteName"></param>
		/// <param name="modeInfo"></param>
		public void InitSystem(string rouletteName, RouletteSystemModeInfo modeInfo)
		{
			// 初始化局内数据
			InGameData = new RouletteSystemInGameData();
			// 给一个新的 转盘类
			Roulette = RouletteSystemConfigLoader.Instance.SpawnRoulette(rouletteName);
		}
		#endregion

		#endregion


	}

}
