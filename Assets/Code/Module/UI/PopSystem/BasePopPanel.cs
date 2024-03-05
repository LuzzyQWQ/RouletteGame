using System.Collections.Generic;
using Argali.UI.Util;
using Argali.Util.Math;
using MEC;
using UnityEngine;
using UnityEngine.Serialization;

namespace Argali.UI.Pop
{
	// 弹窗渐入方向
	public enum PopFadeInDirection
	{
		FromLeft,
		FromRight,
		FromDown,
		FromUp,
	}
	[RequireComponent(typeof(CanvasAdapter))]
	[RequireComponent(typeof(CanvasGroup))]
	public class BasePopPanel : MonoBehaviour, IPopPanel
	{
		[FormerlySerializedAs("ActiveFadeInOut")]
		[SerializeField]
		protected bool _activeFadeInOut = true;
		protected float _fadeInOutTime = 0.25f;

		protected CanvasGroup _canvasGroup;
		private Vector2 _originalPos;

		[FormerlySerializedAs("fadeInDirection")]
		[SerializeField]
		private PopFadeInDirection _fadeInDirection = PopFadeInDirection.FromDown;

		[FormerlySerializedAs("fadeMoveRect")]
		[SerializeField]
		private RectTransform _fadeMoveRect;

		private const float fadeTime = 0.3f;
		private const float movePixel = -80;

		/// <summary>
		/// 是否正在播放Showing动画。
		/// </summary>
		private bool _isPlayingShowAnim;

		/// <summary>
		/// 是否正在播放Hiding动画。
		/// </summary>
		public bool IsPlayingHideAnim { get; private set; }

		private CoroutineHandle _showHideCoroutine;

		protected System.Action _closeAction = null;

		protected virtual void Awake()
		{
			_canvasGroup = GetComponent<CanvasGroup>();
			if (_fadeMoveRect != null)
			{
				_originalPos = _fadeMoveRect.anchoredPosition;
			}

			if (PopPanelManager.Instance != null)
			{
				PopPanelManager.Instance.AddPopPanelItem(this);
			}
		}

		protected virtual void Start()
		{
			InternalHide();
		}

		protected virtual void OnDestroy()
		{
			if (PopPanelManager.Instance != null)
			{
				PopPanelManager.Instance.RemovePopPanelItem(this);
			}

			Timing.KillCoroutines(_showHideCoroutine);
		}

		public virtual void Close()
		{
			if (!IsPlayingHideAnim)
			{
				Timing.KillCoroutines(_showHideCoroutine);
				_isPlayingShowAnim = false;
				IsPlayingHideAnim = true;
				_showHideCoroutine = Timing.RunCoroutine(FadeOut().CancelWith(gameObject));
			}
		}

		public virtual int GetSortLayer()
		{
			return GetComponent<Canvas>().sortingOrder;
		}

		public virtual void Pop()
		{
			if (_activeFadeInOut)
			{
				if (!_isPlayingShowAnim)
				{
					_isPlayingShowAnim = true;
					IsPlayingHideAnim = false;
					Timing.KillCoroutines(_showHideCoroutine);
					InternalShow();
					_showHideCoroutine = Timing.RunCoroutine(FadeIn());
				}
			}
			else
			{
				InternalShow();
			}
		}

		public virtual void SetSortLayer(int layer)
		{
			GetComponent<Canvas>().sortingOrder = layer;
		}

		// 弹出特效
		private IEnumerator<float> FadeIn()
		{
			float time = 0;
			while (time < fadeTime)
			{
				float percent = Mathf.Clamp01(time / fadeTime);
				_canvasGroup.alpha = MathUtil.GetEaseFunction(EaseType.In, EaseMath.Sine)(percent);
				if (_fadeMoveRect != null)
				{
					_fadeMoveRect.anchoredPosition =
						GetFadeInDirection(_fadeInDirection) *
						(movePixel * (1 - MathUtil.GetEaseFunction(EaseType.In, EaseMath.Sine)(percent))) +
						_originalPos;
				}

				yield return Timing.WaitForOneFrame;
				time += Time.deltaTime;
			}

			if (_fadeMoveRect != null)
			{
				_fadeMoveRect.anchoredPosition = _originalPos;
			}

			_canvasGroup.alpha = 1;
			_isPlayingShowAnim = false;
		}

		// 关闭特效
		private IEnumerator<float> FadeOut()
		{
			float time = 0;
			while (time < fadeTime)
			{
				float percent = Mathf.Clamp01(time / fadeTime);
				_canvasGroup.alpha = 1 - MathUtil.GetEaseFunction(EaseType.Out, EaseMath.Sine)(percent);
				if (_fadeMoveRect != null)
				{
					_fadeMoveRect.anchoredPosition =
						GetFadeInDirection(_fadeInDirection) *
						(movePixel * MathUtil.GetEaseFunction(EaseType.Out, EaseMath.Sine)(percent)) + _originalPos;
				}

				yield return Timing.WaitForOneFrame;
				time += Time.deltaTime;
			}

			if (_fadeMoveRect != null)
			{
				_fadeMoveRect.anchoredPosition = GetFadeInDirection(_fadeInDirection) * movePixel + _originalPos;
			}

			_canvasGroup.alpha = 0;
			IsPlayingHideAnim = false;
			InternalHide();
		}

		public void ActiveFade(bool active)
		{
			_activeFadeInOut = active;
		}

		private Vector2 GetFadeInDirection(PopFadeInDirection dir)
		{
			switch (dir)
			{
				case PopFadeInDirection.FromLeft:
					return new Vector2(1, 0);
				case PopFadeInDirection.FromRight:
					return new Vector2(-1, 0);
				case PopFadeInDirection.FromDown:
					return new Vector2(0, 1);
				case PopFadeInDirection.FromUp:
					return new Vector2(0, -1);
				default:
					return new Vector2(0, -1);
			}
		}

		private void InternalShow()
		{
			if (_fadeMoveRect != null)
			{
				_fadeMoveRect.anchoredPosition = _originalPos;
			}

			gameObject.SetActive(true);
			_canvasGroup.alpha = 1;
		}

		private void InternalHide()
		{
			gameObject.SetActive(false);

			_closeAction?.Invoke();
		}
	}

	// 弹窗接口
	public interface IPopPanel
	{
		/// <summary>
		/// 获取SortLayer层级
		/// </summary>
		/// <returns></returns>
		int GetSortLayer();

		/// <summary>
		/// 设置Layer层级
		/// </summary>
		void SetSortLayer(int layer);

		/// <summary>
		/// 弹框展示
		/// </summary>
		void Pop();

		/// <summary>
		/// 关闭
		/// </summary>
		void Close();
	}
}
