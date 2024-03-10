using Argali.Module.Singleton;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Argali.Game.RouletteSystem
{

	public class SlotItemConfigLoader : Singleton<SlotItemConfigLoader>
	{
		#region Config File
		/// <summary>
		/// 插槽物品的总图鉴
		/// </summary>
		[SerializeField]
		private SlotItemMapConfig _slotItemMapConfig;
		#endregion

		#region 属性
		/// <summary>
		/// 插槽物品映射
		/// 插槽物品名字 - 插槽物品信息
		/// </summary>
		private Dictionary<string, SlotItemInfo> _allSlotItemMap;

		#endregion

		#region 加载保存
		/// <summary>
		/// 载入插槽物品总配置
		/// </summary>
		/// <param name="config">配置表</param>
		private void LoadSlotItemMap(SlotItemMapConfig config)
		{
			_allSlotItemMap = new Dictionary<string, SlotItemInfo>();
			if (config == null)
			{
				Debug.LogError("SlotItem 总配置表为空");
				return;
			}
			foreach (var info in config.data)
			{
				if (_allSlotItemMap.ContainsKey(info.SlotItemData.SlotItemName))
				{
					Debug.LogError("SlotItem 配置表中存在重复配置 " + info.SlotItemData.SlotItemName);
					continue;
				}
				else
				{
					_allSlotItemMap.Add(info.SlotItemData.SlotItemName, info);
				}
			}
		}

		#endregion

		#region 访问
		/// <summary>
		/// 获得所有插槽物品信息
		/// </summary>
		/// <returns></returns>
		public List<SlotItemInfo> GetAllSlotItemInfos()
		{
			List<SlotItemInfo> ans = new List<SlotItemInfo>();
			foreach (var info in _allSlotItemMap.Values)
			{
				ans.Add(info);
			}
			return ans;
		}
		/// <summary>
		/// 根据名字查找插槽物品
		/// </summary>
		/// <param name="slotItemName"></param>
		/// <returns></returns>
		public SlotItemData GetSlotItemData(string slotItemName)
		{
			if (!_allSlotItemMap.ContainsKey(slotItemName))
			{
				Debug.LogError("未找到相应的插槽物品 " + slotItemName);
				return null;
			}
			return _allSlotItemMap[slotItemName].SlotItemData;
		}
		#endregion

		#region 生成类
		/// <summary>
		/// 根据插槽物品名字生成相应类
		/// </summary>
		/// <param name="slotItemName"></param>
		/// <returns></returns>
		public ISlotItem SpawnSlotItem(string slotItemName)
		{
			if (_allSlotItemMap.ContainsKey(slotItemName))
			{
				Debug.LogError("无法找到对应GUID的卡片类" + slotItemName.ToString());
				return null;
			}
			return SlotItemFactory.CreateInstance(_allSlotItemMap[slotItemName].SlotItemClassName,slotItemName);
		}
		#endregion

		private void Awake()
		{
			LoadSlotItemMap(_slotItemMapConfig);
		}
	}

}
