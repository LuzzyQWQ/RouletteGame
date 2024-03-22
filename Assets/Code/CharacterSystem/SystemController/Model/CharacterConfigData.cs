using Argali.Module.DataBase.ConfigLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CharacterSystem
{
	[Serializable]
	public struct CharacterConfigData
	{
		
		/// <summary>
		/// 初始攻击力
		/// </summary>
		public int InitAttack;
	}
	/// <summary>
	/// 角色配置信息
	/// </summary>
	/// <remarks>用于存储角色初始数据等</remarks>
	[Serializable]
	public struct CharacterInfo : IConfigInfo
	{
		/// <summary>
		/// 角色ID
		/// </summary>
		/// <remarks>用于唯一索引</remarks>
		public string CharacterName;

		/// <summary>
		/// 初始属性
		/// </summary>
		public CharacterConfigData BaseData;

		public string GetGUID()
		{
			return CharacterName;
		}
	}
}
