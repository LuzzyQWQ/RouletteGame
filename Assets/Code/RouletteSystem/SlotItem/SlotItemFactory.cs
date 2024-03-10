using Argali.Util.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.RouletteSystem
{
	/// <summary>
	/// 插槽物品工厂
	/// </summary>
	public class SlotItemFactory 
	{
		public static SlotItemBase CreateInstance(string className,string slotItemName)
		{
			Type type = ReflectionUtility.GetTypeByName(className);
			if (type == null)
			{
				Debug.LogError("未找到插槽物品类：" + className);
				return null;
			}
			try
			{
				SlotItemBase slotItem = (SlotItemBase)Activator.CreateInstance(type, slotItemName);
				return slotItem;
			}
			catch (Exception e)
			{
				Debug.LogError("创建插槽物品失败：" + e.Message);
				return null;
			}
		}
	}

}
