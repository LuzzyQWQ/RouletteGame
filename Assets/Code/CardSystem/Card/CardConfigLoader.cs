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
		/// 卡片映射
		/// </summary>
		public Dictionary<string, CardInfo> AllCardConfigMap;
		/// <summary>
		/// 初始卡组映射
		/// </summary>
		public Dictionary<string, InitialCardDeckData> InitialCardDeckMap;
		#endregion

		#region 载入
		/// <summary>
		/// 载入初始卡组配置
		/// </summary>
		/// <param name="config"></param>
		private void LoadInitialCardDeckConfig(InitialCardDeckConfig config)
		{
			InitialCardDeckMap = new Dictionary<string, InitialCardDeckData>();
			if(config != null)
			{
				foreach (var cardDeckData in config.data)
				{
					InitialCardDeckMap.Add(cardDeckData.CardDeckName,cardDeckData);
				}
			}
			else
			{
				Debug.LogError("初始卡组配置为空");
			}
		}
		/// <summary>
		/// 载入配置
		/// </summary>
		private void LoadCardMapConfig(CardMapConfig config)
		{
			AllCardConfigMap = new Dictionary<string, CardInfo>();
			if(config != null)
			{
				foreach (var cardinfo in config.data)
				{
					AllCardConfigMap.Add(cardinfo.CardData.Guid,cardinfo);
				}
			}
			else
			{
				Debug.LogError("卡片配置为空");
			}
		}
		#endregion

		#region 请求
		/// <summary>
		/// 通过卡片ID寻找卡片数据
		/// </summary>
		/// <param name="guid"></param>
		/// <returns></returns>
		public CardData FindCardDataByID(string guid)
		{
			if (AllCardConfigMap.ContainsKey(guid))
			{
				return AllCardConfigMap[guid].CardData;
			}
			Debug.LogError("无法找到对应GUID的卡片数据" + guid);
			return null;
		}

		/// <summary>
		/// 生成卡片类
		/// </summary>
		/// <param name="guid"></param>
		/// <returns></returns>
		public ICard SpawnCard(string guid)
		{
			if (AllCardConfigMap.ContainsKey(guid))
			{
				return Instantiate(AllCardConfigMap[guid].CardClass);
			}else
			{
				Debug.LogError("无法找到对应GUID的卡片类" + guid.ToString());
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
			if (!InitialCardDeckMap.ContainsKey(deckName))
			{
				Debug.LogError("没有对应的卡组预设 " + deckName);
				return null;
			}
			List<ICard> ans = new List<ICard>();
			foreach (var cardGuid in InitialCardDeckMap[deckName].CardsGUIDs)
			{
				ans.Add(SpawnCard(cardGuid));
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
