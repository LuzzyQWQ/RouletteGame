using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Argali.Game.CardSystem;
namespace Argali.Tests
{
	public class CardSystemTest
	{
		[UnityTest]
		// 测试卡牌配置加载
		public IEnumerator TestCardConfigLoader()
		{
			var go = GameObject.Instantiate(new GameObject());
			go.AddComponent<CardConfigLoader>();
			yield return new WaitUntil(()=> CardConfigLoader.Instance.AllCardConfigMap != null);
			Assert.True(CardConfigLoader.Instance.AllCardConfigMap.Count == 0,"CardConfigLoader未加载卡牌配置");
		}

		[UnityTest]
		// 测试卡牌系统初始化
		public IEnumerator TestCardSystemControllerInit()
		{
			var go = GameObject.Instantiate(new GameObject());
			go.AddComponent<CardSystemController>();
			yield return new WaitUntil(() => CardSystemController.Instance != null);
			CardSystemConfig config = ScriptableObject.CreateInstance<CardSystemConfig>();
			config.PreDefinedCardDeckName = "";
			config.MaxHandCount = 5;
			config.DropCount = 2;
			CardSystemController.Instance.InitSystemWithDeck("base",config);
			Assert.True(CardSystemController.Instance.SystemInGameData == null, "未初始化局内数据");

			Assert.True(CardSystemController.Instance.UserCardDeck == null, "未初始化用户卡组");
		}
	}
}
