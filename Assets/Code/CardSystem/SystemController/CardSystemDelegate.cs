using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CardSystem
{
	/// <summary>
	/// 数量变化委托
	/// </summary>
	/// <param name="count"></param>
	public delegate void ValueChangeDelegated(int count);
	/// <summary>
	/// 卡片改变委托
	/// </summary>
	/// <param name="card"></param>
	public delegate void CardChangeDelegated(ICard card);
}
