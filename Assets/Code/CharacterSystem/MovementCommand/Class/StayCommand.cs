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
			characterData = roulette.GetSlot(characterData.CurrentIndex).Trigger(characterData, SlotItemTriggerType.Stay);
		}
	}
}
