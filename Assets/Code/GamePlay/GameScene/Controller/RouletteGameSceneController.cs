using Argali.Game.RouletteSystem;
using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Argali.Game.GameScene
{
	/// <summary>
	/// 游戏场景 - 轮盘控制器
	/// </summary>
	public class RouletteGameSceneController
	{
		#region 
		/// <summary>
		/// 轮盘对象
		/// </summary>
		public RouletteObject RouletteObject;
		#endregion

		#region 构造
		private RouletteGameSceneController()
		{
			RouletteObject = null;
		}
		/// <summary>
		/// 创建一个新的轮盘游戏场景控制器
		/// </summary>
		/// <returns></returns>
		public static async UniTask Create()
		{
			var instance = new RouletteGameSceneController();
			var roulettePrefab = await Addressables.LoadAssetAsync<GameObject>("RouletteObject");
			instance.RouletteObject = GameObject.Instantiate(roulettePrefab).GetComponent<RouletteObject>();
			await instance.RouletteObject.CreateSlotObjects(RouletteSystemController.Instance.Roulette);
		}
		#endregion 


		public void Destroy()
		{
			GameObject.Destroy(RouletteObject.gameObject);
			RouletteObject = null;
		}
	}

}
