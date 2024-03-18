namespace Argali.Game.CharacterSystem
{
	/// <summary>
	/// 转向命令
	/// </summary>
	public class TurnBackCommand : IMovementCommand
	{
		public void Execute(ref CharacterInRoundData characterData)
		{
			characterData.CurrentForward = !characterData.CurrentForward;
		}
	}
}
