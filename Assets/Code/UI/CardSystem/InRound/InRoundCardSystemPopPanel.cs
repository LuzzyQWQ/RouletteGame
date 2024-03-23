using Argali.UI.Pop;
using Cysharp.Threading.Tasks;
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

		public async UniTaskVoid Init(CardSystemRoundController cardSystemRoundController)
		{
			if (cardSystemRoundController == null)
			{
				Debug.LogError("初始化卡牌战斗UI失败");
				return;
			}
			await CardDeckArea.Init();
			CardSystemController.Instance.RoundController.DrawInitCards();
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
