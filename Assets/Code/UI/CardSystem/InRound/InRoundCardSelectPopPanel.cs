using Argali.UI.Pop;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Argali.Game.CardSystem.UI
{
	/// <summary>
	/// 局内 卡片使用前，选择参数的弹出界面
	/// </summary>
	public class InRoundCardSelectPopPanel : BasePopPanel
	{
		#region Element
		private TMP_Text _cardNameText;
		/// <summary>
		/// 选择参数输入， 暂时使用输入框代替，未来希望改成滚轮或单选器等UI
		/// </summary>
		private TMP_InputField _argsInputField;
		private Button _useButton;
		private Button _closeButton;

		#endregion

		#region Property
		#endregion

		public void UpdateUI(CardBase cardBase)
		{
			_argsInputField.text = "";
			_cardNameText.text = cardBase.GetCardName();
		}

		
		private void UseCard()
		{
			var cardItemController = CardSystemController.Instance.CurrentRoundController.CardItemController;
			cardItemController.UseCurrentCard(_argsInputField.text);
			PopPanelManager.Instance.ClosePopPanel<InRoundCardSelectPopPanel>();
		}

		protected override void Awake()
		{
			base.Awake();
			InitElement();
		}
		private void InitElement()
		{
			var content = transform.Find("Content");
			_cardNameText = content.Find("CardTitleText").GetComponent<TMP_Text>();
			_argsInputField = content.Find("SelectArea/ArgsInput").GetComponent<TMP_InputField>();
			_useButton = content.Find("UseButton").GetComponent<Button>();
			_closeButton = content.Find("CloseButton").GetComponent<Button>();

			_useButton.onClick.AddListener(UseCard);
			_closeButton.onClick.AddListener(() =>
			{
				PopPanelManager.Instance.ClosePopPanel<InRoundCardSelectPopPanel>();
				CardSystemController.Instance.CurrentRoundController.CardItemController.UnSelect();
			});
		}
	}

}
