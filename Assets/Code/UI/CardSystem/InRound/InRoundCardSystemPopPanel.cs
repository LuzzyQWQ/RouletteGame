using Argali.UI.Pop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CardSystem.UI
{

	public class InRoundCardSystemPopPanel :BasePopPanel 
	{
		#region Element
		public InRoundCardDeckArea CardDeckArea { get; private set; }
		#endregion

		public void Init(CardSystemRoundController cardSystemRoundController)
		{
			if (cardSystemRoundController == null)
			{
				Debug.LogError("初始化卡牌战斗UI失败");
				return;
			}
			CardDeckArea.Init(CardSystemController.Instance.CurrentRoundController.DrawInitCards);
		}


		protected override void Awake()
		{
			base.Awake();
			InitElement();
		}
		private void InitElement()
		{
			CardDeckArea = transform.Find("Content/CardDeckArea").GetComponent<InRoundCardDeckArea>();
		}

	}

}
