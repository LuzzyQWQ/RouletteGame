using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Argali.Game.CardSystem.UI
{
	/// <summary>
	/// 回合内卡片物体UI生成器
	/// </summary>
	/// <remarks>在局内 通过AddComponent 加入 InRoundCardDeckArea</remarks>
	public class InRoundCardItemSpawner
	{
		#region Element
		
		private GameObject _cardItemPrefab;
		#endregion

		#region Prarameter
		/// <summary>
		/// 手牌区域
		/// </summary>
		private RectTransform _handCardContainer;
		#endregion

		#region 构造
		private InRoundCardItemSpawner()
		{
			CardSystemController.Instance.UserCardDeck.OnDrawCard += SpawnCard;
		}
		public static async UniTask<InRoundCardItemSpawner> Create()
		{
			InRoundCardItemSpawner instance = new InRoundCardItemSpawner();
			var prefab = await Addressables.LoadAssetAsync<GameObject>("InRoundCardItem");
			instance._cardItemPrefab = prefab;
			return instance;
		}
		#endregion

		// 初始化
		public void SetContainer(RectTransform container)
		{
			_handCardContainer = container;
			ClearDeckArea();
		}
		private void ClearDeckArea()
		{
			if (_handCardContainer == null)
			{
				return;
			}
			for (int i = 0; i < _handCardContainer.childCount; i++)
			{
				GameObject.Destroy(_handCardContainer.GetChild(i).gameObject);
			}
		}
		/// <summary>
		/// 生成卡片
		/// </summary>
		/// <param name="card"></param>
		private void SpawnCard(ICard card)
		{
			if (_handCardContainer == null)
			{
				return;
			}
			InRoundCardItem item = GameObject.Instantiate(_cardItemPrefab, _handCardContainer).GetComponent<InRoundCardItem>();
			item.InitCardItem(card as CardBase);
		}
		

		public void Destroy()
		{
			CardSystemController.Instance.UserCardDeck.OnDrawCard -= SpawnCard;
		}
	}

}
