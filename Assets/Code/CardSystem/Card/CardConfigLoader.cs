using Argali.Module.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

namespace Argali.Game.CardSystem
{
	/// <summary>
	/// 卡牌配置管理器
	/// </summary>
	public class CardConfigLoader : Singleton<CardConfigLoader>
	{
		#region Config File

		[SerializeField]
		private InitialCardDeckConfig _initialCardDeckConfig;
		[SerializeField]
		private CardMapConfig _cardConfig;
		#endregion


		#region 属性

		/// <summary>
		/// 卡片映射 名字 - 卡片信息
		/// </summary>
		private Dictionary<string, CardInfo> _allCardConfigMap;
		/// <summary>
		/// 初始卡组映射 卡组名字 - 初始卡组信息
		/// </summary>
		private Dictionary<string, InitialCardDeckData> _initialCardDeckMap;
		#endregion

		#region 载入
		/// <summary>
		/// 载入初始卡组配置
		/// </summary>
		/// <param name="config"></param>
		private void LoadInitialCardDeckConfig(InitialCardDeckConfig config)
		{
			_initialCardDeckMap = new Dictionary<string, InitialCardDeckData>();
			if (config == null)
			{
				Debug.LogError("初始卡组配置表 为空");
				return;
			}
			foreach (var cardDeckData in config.data)
			{
				if(_initialCardDeckMap.ContainsKey(cardDeckData.CardDeckName))
				{
					Debug.LogError("卡组配置存在相同的卡组名称 "+ cardDeckData.CardDeckName);
					continue;
				}
				_initialCardDeckMap.Add(cardDeckData.CardDeckName, cardDeckData);
			}
		}
		/// <summary>
		/// 载入卡片配置
		/// </summary>
		private void LoadCardMapConfig(CardMapConfig config)
		{
			_allCardConfigMap = new Dictionary<string, CardInfo>();
			if (config == null)
			{
				Debug.LogError("卡片配置表 为空");
				return;
			}
			foreach (var cardinfo in config.data)
			{
				if (_allCardConfigMap.ContainsKey(cardinfo.CardData.CardName))
				{
					Debug.LogError("卡组配置存在相同的卡组名称 " + cardinfo.CardData.CardName);
					continue;
				}
				_allCardConfigMap.Add(cardinfo.CardData.CardName, cardinfo);
			}
		}
		#endregion

		#region 访问
		/// <summary>
		/// 获得所有卡片的信息
		/// </summary>
		/// <returns></returns>
		public List<CardInfo> GetAllCardsInfo() 
		{
			List<CardInfo> cards = new List<CardInfo>();
			foreach (var info in _allCardConfigMap.Values)
			{
				cards.Add(info);
			}
			return cards;
		}

		/// <summary>
		/// 通过卡片ID寻找卡片数据
		/// </summary>
		/// <param name="cardName"></param>
		/// <returns></returns>
		public CardData FindCardDataByName(string cardName)
		{
			if (_allCardConfigMap.ContainsKey(cardName))
			{
				return _allCardConfigMap[cardName].CardData;
			}
			Debug.LogError("无法找到对应GUID的卡片数据" + cardName);
			return null;
		}

		/// <summary>
		/// 生成卡片类
		/// </summary>
		/// <param name="cardName"></param>
		/// <returns></returns>
		public ICard SpawnCard(string cardName)
		{
			if (_allCardConfigMap.ContainsKey(cardName))
			{
				return CardFactory.CreateCard(_allCardConfigMap[cardName].CardClassName, cardName);
			}
			else
			{
				Debug.LogError("无法找到对应GUID的卡片类" + cardName.ToString());
				return null;
			}
		}
		/// <summary>
		/// 获得卡组的初始卡牌
		/// </summary>
		/// <param name="deckName"></param>
		/// <returns></returns>
		public List<ICard> GetInitialDeckCards(string deckName)
		{
			if (!_initialCardDeckMap.ContainsKey(deckName))
			{
				Debug.LogError("没有对应的卡组预设 " + deckName);
				return null;
			}
			List<ICard> ans = new List<ICard>();
			foreach (var cardGuid in _initialCardDeckMap[deckName].CardsGUIDs)
			{
				ans.Add(SpawnCard(cardGuid));
			}
			return ans;
		}
		/// <summary>
		/// 获得所有初试卡组信息
		/// </summary>
		/// <returns></returns>
		public List<InitialCardDeckData> GetAllInitialCardDeckDatas()
		{
			List<InitialCardDeckData> ans = new List<InitialCardDeckData>();
			foreach (var data in _initialCardDeckMap.Values)
			{
				ans.Add(data);
			}
			return ans;
		}
		#endregion


		private void Awake()
		{
			LoadInitialCardDeckConfig(_initialCardDeckConfig);
			LoadCardMapConfig(_cardConfig);
		}
	}

}
