using Argali.Util.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.RouletteSystem
{
	/// <summary>
	/// 插槽工厂
	/// </summary>
	public class SlotFactory 
	{
		public static SlotBase CreateInstance(string className, string slotName)
		{
			Type type = ReflectionUtility.GetTypeByName(className);
			if (type == null)
			{
				Debug.LogError("未找到插槽类：" + className);
				return null;
			}
			try
			{
				SlotBase slotItem = (SlotBase)Activator.CreateInstance(type, slotName);
				return slotItem;
			}
			catch (Exception e)
			{
				Debug.LogError("创建插槽失败：" + e.Message);
				return null;
			}
		}
	}

}
