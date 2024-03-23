using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Argali.Game.CardSystem.UI
{
	/// <summary>
	/// 局内卡组区域 UI
	/// </summary>
	public class InRoundCardDeckArea: MonoBehaviour
	{
		#region Element
		private InRoundCardDeckInfoArea _infoArea;

		private RectTransform _handCardContainer;

		/// <summary>
		/// 结束回合，开始结算按钮
		/// </summary>
		private Button _finishRoundButton;
		#endregion

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="finishCallBack"></param>
		public async UniTask Init()
		{
			await UniTask.Yield();
			CardSystemController.Instance.RoundController.CardItemSpawner.SetContainer(_handCardContainer);
		}

		private void Awake()
		{
			InitElement();
		}
		private void InitElement()
		{
			_infoArea = transform.Find("CardDeckInfoPart").GetComponent<InRoundCardDeckInfoArea>();
			_handCardContainer = transform.Find("HandCardArea/Container").GetComponent<RectTransform>();

			_finishRoundButton = transform.Find("ButtonArea/FinishRoundButton").GetComponent<Button>();
			_finishRoundButton.onClick.AddListener(() =>
			{
				GamePlayManager.Instance.TryEndRound();
			});
		}
	}

}
