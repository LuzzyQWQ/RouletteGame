using Argali.Game;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

namespace Argali.UI.Pop
{

	/// <summary>
	/// 游戏内关卡选择界面
	/// </summary>
	public class RoundSelectPanel : BasePopPanel
	{
		#region Elmement
		/// <summary>
		/// 开始回合按钮
		/// </summary>
		private Button startRoundBtn;

		#endregion

		/// <summary>
		/// 初始化界面元素
		/// </summary>
		private void InitElement()
		{
			var content = transform.Find("Content");

			startRoundBtn = content.Find("StartRoundButton").GetComponent<Button>();
			startRoundBtn.onClick.AddListener(() => { GamePlayManager.Instance.StartRound().Forget(); });
		}
		protected override void Awake()
		{
			base.Awake();
			InitElement();
		}
	}

}
