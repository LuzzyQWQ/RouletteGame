using Argali.Module.DataBase.ConfigLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CharacterSystem
{
	/// <summary>
	/// 角色基础属性配置
	/// </summary>
	[CreateAssetMenu(fileName = "Character Map Config", menuName = "Character System/Character Map Config",order = 2)]
	public class CharacterMapConfig : ScriptableObject 
	{
		public List<CharacterInfo> data;
	}


}
