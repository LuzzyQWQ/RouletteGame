using Argali.Game.CardSystem.UI;
using Argali.Game.CharacterSystem;
using Argali.UI.Pop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CardSystem
{

	public class MoveCard : CardBase
	{

		public override void SelectCard()
		{
			Debug.Log("选择了卡片： " + typeof(MoveCard).ToString() + " " + this._cardName);
		}



		public override void UnselectCard()
		{
			Debug.Log("取消选择了卡片： " + typeof(MoveCard).ToString() + " " + this._cardName);
		}

		public override void UseCard(params object[] args)
		{
			// 选择的第一个参数为前进步数
			int step = 0;
			if (args[0]!= null && int.TryParse(args[0].ToString(),out step))
			{
				Debug.Log("使用前进卡片: " + GetCardName()+" 前进 "+ step.ToString() + "步");
				// 指令内容
				List<IMovementCommand> commands = new List<IMovementCommand>();
				for(int i = 0; i < step; i++)
				{
					commands.Add(MovementCommandFactory.CreateCommand(MovementCommandType.MoveForward));
				}
				commands.Add(MovementCommandFactory.CreateCommand(MovementCommandType.Stay));
				// 执行移动指令
				CharacterSystemController.Instance.PlayerRoundController.Commander.RunCommands(commands);
			}
		}
		public override void ShowArgsPanel()
		{
			var panel = PopPanelManager.Instance.OpenPopPanel<InRoundCardSelectPopPanel>();
			panel.UpdateUI(this);
		}
	}

}
