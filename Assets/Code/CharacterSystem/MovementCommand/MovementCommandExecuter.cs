using Argali.Game.RouletteSystem;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Argali.Game.CharacterSystem
{
	/// <summary>
	/// 移动指令执行器
	/// </summary>
	/// <remarks>用于执行一系列移动指令</remarks>
	public class MovementCommandExecuter
	{
		#region 数据
		
		///// <summary>
		///// 可能不需要？
		///// 当前执行的指令组
		///// </summary>
		//private MovementCommandGroup _currentGroup;

		/// <summary>
		/// 是否正在执行
		/// </summary>
		public bool IsExecuting { get; private set; }
		#endregion

		#region 事件
		///// <summary>
		///// 命令结束事件
		///// </summary>
		//public event System.Action OnCommandGroupFinish;

		#endregion



		#region 方法
		/// <summary>
		/// 执行命令组
		/// </summary>
		/// <param name="characterInRoundData"></param>
		/// <param name="commands"></param>
		public async void RunCommands(List<IMovementCommand> commands)
		{
			if(IsExecuting)
			{
				Debug.LogError("当前正在执行指令组，无法执行新的指令组");
				return;
			}
			MovementCommandGroup group = new MovementCommandGroup();
			group.Commands = commands;
			//_currentGroup = group;
			await ExecuteGroup(group);
			//// 命令执行结束，玩家可以进行下一步操作
			//OnCommandGroupFinish?.Invoke();
		}


		#endregion
		/// <summary>
		/// 执行移动命令,返回是否需要打断后续事件
		/// </summary>
		/// <param name="data"></param>
		/// <param name="movementCommand"></param>
		/// <returns></returns>
		private async UniTask<bool> CommandExecution(CharacterInRoundData data, IMovementCommand movementCommand)
		{
			CharacterInRoundData beforeData = data;
			CharacterInRoundData afterData = new(data);
			movementCommand.Execute(ref afterData);
			// TODO: 更新数据
			CharacterSystemController.Instance.PlayerRoundController.PlayerRoundData = afterData;
			// 检查是否需要打断后续事件
			bool isCancel = default;

			// TODO: 执行动效等
			int step = RouletteSystemController.Instance.Roulette.CalculateStep(beforeData.CurrentIndex,afterData.CurrentIndex,beforeData.CurrentRoundCount,afterData.CurrentRoundCount);
			await RouletteSystemController.Instance.RouletteObject.Move(step);
			//await UniTask.Yield();
			return isCancel;
		}
		/// <summary>
		/// 执行指令组
		/// </summary>
		/// <param name="data"></param>
		/// <param name="group"></param>
		/// <returns></returns>
		private async UniTask ExecuteGroup(MovementCommandGroup group)
		{
			IsExecuting = true;
			bool isCancel = false;
			foreach (var command in group.Commands)
			{
				// 检测是否有取消指令
				// 某些指令会中断后续指令
				isCancel = await CommandExecution(CharacterSystemController.Instance.PlayerRoundController.PlayerRoundData, command);
			}
			if (isCancel)
			{
				// TODO: 执行中断后的事件
			}
			IsExecuting = false;
		}

	}


	/// <summary>
	/// 移动命令组
	/// </summary>
	/// <remarks>执行器按照指令组为单位，进行一次完整执行</remarks>
	public struct MovementCommandGroup
	{
		/// <summary>
		/// 移动指令集
		/// </summary>
		public List<IMovementCommand> Commands;
	}
}
