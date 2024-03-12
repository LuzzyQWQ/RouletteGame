using Argali.Module.DataBase.ConfigLoader;
using Argali.Module.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CardSystem
{
	public class CardSystemConfigLoader : Singleton<CardSystemConfigLoader>
	{

		#region 子 Config Loader
		/// <summary>
		/// 模式配置加载器
		/// </summary>
		/// <remarks> 初始加载 </remarks>
		public ConfigLoader<CardSystemModeInfo> ModeLoader;

		/// <summary>
		/// 卡组配置加载器
		/// </summary>
		/// <remarks> 初始加载 </remarks>
		public ConfigLoader<CardDeckInfo> CardDeckLoader;

		/// <summary>
		/// 卡片配置加载器
		/// </summary>
		/// <remarks> 跟随模式加载 </remarks>
		public ConfigLoader<CardInfo> CardLoader;

		#endregion

		/// <summary>
		/// 加载配置
		/// </summary>
		/// <param name="modeName"></param>
		/// <param name="onFinish"></param>
		public void LoadMode(string modeName, System.Action onFinish)
		{
			CardSystemModeInfo info = ModeLoader.GetInfo(modeName);
			StartCoroutine(ConfigUtil.LoadConfigAsset(info.CardConfigPath, (so) =>
			{
				if (so is CardMapConfig)
				{
					CardMapConfig config = so as CardMapConfig;
					CardLoader.Load(config.data);
					onFinish?.Invoke();
				}
			}));
		}
		#region 生成
		/// <summary>
		/// 生成卡片类
		/// </summary>
		/// <param name="cardName"></param>
		/// <returns></returns>
		public CardBase SpawnCard(string cardName)
		{
			var info = CardLoader.GetInfo(cardName);
			return CardFactory.CreateCard(info.ClassName, cardName);
		}

		#endregion

		/// <summary>
		/// 获得初始卡组
		/// </summary>
		/// <param name="deckName"></param>
		/// <returns></returns>
		public List<ICard> GetInitCardDeck(string deckName)
		{
			List<ICard> cards = new List<ICard>();
			var deckInfo = CardDeckLoader.GetInfo(deckName);
			foreach (var cardGUID in deckInfo.CardsGUIDs)
			{
				cards.Add(SpawnCard(cardGUID));
			}
			return cards;
		}


		/// <summary>
		/// 初始化配置
		/// </summary>
		private void InitConfig()
		{
			ModeLoader = new ConfigLoader<CardSystemModeInfo>();
			CardDeckLoader = new ConfigLoader<CardDeckInfo>();
			CardLoader = new ConfigLoader<CardInfo>();
			// 加载模式配置
			StartCoroutine(ConfigUtil.LoadConfigAsset("Card System Mode Config", (so) =>
			{
				if (so is CardSystemModeConfig)
				{
					CardSystemModeConfig config = so as CardSystemModeConfig;
					ModeLoader.Load(config.data);
				}
			}));
			// 加载卡组配置
			StartCoroutine(ConfigUtil.LoadConfigAsset("Card Deck Config", (so) =>
			{
				if (so is CardDeckConfig)
				{
					CardDeckConfig config = so as CardDeckConfig;
					CardDeckLoader.Load(config.data);
				}
			}));
		}

		public void Awake()
		{
			InitConfig();
		}
	}

}
