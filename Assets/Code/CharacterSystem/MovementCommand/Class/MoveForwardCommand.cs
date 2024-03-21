using Argali.Game.RouletteSystem;

namespace Argali.Game.CharacterSystem
{
	/// <summary>
	/// 向前移动命令
	/// </summary>
	public class MoveForwardCommand : IMovementCommand
	{
		public void Execute(ref CharacterInRoundData characterData)
		{
			var roulette = RouletteSystemController.Instance.Roulette;
			int nextIndex = roulette.GetNextIndex(characterData.CurrentIndex,characterData.CurrentForward);
			characterData.CurrentIndex = nextIndex;
			// 触发下一个下标的事件
			characterData = roulette.GetSlot(nextIndex).Trigger(characterData, SlotItemTriggerType.Enter);
		}
	}
}
