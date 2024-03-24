using Argali.Game.RouletteSystem;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Argali.Game.GameScene
{
	/// <summary>
	/// 轮盘物体
	/// </summary>
	/// <remarks>游戏场景内的轮盘物体</remarks>
	public class RouletteObject : MonoBehaviour
	{
		#region Element
		/// <summary>
		/// 插槽物体容器
		/// </summary>
		private Transform _slotContianer;
		#endregion

		/// <summary>
		/// 生成插槽物体
		/// </summary>
		public async UniTask CreateSlotObjects(RouletteBase roulette)
		{
			GameObject slotPrefab = await Addressables.LoadAssetAsync<GameObject>("SlotPrefab");
			int slotCount = roulette.SlotCount;
			Vector3 rotateVec = Vector3.zero;
			for (int i = 0; i < slotCount; i++)
			{
				var slotObject = Instantiate(slotPrefab, _slotContianer).GetComponent<SlotObject>();
				slotObject.transform.DORotate(rotateVec, 0);
				rotateVec += Vector3.forward * 30;
				slotObject.BindSlot(i);
				slotObject.gameObject.name = string.Format("Slot_{0}", i.ToString());
			}
		}
		
		/// <summary>
		/// 移动动画
		/// </summary>
		/// <param name="step"></param>
		/// <param name="isforward"></param>
		/// <param name="time"></param>
		/// <returns></returns>
		public async UniTask Move(int step, float time = 1f)
		{
			Vector3 rotateVector = _slotContianer.rotation.eulerAngles + Vector3.back * step * 360f / RouletteSystemController.Instance.Roulette.SlotCount;
			await _slotContianer.DORotate(rotateVector, time);
		}


		private void InitElement()
		{
			_slotContianer = transform.Find("SlotContainer");
		}

		private void Awake()
		{
			InitElement();
		}
	}

}
