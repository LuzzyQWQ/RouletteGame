using Argali.Game;
using Argali.Game.CardSystem;
using Argali.UI.Pop;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.UI;


namespace Argali.UI
{
	/// <summary>
	/// 主界面菜单UI
	/// </summary>
	public class MainMenuPanel :MonoBehaviour
	{
		#region Element
		private Button _startButton;
		private Button _exitButton;
		#endregion



		private void Awake()
		{
			InitElement();
		}
		private void InitElement()
		{
			var buttonContainer = transform.Find("Content/ButtonContainer");

			_startButton = buttonContainer.Find("StartButton").GetComponent<Button>();
			_exitButton = buttonContainer.Find("ExitButton").GetComponent<Button>();

			_startButton.onClick.AddListener(GameStart);
			_exitButton.onClick.AddListener(GameExit);
		}

		#region Click Event
		private void GameStart()
		{
			GamePlayManager.Instance.StartNewGame();
		}

		private void GameExit()
		{
			Application.Quit();
		}
		#endregion
	}

}
