using Argali.Module.DataBase.ConfigLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.RouletteSystem
{
	[Serializable]
	/// <summary>
	/// 插槽数据
	/// </summary>
	public class SlotData 
	{
		public string SlotName;
	}
	/// <summary>
	/// 插槽信息
	/// </summary>
	[Serializable]
	public class SlotInfo : IConfigInfo
	{
		public int Index;
		public SlotData SlotData;
		public string ClassName;

		public string GetGUID()
		{
			return SlotData.SlotName;
		}
	}
}
