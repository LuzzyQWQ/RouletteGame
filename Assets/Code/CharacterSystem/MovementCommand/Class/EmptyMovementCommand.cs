namespace Argali.Game.CharacterSystem
{
	/// <summary>
	/// 空移动命令
	/// </summary>
	public class EmptyMovementCommand : IMovementCommand
	{
		public void Execute(ref CharacterInRoundData characterData)
		{
			// Do nothing
		}
	}
}
