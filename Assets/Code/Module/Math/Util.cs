
namespace Argali.Util.Math
{
    /// <summary>
    /// 工具类
    /// </summary>
    public static class MathUtil
    {
        /// <summary>
        /// 根据类型和数学方法获得缓动方程
        /// </summary>
        /// <param name="type">缓动类型</param>
        /// <param name="math">缓动方程</param>
        /// <returns></returns>
        public static EaseFunction GetEaseFunction(EaseType type, EaseMath math)
        {
            if (type == EaseType.In)
            {
                switch (math)
                {
                    case EaseMath.Sine:
                        return Ease.EaseInSine;
                    case EaseMath.Quad:
                        return Ease.EaseInQuad;
                    case EaseMath.Cubic:
                        return Ease.EaseInCubic;
                    case EaseMath.Quart:
                        return Ease.EaseInQuart;
                    case EaseMath.Quint:
                        return Ease.EaseInQuint;
                    case EaseMath.Expo:
                        return Ease.EaseInExpo;
                    case EaseMath.Circ:
                        return Ease.EaseInCirc;
                    case EaseMath.Back:
                        return Ease.EaseInBack;
                    case EaseMath.Elastic:
                        return Ease.EaseInElastic;
                    case EaseMath.Bounce:
                        return Ease.EaseInBounce;
                }
            }
            if(type == EaseType.Out)
            {
                switch (math)
                {
                    case EaseMath.Sine:
                        return Ease.EaseOutSine;
                    case EaseMath.Quad:
                        return Ease.EaseOutQuad;
                    case EaseMath.Cubic:
                        return Ease.EaseOutCubic;
                    case EaseMath.Quart:
                        return Ease.EaseOutQuart;
                    case EaseMath.Quint:
                        return Ease.EaseOutQuint;
                    case EaseMath.Expo:
                        return Ease.EaseOutExpo;
                    case EaseMath.Circ:
                        return Ease.EaseOutCirc;
                    case EaseMath.Back:
                        return Ease.EaseOutBack;
                    case EaseMath.Elastic:
                        return Ease.EaseOutElastic;
                    case EaseMath.Bounce:
                        return Ease.EaseOutBounce;
                }
            }
            if(type == EaseType.InOut)
            {
                switch (math)
                {
                    case EaseMath.Sine:
                        return Ease.EaseInOutSine;
                    case EaseMath.Quad:
                        return Ease.EaseInOutQuad;
                    case EaseMath.Cubic:
                        return Ease.EaseInOutCubic;
                    case EaseMath.Quart:
                        return Ease.EaseInOutQuart;
                    case EaseMath.Quint:
                        return Ease.EaseInOutQuint;
                    case EaseMath.Expo:
                        return Ease.EaseInOutExpo;
                    case EaseMath.Circ:
                        return Ease.EaseInOutCirc;
                    case EaseMath.Back:
                        return Ease.EaseInOutBack;
                    case EaseMath.Elastic:
                        return Ease.EaseInOutElastic;
                    case EaseMath.Bounce:
                        return Ease.EaseInOutBounce;
                }
            }
            return Ease.EaseInQuad;
        }

		
    }

}
