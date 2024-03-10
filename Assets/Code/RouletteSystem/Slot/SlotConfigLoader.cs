using Argali.Module.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.RouletteSystem
{

	public class SlotConfigLoader : Singleton<SlotConfigLoader> 
	{
		#region Config File
		/// <summary>
		/// 插槽的总图鉴
		/// </summary>
		[SerializeField]
		private SlotMapConfig _slotMapConfig;
		#endregion

		#region 属性
		/// <summary>
		/// 插槽物品映射
		/// 插槽物品名字 - 插槽物品信息
		/// </summary>
		private Dictionary<string, SlotInfo> _allSlotMap;

		#endregion

		#region 加载保存
		/// <summary>
		/// 载入插槽物品总配置
		/// </summary>
		/// <param name="config">配置表</param>
		private void LoadSlotItemMap(SlotMapConfig config)
		{
			_allSlotMap = new Dictionary<string, SlotInfo>();
			if (config == null)
			{
				Debug.LogError("SlotItem 总配置表为空");
				return;
			}
			foreach (var info in config.data)
			{
				if (_allSlotMap.ContainsKey(info.SlotData.SlotName))
				{
					Debug.LogError("SlotItem 配置表中存在重复配置 " + info.SlotData.SlotName);
					continue;
				}
				else
				{
					_allSlotMap.Add(info.SlotData.SlotName, info);
				}
			}
		}

		#endregion

		#region 访问
		/// <summary>
		/// 获得所有插槽物品信息
		/// </summary>
		/// <returns></returns>
		public List<SlotInfo> GetAllSlotInfos()
		{
			List<SlotInfo> ans = new List<SlotInfo>();
			foreach (var info in _allSlotMap.Values)
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
		public SlotData GetSlotItemData(string slotName)
		{
			if (!_allSlotMap.ContainsKey(slotName))
			{
				Debug.LogError("未找到相应的插槽物品 " + slotName);
				return null;
			}
			return _allSlotMap[slotName].SlotData;
		}
		#endregion

		#region 生成类
		/// <summary>
		/// 根据插槽物品名字生成相应类
		/// </summary>
		/// <param name="slotName"></param>
		/// <returns></returns>
		public ISlotItem SpawnSlot(string slotName)
		{
			if (_allSlotMap.ContainsKey(slotName))
			{
				Debug.LogError("无法找到对应GUID的卡片类" + slotName.ToString());
				return null;
			}
			return SlotItemFactory.CreateInstance(_allSlotMap[slotName].ClassName,slotName);
		}
		#endregion

		private void Awake()
		{
			LoadSlotItemMap(_slotMapConfig);
		}
	}

}
