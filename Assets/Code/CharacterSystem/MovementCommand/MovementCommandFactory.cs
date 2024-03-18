using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CharacterSystem
{

	/// <summary>
	/// 移动命令工厂
	/// </summary>
	/// <remarks>用于创建各种移动命令</remarks>
	public class MovementCommandFactory 
	{
		public static IMovementCommand CreateCommand(MovementCommandType type)
		{
			switch (type)
			{
				case MovementCommandType.MoveForward:
					return new MoveForwardCommand();
				case MovementCommandType.TurnBack:
					return new TurnBackCommand();
				case MovementCommandType.Stay:
					return new StayCommand();
				default:
					return new EmptyMovementCommand();
			}
		}
	}

}
