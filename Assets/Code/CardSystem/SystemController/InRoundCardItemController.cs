using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Argali.Game.CardSystem.UI
{
	/// <summary>
	/// 回合内卡片物体UI控制器
	/// </summary>
	/// <remarks>（UI）管理局内CardItem逻辑, 在CardSystemRoundController下引用</remarks>
	public class InRoundCardItemController
	{

		#region Parameter
		private InRoundCardItem _currentCardItem;
		#endregion

		#region Event
		public delegate void SelectCardItemDelegate(InRoundCardItem lastItem, InRoundCardItem currentItem);
		public delegate void HoverCardItemDelegate(InRoundCardItem item);
		public delegate void UseCardItemDelegate(InRoundCardItem item, params object[] args);
		public delegate void DropCardItemDelegate(InRoundCardItem item);

		public event SelectCardItemDelegate OnSelectCardItem;
		public event HoverCardItemDelegate OnHoverCardItem;
		public event UseCardItemDelegate OnUseCardItem;
		public event DropCardItemDelegate OnDropCardItem;
		#endregion

		public InRoundCardItemController()
		{
			_currentCardItem = null;
		}
		
		/// <summary>
		/// 选择卡片
		/// </summary>
		public void SelectCard(InRoundCardItem cardItem)
		{
			OnSelectCardItem?.Invoke(_currentCardItem, cardItem);
			if (_currentCardItem == cardItem)
			{
				_currentCardItem = null;
			}
			else
			{
				_currentCardItem = cardItem;
			}
		}
		/// <summary>
		/// 取消选择
		/// </summary>
		public void UnSelect()
		{
			if (_currentCardItem !=null)
			{
				OnSelectCardItem?.Invoke(_currentCardItem, _currentCardItem);
				_currentCardItem = null;
			}
		}

		/// <summary>
		/// 使用当前选中卡片
		/// </summary>
		/// <param name="carditem"></param>
		/// <param name="args"></param>
		public void UseCurrentCard(params object[] args)
		{
			if (_currentCardItem == null)
			{
				Debug.LogError("当前未选中任何卡片，但是依然在使用卡片");
				return;
			}
			OnUseCardItem?.Invoke(_currentCardItem, args);
			_currentCardItem = null;
		}
		/// <summary>
		/// 弃牌，并通知所有弃牌事件
		/// </summary>
		public void DropCard()
		{
			OnDropCardItem?.Invoke(_currentCardItem);
			_currentCardItem = null;
		}
		/// <summary>
		/// 悬停卡片
		/// </summary>
		/// <param name="carditem"></param>
		public void HoverCard(InRoundCardItem carditem)
		{
			OnHoverCardItem?.Invoke(carditem);
		}


	}

}
