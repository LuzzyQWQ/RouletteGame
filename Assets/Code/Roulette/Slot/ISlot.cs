using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game
{
	/// <summary>
	/// 轮盘插槽类
	/// </summary>
	public interface ISlot
	{
		public bool IsAvailable();

		public bool IsDestoryed();

		public void Pass();

		public void Stay();
	}
}
