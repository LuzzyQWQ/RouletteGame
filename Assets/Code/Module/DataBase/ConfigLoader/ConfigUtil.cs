using Cysharp.Threading.Tasks;
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
		public static async UniTask<ScriptableObject> LoadConfigAsset(string path)
		{
			if (path == "")
			{
				return null;
			}
			var config = await Addressables.LoadAssetAsync<ScriptableObject>(path);
			return config;
		}
	}

}
