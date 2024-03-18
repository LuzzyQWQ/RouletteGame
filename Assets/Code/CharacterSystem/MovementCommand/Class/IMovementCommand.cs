using Argali.Game.RouletteSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CharacterSystem
{
	/// <summary>
	/// 移动命令类型
	/// </summary>
	public enum MovementCommandType
	{
		MoveForward,
		TurnBack,
		Stay
	}

	/// <summary>
	/// 移动命令接口
	/// </summary>
	public interface IMovementCommand
	{
		/// <summary>
		/// 执行移动命令
		/// </summary>
		/// <param name="characterData"></param>
		public void Execute(ref CharacterInRoundData characterData);
	}
}
