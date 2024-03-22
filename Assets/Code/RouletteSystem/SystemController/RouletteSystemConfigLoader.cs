using Argali.Game.CharacterSystem;
using Argali.Module.DataBase.ConfigLoader;
using Argali.Module.Singleton;
using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Argali.Game.RouletteSystem
{

	public class RouletteSystemConfigLoader : Singleton<RouletteSystemConfigLoader>
	{


		#region 子 Config Loader

		/// <summary>
		/// 模式配置加载器
		/// <remarks> 初始加载 </remarks>
		/// </summary>
		public ConfigLoader<RouletteSystemModeInfo> ModeLoader;

		/// <summary>
		/// 转盘配置加载器
		/// <remarks> 初始加载 </remarks>
		/// </summary>
		public ConfigLoader<RouletteInfo> RouletteLoader;

		/// <summary>
		/// 插槽配置加载器
		/// <remarks> 初始加载 </remarks>
		/// </summary>
		public ConfigLoader<SlotInfo> SlotLoader;

		/// <summary>
		/// 插槽物品配置加载器
		/// <remarks> 模式加载 </remarks>
		/// </summary>
		public ConfigLoader<SlotItemInfo> SlotItemLoader;
		#endregion


		#region 加载
		/// <summary>
		/// 加载模式
		/// </summary>
		/// <param name="modeName"></param>
		public async UniTask LoadMode(string modeName)
		{
			RouletteSystemModeInfo info = ModeLoader.GetInfo(modeName);
			// 加载插槽物品配置
			var slotItemAsset = await ConfigUtil.LoadConfigAsset(info.SlotItemConfigPath);

			if (slotItemAsset is SlotItemMapConfig)
			{
				SlotItemMapConfig config = slotItemAsset as SlotItemMapConfig;
				SlotItemLoader.Load(config.data);
			}
		}
		#endregion

		#region 生成实例化
		/// <summary>
		/// 根据转盘名字生成相应类
		/// </summary>
		/// <param name="rouletteName"></param>
		/// <returns></returns>
		public RouletteBase SpawnRoulette(string rouletteName)
		{
			var info = RouletteLoader.GetInfo(rouletteName);
			return RouletteFactory.CreateRoulette(info.ClassName, rouletteName);
		}
		/// <summary>
		/// 生成插槽
		/// </summary>
		/// <param name="slotName"></param>
		/// <returns></returns>
		public SlotBase SpawnSlot(string slotName)
		{
			var info = SlotLoader.GetInfo(slotName);
			return SlotFactory.CreateInstance(info.ClassName, slotName);
		}
		/// <summary>
		/// 生成插槽物品
		/// </summary>
		/// <param name="slotItemName"></param>
		/// <returns></returns>
		public SlotItemBase SpawnSlotItem(string slotItemName)
		{
			var info = SlotItemLoader.GetInfo(slotItemName);
			return SlotItemFactory.CreateInstance(info.ClassName, slotItemName);
		}
		#endregion



		/// <summary>
		/// 初始加载配置
		/// </summary>
		private void InitConfig()
		{
			ModeLoader = new ConfigLoader<RouletteSystemModeInfo>();
			RouletteLoader = new ConfigLoader<RouletteInfo>();
			SlotLoader = new ConfigLoader<SlotInfo>();
			SlotItemLoader = new ConfigLoader<SlotItemInfo>();

			// 加载模式配置
			UniTask.Create(async () =>
			{
				var modeAsset = await ConfigUtil.LoadConfigAsset("Roulette System Mode Config");
				if (modeAsset is RouletteSystemModeConfig)
				{
					RouletteSystemModeConfig config = modeAsset as RouletteSystemModeConfig;
					ModeLoader.Load(config.data);
				}
			}).Forget();
			// 加载转盘配置
			UniTask.Create(async () =>
			{
				var rouletteAsset = await ConfigUtil.LoadConfigAsset("Roulette Map Config");
				if (rouletteAsset is RouletteMapConfig)
				{
					RouletteMapConfig config = rouletteAsset as RouletteMapConfig;
					RouletteLoader.Load(config.data);
				}
			}).Forget();
			// 加载插槽配置
			UniTask.Create(async () =>
			{
				var slotAsset = await ConfigUtil.LoadConfigAsset("Slot Map Config");
				if (slotAsset is SlotMapConfig)
				{
					SlotMapConfig config = slotAsset as SlotMapConfig;
					SlotLoader.Load(config.data);
				}
			}).Forget();
		}

		private void Awake()
		{
			InitConfig();
		}
	}

}
