using Argali.Util.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CardSystem
{
	
	/// <summary>
	/// 卡片工厂，通过反射创建相应卡片类
	/// </summary>
	public class CardFactory
	{
		/// <summary>
		/// 根据类名创建卡片
		/// </summary>
		/// <param name="className"></param>
		/// <param name="cardName"></param>
		/// <returns></returns>
		public static CardBase CreateCard(string className,string cardName)
		{
			//Type type = Type.GetType(className);
			Type type = ReflectionUtility.GetTypeByName(className);
			if (type == null)
			{
				Debug.LogError("未找到卡片类：" + className);
				return null;
			}
			try
			{
				CardBase card = (CardBase)Activator.CreateInstance(type);
				card.SetCardName(cardName);	
				return card;
			}
			catch (Exception e)
			{
				Debug.LogError("创建卡片失败：" + e.Message);
				return null;
			}
		}
	}

}
