using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Argali.Game.CardSystem.UI
{
	/// <summary>
	/// 局内 CardItemController 生成器
	/// 在局内 通过AddComponent 加入 InRoundCardDeckArea
	/// </summary>
	public class InRoundCardItemSpawner
	{
		#region Element
		
		private GameObject _cardItemPrefab;
		#endregion

		#region Prarameter
		/// <summary>
		/// 是否加载完成资源
		/// </summary>
		public bool IsReady { get; private set; }

		private AsyncOperationHandle<GameObject> _cardItemHandle;

		private RectTransform _handCardContainer;
		#endregion
		public InRoundCardItemSpawner()
		{
			IsReady = false;
			CardSystemController.Instance.UserCardDeck.OnDrawCard += SpawnCard;
			_cardItemHandle = Addressables.LoadAssetAsync<GameObject>("InRoundCardItem");
			_cardItemHandle.Completed += LoadComplete;
		}
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

		private void LoadComplete(AsyncOperationHandle<GameObject> operation)
		{
			if (operation.Status == AsyncOperationStatus.Succeeded)
			{
				IsReady = true;
				_cardItemPrefab = operation.Result;
			}
			else
			{
				Debug.LogError($"Asset failed to load.");
			}
		}
		


		public void Destroy()
		{
			CardSystemController.Instance.UserCardDeck.OnDrawCard -= SpawnCard;
			Addressables.Release(_cardItemHandle);
		}
	}

}
