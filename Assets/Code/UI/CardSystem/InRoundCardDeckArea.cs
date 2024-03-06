using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CardSystem.UI
{
	/// <summary>
	/// 局内卡组区域 UI
	/// </summary>
	public class InRoundCardDeckArea: MonoBehaviour
	{
		#region Element
		public InRoundHandCardArea HandCardArea {  get; private set; }
		private InRoundCardDeckInfoArea _infoArea;
		#endregion
		
		public void Init(CardDeck cardDeck,System.Action finishCallBack=null)
		{
			HandCardArea.Init();
			finishCallBack?.Invoke();
		}



		private void Awake()
		{
			InitElement();
		}
		private void InitElement()
		{
			HandCardArea = transform.Find("HandCardArea").GetComponent<InRoundHandCardArea>();
			_infoArea = transform.Find("CardDeckInfoPart").GetComponent<InRoundCardDeckInfoArea>();
		}
	}

}
