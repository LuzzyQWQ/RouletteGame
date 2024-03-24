using Argali.Game.RouletteSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Argali.Game.GameScene
{
	/// <summary>
	/// 插槽物体
	/// </summary>
	/// <remarks>在游戏场景内的插槽物体</remarks>
	public class SlotObject : MonoBehaviour
	{
		#region Element
		/// <summary>
		/// 插槽下标
		/// </summary>
		private TMP_Text _slotIndexText;
		#endregion

		#region 数据
		private int _slotIndex;

		private ISlot slot => RouletteSystemController.Instance.Roulette.GetSlot(_slotIndex);
		#endregion


		/// <summary>
		/// 绑定插槽
		/// </summary>
		/// <param name="index"></param>
		public void BindSlot(int index)
		{
			_slotIndex = index;
			_slotIndexText.text = (_slotIndex + 1).ToString();
		}



		private void InitElement()
		{
			_slotIndexText = transform.Find("SlotText").GetComponent<TMP_Text>();
		}
		private void Awake()
		{
			InitElement();
		}
	}

}
