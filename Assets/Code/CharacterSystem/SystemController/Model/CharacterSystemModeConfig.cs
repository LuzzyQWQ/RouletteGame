using Argali.Module.DataBase.ConfigLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CharacterSystem
{
	[CreateAssetMenu(fileName = "Character System Mode Config", menuName = "Character System/Character System Mode Config")]
	public class CharacterSystemModeConfig : ScriptableObject
	{
		public List<CharacterSystemModeInfo> data;
	}

	[Serializable]
	/// <summary>
	/// 角色系统模式信息
	/// </summary>
	public struct CharacterSystemModeInfo : IConfigInfo
	{
		/// <summary>
		/// 模式名称
		/// </summary>
		public string ModeName;
		/// <summary>
		/// 敌人配置文件路径
		/// </summary>
		public string EnemyConfigPath;
		public string GetGUID()
		{
			return ModeName;
		}
	}
}
