using Argali.Game.CardSystem.UI;
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
			Debug.Log("使用前进卡片: " + GetCardName());
		}
		public override void ShowArgsPanel()
		{
			var panel = PopPanelManager.Instance.OpenPopPanel<InRoundCardSelectPopPanel>();
			panel.UpdateUI(this);
		}
	}

}
