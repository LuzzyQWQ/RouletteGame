using Argali.Module.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.RouletteSystem
{

	public class RouletteConfigLoader : Singleton<RouletteConfigLoader> 
	{
		#region Config File
		/// <summary>
		/// 插槽的总图鉴
		/// </summary>
		[SerializeField]
		private RouletteMapConfig _rouletteConfig;
		#endregion

		#region 属性
		/// <summary>
		/// 插槽物品映射
		/// 插槽物品名字 - 插槽物品信息
		/// </summary>
		private Dictionary<string, RouletteInfo> _rouletteMap;

		#endregion

		#region 加载保存
		/// <summary>
		/// 载入插槽物品总配置
		/// </summary>
		/// <param name="config">配置表</param>
		private void LoadRouletteMap(RouletteMapConfig config)
		{
			_rouletteMap = new Dictionary<string, RouletteInfo>();
			if (config == null)
			{
				Debug.LogError("SlotItem 总配置表为空");
				return;
			}
			foreach (var info in config.data)
			{
				if (_rouletteMap.ContainsKey(info.RouletteData.RouletteName))
				{
					Debug.LogError("SlotItem 配置表中存在重复配置 " + info.RouletteData.RouletteName);
					continue;
				}
				else
				{
					_rouletteMap.Add(info.RouletteData.RouletteName, info);
				}
			}
		}

		#endregion

		#region 访问
		/// <summary>
		/// 获得所有轮盘信息
		/// </summary>
		/// <returns></returns>
		public List<RouletteInfo> GetAllInitRouletteInfos()
		{
			List<RouletteInfo> ans = new List<RouletteInfo>();
			foreach (var info in _rouletteMap.Values)
			{
				ans.Add(info);
			}
			return ans;
		}
		/// <summary>
		/// 根据名字查找插槽物品
		/// </summary>
		/// <param name="slotName"></param>
		/// <returns></returns>
		public RouletteData GetRouletteData(string rouletteName)
		{
			if (!_rouletteMap.ContainsKey(rouletteName))
			{
				Debug.LogError("未找到相应的插槽物品 " + rouletteName);
				return null;
			}
			return _rouletteMap[rouletteName].RouletteData;
		}
		#endregion

		#region 生成类
		/// <summary>
		/// 根据插槽物品名字生成相应类
		/// </summary>
		/// <param name="rouletteName"></param>
		/// <returns></returns>
		public RouletteBase SpawnRoulette(string rouletteName)
		{
			if (_rouletteMap.ContainsKey(rouletteName))
			{
				Debug.LogError("无法找到对应GUID的转盘类" + rouletteName.ToString());
				return null;
			}
			return RouletteFactory.CreateRoulette(_rouletteMap[rouletteName].ClassName,rouletteName);
		}
		#endregion

		private void Awake()
		{
			LoadRouletteMap(_rouletteConfig);
		}
	}

}
