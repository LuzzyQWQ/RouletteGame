using Argali.Module.DataBase.ConfigLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.RouletteSystem
{
	/// <summary>
	/// 插槽物品类型
	/// </summary>
	public enum SlotItemTriggerType
	{
		Enter,  // 进入触发
		Stay,   // 停留触发
	}
	/// <summary>
	/// 插槽物品数据类型
	/// </summary>
	[Serializable]
	public class SlotItemData
	{
		/// <summary>
		/// 插槽物品名字
		/// </summary>
		public string SlotItemName;

		/// <summary>
		/// 插槽物品触发类型
		/// </summary>
		public SlotItemTriggerType TriggerType;
	}
	/// <summary>
	/// 插槽物品信息
	/// </summary>
	[Serializable]
	public class SlotItemInfo : IConfigInfo
	{
		public int Index;
		public SlotItemData SlotItemData;
		/// <summary>
		/// 插槽物品 类名
		/// </summary>
		public string ClassName;

		public string GetGUID()
		{
			return SlotItemData.SlotItemName;
		}
	}
} 
