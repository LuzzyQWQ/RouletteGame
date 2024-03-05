
using UnityEngine;
namespace Argali.Util.Math
{

    public static class Ease
    {

        #region 缓动方程
        /// <summary>
        /// Sine淡入方程
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInSine(float x)
        {
            return 1 - Mathf.Cos((x * Mathf.PI) / 2);
        }

        /// <summary>
        /// Sine淡出方程
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseOutSine(float x)
        {
            return Mathf.Sin((x * Mathf.PI) / 2);
        }
        /// <summary>
        /// Sine淡入淡出方程
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInOutSine(float x)
        {
            return -(Mathf.Cos(Mathf.PI * x) - 1) / 2;
        }
        /// <summary>
        /// 平方淡入方程
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInQuad(float x)
        {
            return x * x;
        }
        /// <summary>
        /// 平方淡出方程
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseOutQuad(float x)
        {
            return 1 - (1 - x) * (1 - x);
        }
        /// <summary>
        /// 平方淡入淡出方程
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInOutQuad(float x)
        {
            return x < 0.5 ? 2 * x * x : 1 - Mathf.Pow(-2 * x + 2, 2) / 2;
        }
        /// <summary>
        /// 立方淡入方程
        /// </summary>
        /// <param name="x">（0-1）</param>
        /// <returns></returns>
        public static float EaseInCubic(float x)
        {
            return x * x * x;
        }
        /// <summary>
        /// 立方淡出方程
        /// </summary>
        /// <param name="x">（0-1）</param>
        /// <returns></returns>
        public static float EaseOutCubic(float x)
        {
            return 1 - Mathf.Pow(1 - x, 3);
        }
        /// <summary>
        /// 立方淡入淡出方程
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInOutCubic(float x)
        {
            return x < 0.5 ? 4 * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 3) / 2;
        }

        /// <summary>
        /// 四次方淡入方程
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInQuart(float x)
        {
            return x * x * x * x;
        }
        /// <summary>
        /// 四次方淡出方程
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseOutQuart(float x)
        {
            return 1 - Mathf.Pow(1 - x, 4);
        }
        /// <summary>
        /// 四次方淡入淡出方程
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInOutQuart(float x)
        {
            return x < 0.5 ? 8 * x * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 4) / 2;
        }

        /// <summary>
        /// 五次方淡入方程
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInQuint(float x)
        {
            return x * x * x * x * x;
        }
        /// <summary>
        /// 五次方淡出方程
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseOutQuint(float x)
        {
            return 1 - Mathf.Pow(1 - x, 5);
        }
        /// <summary>
        /// 五次方淡入淡出方程
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInOutQuint(float x)
        {
            return x < 0.5 ? 16 * x * x * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 5) / 2;
        }
        /// <summary>
        /// 指数淡入方程
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInExpo(float x)
        {
            return x <= 0 ? 0 : Mathf.Pow(2, 10 * x - 10);
        }
        /// <summary>
        /// 指数淡出方程
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseOutExpo(float x)
        {
            return x >= 1 ? 1 : 1 - Mathf.Pow(2, -10 * x);
        }
        /// <summary>
        /// 指数淡入淡出方程
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInOutExpo(float x)
        {
            return x <= 0
                ? 0
                : x >= 1
                ? 1
                : x < 0.5 ? Mathf.Pow(2, 20 * x - 10) / 2
                : (2 - Mathf.Pow(2, -20 * x + 10)) / 2;
        }
        /// <summary>
        /// 圆形淡入方程
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInCirc(float x)
        {
            return 1 - Mathf.Sqrt(1 - Mathf.Pow(x, 2));
        }
        /// <summary>
        /// 圆形淡出方程
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseOutCirc(float x)
        {
            return Mathf.Sqrt(1 - Mathf.Pow(x - 1, 2));
        }
        /// <summary>
        /// 圆形淡入淡出方程
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInOutCirc(float x)
        {
            return x < 0.5
                ? (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * x, 2))) / 2
                : (Mathf.Sqrt(1 - Mathf.Pow(-2 * x + 2, 2))) / 2;
        }
        /// <summary>
        /// 回退淡入曲线
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInBack(float x)
        {
            float c1 = 1.70158f;
            float c3 = c1 + 1;
            return c3 * x * x * x - c1 * x * x;
        }
        /// <summary>
        /// 回退淡出曲线
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseOutBack(float x)
        {
            float c1 = 1.70158f;
            float c3 = c1 + 1;
            return 1 + c3 * Mathf.Pow(x - 1, 3) + c1 * Mathf.Pow(x - 1, 2);
        }
        /// <summary>
        /// 回退淡入淡出曲线
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInOutBack(float x)
        {
            float c1 = 1.70158f;
            float c3 = c1 + 1;

            return x < 0.5
                ? (Mathf.Pow(2 * x, 2) * ((c3 + 1) * 2 * x - c3)) / 2
                : (Mathf.Pow(2 * x - 2, 2) * ((c3 + 1) * (x * 2 - 2) + c3) + 2) / 2;
        }
        /// <summary>
        /// 弹性淡入曲线
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInElastic(float x)
        {
            float c4 = (2 * Mathf.PI) / 3;

            return x <= 0
                ? 0
                : x >= 1
                ? 1
                : -Mathf.Pow(2, 10 * x - 10) * Mathf.Sin((x * 10 - 10.75f) * c4);
        }
        /// <summary>
        /// 弹性淡出曲线
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseOutElastic(float x)
        {
            float c4 = (2 * Mathf.PI) / 3;

            return x <= 0
                ? 0
                : x >= 1
                ? 1
                : Mathf.Pow(2, -10 * x) * Mathf.Sin((x * 10 - 0.75f) * c4) + 1;
        }
        
        /// <summary>
        /// 弹性淡入淡出曲线
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInOutElastic(float x)
        {
            float c5 = (2 * Mathf.PI) / 4.5f;

            return x <= 0
                ? 0
                : x >= 1
                ? 1
                : x < 0.5
                ? -(Mathf.Pow(2, 20 * x - 10) * Mathf.Sin((20 * x - 11.125f) * c5)) / 2
                : (Mathf.Pow(2, -20 * x + 10) * Mathf.Sin((20 * x - 11.125f) * c5)) / 2 + 1;
        }
        
        /// <summary>
        /// 跳跃淡入曲线
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInBounce(float x)
        {
            return 1 - EaseOutBounce(x);
        }
        /// <summary>
        /// 跳跃淡出曲线
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseOutBounce(float x)
        {
            float n1 = 7.5625f;
            float d1 = 2.75f;

            if (x < 1 / d1)
            {
                return n1 * x * x;
            }
            else if (x < 2 / d1)
            {
                return n1 * (x -= 1.5f / d1) * x + 0.75f;
            }
            else if (x < 2.5 / d1)
            {
                return n1 * (x -= 2.25f / d1) * x + 0.9375f;
            }
            else
            {
                return n1 * (x -= 2.625f / d1) * x + 0.984375f;
            }
        }
        /// <summary>
        /// 跳跃淡入淡出曲线
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInOutBounce(float x)
        {
            return x < 0.5
                ? (1 - EaseOutBounce(1 - 2 * x)) / 2
                : (1 + EaseOutBounce(2 * x - 1)) / 2;
        }
        #endregion

    }

}
