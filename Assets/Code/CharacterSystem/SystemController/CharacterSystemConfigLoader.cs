using Argali.Module.DataBase.ConfigLoader;
using Argali.Module.Singleton;
using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.Game.CharacterSystem
{
	/// <summary>
	/// 角色配置加载器
	/// </summary>
	public class CharacterSystemConfigLoader : Singleton<CharacterSystemConfigLoader>
	{

		#region 子 Config Loader
		/// <summary>
		/// 模式加载器
		/// </summary>
		public ConfigLoader<CharacterSystemModeInfo> ModeLoader;
		/// <summary>
		/// 玩家角色配置加载器
		/// </summary>
		public ConfigLoader<CharacterInfo> PlayerLoader;
		/// <summary>
		/// 敌人角色配置加载器
		/// </summary>
		public ConfigLoader<CharacterInfo> EnemyLoader;
		#endregion

		/// <summary>
		/// 加载模式
		/// </summary>
		/// <param name="modeName"></param>
		/// <returns></returns>
		public async UniTask LoadMode(string modeName)
		{
			CharacterSystemModeInfo info = ModeLoader.GetInfo(modeName);
			// 加载敌人角色配置
			var enemryAsset = await ConfigUtil.LoadConfigAsset(info.EnemyConfigPath);
			if (enemryAsset is CharacterMapConfig)
			{
				CharacterMapConfig config = enemryAsset as CharacterMapConfig;
				EnemyLoader.Load(config.data);
			}
		}


		#region 生成数据
		/// <summary>
		/// 生成玩家局内数据
		/// </summary>
		/// <param name="characterName"></param>
		/// <returns></returns>
		public CharacterInGameData GeneratePlayerData(string characterName)
		{
			CharacterInfo info = GetPlayerInfo(characterName);
			return new CharacterInGameData(info.BaseData);
		}
		/// <summary>
		/// 生成敌人局内数据
		/// </summary>
		/// <param name="characterName"></param>
		/// <returns></returns>
		public CharacterInGameData GenerateEnemyData(string characterName)
		{
			CharacterInfo info = GetEnemyInfo(characterName);
			// TODO: 未来可能会根据回合数，对敌人数据进行调整
			return new CharacterInGameData(info.BaseData);
		}
		#endregion

		#region 查找数据
		/// <summary>
		/// 查找玩家信息
		/// </summary>
		/// <param name="characterName"></param>
		/// <returns></returns>
		public CharacterInfo GetPlayerInfo(string characterName)
		{
			return PlayerLoader.GetInfo(characterName);
		}
		/// <summary>
		/// 查找敌人信息
		/// </summary>
		/// <param name="characterName"></param>
		/// <returns></returns>
		public CharacterInfo GetEnemyInfo(string characterName)
		{
			return EnemyLoader.GetInfo(characterName);
		}

		#endregion
		
		/// <summary>
		/// 初始化前置配置
		/// </summary>
		private void InitConfig()
		{
			ModeLoader = new ConfigLoader<CharacterSystemModeInfo>();
			PlayerLoader = new ConfigLoader<CharacterInfo>();
			EnemyLoader = new ConfigLoader<CharacterInfo>();


			// 加载模式配置
			UniTask.Create(async () =>
			{
				var playerAsset = await ConfigUtil.LoadConfigAsset("Character System Mode Config");
				if (playerAsset is CharacterSystemModeConfig)
				{
					CharacterSystemModeConfig config = playerAsset as CharacterSystemModeConfig;
					ModeLoader.Load(config.data);
				}
			}).Forget();
			// 加载玩家角色配置
			UniTask.Create(async () =>
			{
				var playerAsset = await ConfigUtil.LoadConfigAsset("Player Character Config");
				if (playerAsset is CharacterMapConfig)
				{
					CharacterMapConfig config = playerAsset as CharacterMapConfig;
					PlayerLoader.Load(config.data);
				}
			}).Forget();

		}


		private void Awake()
		{
			InitConfig();
		}
	}
}
