using Argali.Game.RouletteSystem;

namespace Argali.Game.CharacterSystem
{
	/// <summary>
	/// 等待命令
	/// </summary>
	public class StayCommand : IMovementCommand
	{
		public void Execute(ref CharacterInRoundData characterData)
		{
			var roulette = RouletteSystemController.Instance.Roulette;
			roulette.GetSlot(characterData.CurrentIndex).Trigger(ref characterData, SlotItemTriggerType.Stay);
		}
	}
}
