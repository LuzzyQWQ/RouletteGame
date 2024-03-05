using UnityEngine;
using UnityEngine.UI;

namespace Argali.UI.Util
{
    [RequireComponent(typeof(CanvasScaler))]
    public class CanvasAdapter : MonoBehaviour
    {
        private CanvasScaler CanvasScaler => _canvasScaler != null ? _canvasScaler : GetComponent<CanvasScaler>();
        private CanvasScaler _canvasScaler;

        public bool isAutoOn = true;

        public void Awake()
        {
            _canvasScaler = GetComponent<CanvasScaler>();
            SetMatchHeight(IsPad);
        }

        /// <summary>
        /// 小于1.6按 pad 屏幕适配
        /// ipad = 4/3 = 1.33
        /// ipadMini = 1.5?
        /// </summary>
        private const float TriggerRatio = 1.85f;

        public static bool IsPad
        {
            get
            {
                var screenRatio = Screen.height / (float)Screen.width;
                if (screenRatio < 1)
                {
                    screenRatio = 1 / screenRatio;
                }

                return screenRatio <= TriggerRatio;
            }
        }

        private void SetMatchHeight(bool matchHeight)
        {
            CanvasScaler.matchWidthOrHeight = matchHeight ? 1f : 0f;
        }

        //[Button]
        //private void SetScreenMatchHeight()
        //{
        //    SetMatchHeight(true);
        //}

        //[Button]
        //private void SetScreenMatchWidth()
        //{
        //    SetMatchHeight(false);
        //}
    }
}
