using Argali.Util.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.RouletteSystem
{

	/// <summary>
	/// 转盘工厂
	/// </summary>
	public class RouletteFactory 
	{
		/// <summary>
		/// 根据类名创建转盘
		/// </summary>
		/// <param name="className"></param>
		/// <param name="cardName"></param>
		/// <returns></returns>
		public static RouletteBase CreateRoulette(string className, string cardName)
		{
			Type type = ReflectionUtility.GetTypeByName(className);
			if (type == null)
			{
				Debug.LogError("未找到转盘类：" + className);
				return null;
			}
			try
			{
				RouletteBase roulette = (RouletteBase)Activator.CreateInstance(type);
				return roulette;
			}
			catch (Exception e)
			{
				Debug.LogError("创建转盘失败：" + e.Message);
				return null;
			}
		}
	}

}
