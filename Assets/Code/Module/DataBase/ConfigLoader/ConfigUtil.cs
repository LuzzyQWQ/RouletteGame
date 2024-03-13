using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Argali.Module.DataBase.ConfigLoader
{

	public class ConfigUtil
	{
		/// <summary>
		/// 加载配置资源
		/// </summary>
		/// <param name="path"></param>
		/// <param name="onLoadSuccess"></param>
		/// <returns></returns>
		public static IEnumerator LoadConfigAsset(string path, System.Action<ScriptableObject> onLoadSuccess)
		{
			if (path == "")
			{
				yield break;
			}
			AsyncOperationHandle<ScriptableObject> handle = Addressables.LoadAssetAsync<ScriptableObject>(path);
			yield return handle;
			if (handle.Status == AsyncOperationStatus.Succeeded)
			{
				ScriptableObject config = handle.Result;
				onLoadSuccess?.Invoke(config);
				Addressables.Release(handle);
			}
			else
			{
				Debug.LogError("LoadConfigAsset Failed");
			}
		}
	}

}
