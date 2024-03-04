using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CardSystem
{
	/// <summary>
	/// 所有卡片信息配置文件
	/// </summary>
	[CreateAssetMenu(fileName ="CardMap Config",menuName ="Card System/CardMap Config",order = 1)]
	public class CardMapConfig : ScriptableObject 
	{
		public List<CardInfo> data;
	}
}
