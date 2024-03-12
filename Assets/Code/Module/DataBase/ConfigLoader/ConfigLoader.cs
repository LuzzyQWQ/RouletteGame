using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Argali.Module.DataBase.ConfigLoader
{

	/// <summary>
	/// 配置载入器
	/// </summary>   
	/// <remarks>
	/// 通用配置载入器，使用GUID作为索引，检索配置信息。
	/// </remarks>
	/// <typeparam name="InfoType">信息类型</typeparam>
	public class ConfigLoader<InfoType> where InfoType : IConfigInfo
	{
		#region 属性
		/// <summary> 
		/// 配置映射表 GUID -> InfoType
		/// </summary>
		private Dictionary<string, InfoType> _configMap;
		#endregion
		public ConfigLoader()
		{
			_configMap = new Dictionary<string, InfoType>();
		}

		#region 加载	
		/// <summary>
		/// 加载配置信息
		/// </summary>
		/// <param name="datas"></param>
		/// <param name="addition">额外添加</param>
		public void Load(List<InfoType> datas, bool addition = false)
		{
			if (!addition)
			{
				_configMap.Clear();
			}
			if (datas == null)
			{
				Debug.LogError(string.Format("ConfigLoader<{0}>.Load()失败,数据为空", typeof(InfoType).ToString()));
				return;
			}
			foreach (var info in datas)
			{
				string guid = info.GetGUID();
				if (_configMap.ContainsKey(guid))
				{
					Debug.LogError(string.Format("ConfigLoader<{0}>.Load()存在重复数据", guid));
					continue;
				}
				else
				{
					_configMap.Add(guid, info);
				}
			}
		}
		#endregion

		#region 请求
		/// <summary>
		/// 请求数据
		/// </summary>
		/// <param name="guid"></param>
		/// <returns></returns>
		public InfoType GetInfo(string guid)
		{
			if (_configMap.ContainsKey(guid))
			{
				return _configMap[guid];
			}
			else
			{
				Debug.LogError(string.Format("ConfigLoader<{0}>.GetInfo()不存在GUID:{1}", typeof(InfoType).ToString(), guid));
				return default;
			}
		}
		/// <summary>
		/// 获得所有配置信息
		/// </summary>
		/// <returns></returns>
		public List<InfoType> GetAllInfos()
		{
			List<InfoType> list = new List<InfoType>();
			foreach (var info in _configMap.Values)
			{
				list.Add(info);
			}
			return list;
		}
		#endregion


	}

}
