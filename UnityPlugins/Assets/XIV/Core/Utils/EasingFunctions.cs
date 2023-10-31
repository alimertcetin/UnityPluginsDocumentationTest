using UnityEngine;

namespace XIV.Core.Utils
{
    // https://gist.github.com/cjddmut/d789b9eb78216998e95c
    public static class EasingFunction
    {
        public enum Ease
        {
            EaseInQuad = 0,
            EaseOutQuad,
            EaseInOutQuad,
            EaseInCubic,
            EaseOutCubic,
            EaseInOutCubic,
            EaseInQuart,
            EaseOutQuart,
            EaseInOutQuart,
            EaseInQuint,
            EaseOutQuint,
            EaseInOutQuint,
            EaseInSine,
            EaseOutSine,
            EaseInOutSine,
            EaseInExpo,
            EaseOutExpo,
            EaseInOutExpo,
            EaseInCirc,
            EaseOutCirc,
            EaseInOutCirc,
            Linear,
            Spring,
            EaseInBounce,
            EaseOutBounce,
            EaseInOutBounce,
            EaseInBack,
            EaseOutBack,
            EaseInOutBack,
            EaseInElastic,
            EaseOutElastic,
            EaseInOutElastic,
            EaseSmoothStart1,
            EaseSmoothStart2,
            EaseSmoothStart3,
            EaseSmoothStart4,
            EaseSmoothStart5,
            EaseSmoothStart6,
            EaseSmoothStop1,
            EaseSmoothStop2,
            EaseSmoothStop3,
            EaseSmoothStop4,
            EaseSmoothStop5,
            EaseSmoothStop6,
            EaseSmoothStartAndStop1,
            EaseSmoothStartAndStop2,
            EaseSmoothStartAndStop3,
            EaseSmoothStartAndStop4,
            EaseSmoothStartAndStop5,
            EaseSmoothStartAndStop6,
        }

        private const float NATURAL_LOG_OF_2 = 0.693147181f;

        //
        // Easing functions
        //

        #region Easing 0-1

        
        public static float Linear(float value)
        {
            return Linear(0, 1f, value);
        }

        public static float Spring(float value)
        {
            return Spring(0, 1f, value);
        }

        public static float EaseInQuad(float value)
        {
            return EaseInQuad(0, 1f, value);
        }

        public static float EaseOutQuad(float value)
        {
            return EaseOutQuad(0, 1f, value);
        }

        public static float EaseInOutQuad(float value)
        {
            return EaseInOutQuad(0, 1f, value);
        }

        public static float EaseInCubic(float value)
        {
            return EaseInCubic(0, 1f, value);
        }

        public static float EaseOutCubic(float value)
        {
            return EaseOutCubic(0, 1f, value);
        }

        public static float EaseInOutCubic(float value)
        {
            return EaseInOutCubic(0, 1f, value);
        }

        public static float EaseInQuart(float value)
        {
            return EaseInQuart(0, 1f, value);
        }

        public static float EaseOutQuart(float value)
        {
            return EaseOutQuart(0, 1f, value);
        }

        public static float EaseInOutQuart(float value)
        {
            return EaseInOutQuart(0, 1f, value);
        }

        public static float EaseInQuint(float value)
        {
            return EaseInQuint(0, 1f, value);
        }

        public static float EaseOutQuint(float value)
        {
            return EaseOutQuint(0, 1f, value);
        }

        public static float EaseInOutQuint(float value)
        {
            return EaseInOutQuint(0, 1f, value);
        }

        public static float EaseInSine(float value)
        {
            return EaseInSine(0, 1f, value);
        }

        public static float EaseOutSine(float value)
        {
            return EaseOutSine(0, 1f, value);
        }

        public static float EaseInOutSine(float value)
        {
            return EaseInOutSine(0, 1f, value);
        }

        public static float EaseInExpo(float value)
        {
            return EaseInExpo(0, 1f, value);
        }

        public static float EaseOutExpo(float value)
        {
            return EaseOutExpo(0, 1f, value);
        }

        public static float EaseInOutExpo(float value)
        {
            return EaseInOutExpo(0, 1f, value);
        }

        public static float EaseInCirc(float value)
        {
            return EaseInCirc(0, 1f, value);
        }

        public static float EaseOutCirc(float value)
        {
            return EaseOutCirc(0, 1f, value);
        }

        public static float EaseInOutCirc(float value)
        {
            return EaseInOutCirc(0, 1f, value);
        }

        public static float EaseInBounce(float value)
        {
            return EaseInBounce(0, 1f, value);
        }

        public static float EaseOutBounce(float value)
        {
            return EaseOutBounce(0, 1f, value);
        }

        public static float EaseInOutBounce(float value)
        {
            return EaseInOutBounce(0, 1f, value);
        }

        public static float EaseInBack(float value)
        {
            return EaseInBack(0, 1f, value);
        }

        public static float EaseOutBack(float value)
        {
            return EaseOutBack(0, 1f, value);
        }

        public static float EaseInOutBack(float value)
        {
            return EaseInOutBack(0, 1f, value);
        }

        public static float EaseInElastic(float value)
        {
            return EaseInElastic(0, 1f, value);
        }

        public static float EaseOutElastic(float value)
        {
            return EaseOutElastic(0, 1f, value);
        }

        public static float EaseInOutElastic(float value)
        {
            return EaseInOutElastic(0, 1f, value);
        }

        public static float SmoothStart1(float t)
        {
            return t * t;
        }

        public static float SmoothStart2(float t)
        {
            return t * t * t;
        }

        public static float SmoothStart3(float t)
        {
            return t * t * t * t;
        }

        public static float SmoothStart4(float t)
        {
            return t * t * t * t * t;
        }

        public static float SmoothStart5(float t)
        {
            return t * t * t * t * t * t;
        }

        public static float SmoothStart6(float t)
        {
            return t * t * t * t * t * t * t;
        }
        
        public static float SmoothStop1(float t)
        {
            float oneMinusT = 1 - t;
            return 1 - oneMinusT * oneMinusT * oneMinusT;
        }

        public static float SmoothStop2(float t)
        {
            float oneMinusT = 1 - t;
            return 1 - oneMinusT * oneMinusT;
        }

        public static float SmoothStop3(float t)
        {
            float oneMinusT = 1 - t;
            return 1 - oneMinusT * oneMinusT * oneMinusT * oneMinusT;
        }

        public static float SmoothStop4(float t)
        {
            float oneMinusT = 1 - t;
            return 1 - oneMinusT * oneMinusT * oneMinusT * oneMinusT * oneMinusT;
        }

        public static float SmoothStop5(float t)
        {
            float oneMinusT = 1 - t;
            return 1 - oneMinusT * oneMinusT * oneMinusT * oneMinusT * oneMinusT * oneMinusT;
        }

        public static float SmoothStop6(float t)
        {
            float oneMinusT = 1 - t;
            return 1 - oneMinusT * oneMinusT * oneMinusT * oneMinusT * oneMinusT * oneMinusT * oneMinusT;
        }

        #endregion

        public static float Linear(float start, float end, float value)
        {
            return Mathf.Lerp(start, end, value);
        }

        public static float Spring(float start, float end, float value)
        {
            value = Mathf.Clamp01(value);
            value = (Mathf.Sin(value * Mathf.PI * (0.2f + 2.5f * value * value * value)) * Mathf.Pow(1f - value, 2.2f) + value) * (1f + (1.2f * (1f - value)));
            return start + (end - start) * value;
        }

        public static float EaseInQuad(float start, float end, float value)
        {
            end -= start;
            return end * value * value + start;
        }

        public static float EaseOutQuad(float start, float end, float value)
        {
            end -= start;
            return -end * value * (value - 2) + start;
        }

        public static float EaseInOutQuad(float start, float end, float value)
        {
            value /= .5f;
            end -= start;
            if (value < 1) return end * 0.5f * value * value + start;
            value--;
            return -end * 0.5f * (value * (value - 2) - 1) + start;
        }

        public static float EaseInCubic(float start, float end, float value)
        {
            end -= start;
            return end * value * value * value + start;
        }

        public static float EaseOutCubic(float start, float end, float value)
        {
            value--;
            end -= start;
            return end * (value * value * value + 1) + start;
        }

        public static float EaseInOutCubic(float start, float end, float value)
        {
            value /= .5f;
            end -= start;
            if (value < 1) return end * 0.5f * value * value * value + start;
            value -= 2;
            return end * 0.5f * (value * value * value + 2) + start;
        }

        public static float EaseInQuart(float start, float end, float value)
        {
            end -= start;
            return end * value * value * value * value + start;
        }

        public static float EaseOutQuart(float start, float end, float value)
        {
            value--;
            end -= start;
            return -end * (value * value * value * value - 1) + start;
        }

        public static float EaseInOutQuart(float start, float end, float value)
        {
            value /= .5f;
            end -= start;
            if (value < 1) return end * 0.5f * value * value * value * value + start;
            value -= 2;
            return -end * 0.5f * (value * value * value * value - 2) + start;
        }

        public static float EaseInQuint(float start, float end, float value)
        {
            end -= start;
            return end * value * value * value * value * value + start;
        }

        public static float EaseOutQuint(float start, float end, float value)
        {
            value--;
            end -= start;
            return end * (value * value * value * value * value + 1) + start;
        }

        public static float EaseInOutQuint(float start, float end, float value)
        {
            value /= .5f;
            end -= start;
            if (value < 1) return end * 0.5f * value * value * value * value * value + start;
            value -= 2;
            return end * 0.5f * (value * value * value * value * value + 2) + start;
        }

        public static float EaseInSine(float start, float end, float value)
        {
            end -= start;
            return -end * Mathf.Cos(value * (Mathf.PI * 0.5f)) + end + start;
        }

        public static float EaseOutSine(float start, float end, float value)
        {
            end -= start;
            return end * Mathf.Sin(value * (Mathf.PI * 0.5f)) + start;
        }

        public static float EaseInOutSine(float start, float end, float value)
        {
            end -= start;
            return -end * 0.5f * (Mathf.Cos(Mathf.PI * value) - 1) + start;
        }

        public static float EaseInExpo(float start, float end, float value)
        {
            end -= start;
            return end * Mathf.Pow(2, 10 * (value - 1)) + start;
        }

        public static float EaseOutExpo(float start, float end, float value)
        {
            end -= start;
            return end * (-Mathf.Pow(2, -10 * value) + 1) + start;
        }

        public static float EaseInOutExpo(float start, float end, float value)
        {
            value /= .5f;
            end -= start;
            if (value < 1) return end * 0.5f * Mathf.Pow(2, 10 * (value - 1)) + start;
            value--;
            return end * 0.5f * (-Mathf.Pow(2, -10 * value) + 2) + start;
        }

        public static float EaseInCirc(float start, float end, float value)
        {
            end -= start;
            return -end * (Mathf.Sqrt(1 - value * value) - 1) + start;
        }

        public static float EaseOutCirc(float start, float end, float value)
        {
            value--;
            end -= start;
            return end * Mathf.Sqrt(1 - value * value) + start;
        }

        public static float EaseInOutCirc(float start, float end, float value)
        {
            value /= .5f;
            end -= start;
            if (value < 1) return -end * 0.5f * (Mathf.Sqrt(1 - value * value) - 1) + start;
            value -= 2;
            return end * 0.5f * (Mathf.Sqrt(1 - value * value) + 1) + start;
        }

        public static float EaseInBounce(float start, float end, float value)
        {
            end -= start;
            float d = 1f;
            return end - EaseOutBounce(0, end, d - value) + start;
        }

        public static float EaseOutBounce(float start, float end, float value)
        {
            value /= 1f;
            end -= start;
            if (value < (1 / 2.75f))
            {
                return end * (7.5625f * value * value) + start;
            }
            else if (value < (2 / 2.75f))
            {
                value -= (1.5f / 2.75f);
                return end * (7.5625f * (value) * value + .75f) + start;
            }
            else if (value < (2.5 / 2.75))
            {
                value -= (2.25f / 2.75f);
                return end * (7.5625f * (value) * value + .9375f) + start;
            }
            else
            {
                value -= (2.625f / 2.75f);
                return end * (7.5625f * (value) * value + .984375f) + start;
            }
        }

        public static float EaseInOutBounce(float start, float end, float value)
        {
            end -= start;
            float d = 1f;
            if (value < d * 0.5f) return EaseInBounce(0, end, value * 2) * 0.5f + start;
            else return EaseOutBounce(0, end, value * 2 - d) * 0.5f + end * 0.5f + start;
        }

        public static float EaseInBack(float start, float end, float value)
        {
            end -= start;
            value /= 1;
            float s = 1.70158f;
            return end * (value) * value * ((s + 1) * value - s) + start;
        }

        public static float EaseOutBack(float start, float end, float value)
        {
            float s = 1.70158f;
            end -= start;
            value = (value) - 1;
            return end * ((value) * value * ((s + 1) * value + s) + 1) + start;
        }

        public static float EaseInOutBack(float start, float end, float value)
        {
            float s = 1.70158f;
            end -= start;
            value /= .5f;
            if ((value) < 1)
            {
                s *= (1.525f);
                return end * 0.5f * (value * value * (((s) + 1) * value - s)) + start;
            }
            value -= 2;
            s *= (1.525f);
            return end * 0.5f * ((value) * value * (((s) + 1) * value + s) + 2) + start;
        }

        public static float EaseInElastic(float start, float end, float value)
        {
            end -= start;

            float d = 1f;
            float p = d * .3f;
            float s;
            float a = 0;

            if (value == 0) return start;

            if ((value /= d) == 1) return start + end;

            if (a == 0f || a < Mathf.Abs(end))
            {
                a = end;
                s = p / 4;
            }
            else
            {
                s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
            }

            return -(a * Mathf.Pow(2, 10 * (value -= 1)) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p)) + start;
        }

        public static float EaseOutElastic(float start, float end, float value)
        {
            end -= start;

            float d = 1f;
            float p = d * .3f;
            float s;
            float a = 0;

            if (value == 0) return start;

            if ((value /= d) == 1) return start + end;

            if (a == 0f || a < Mathf.Abs(end))
            {
                a = end;
                s = p * 0.25f;
            }
            else
            {
                s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
            }

            return (a * Mathf.Pow(2, -10 * value) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p) + end + start);
        }

        public static float EaseInOutElastic(float start, float end, float value)
        {
            end -= start;

            float d = 1f;
            float p = d * .3f;
            float s;
            float a = 0;

            if (value == 0) return start;

            if ((value /= d * 0.5f) == 2) return start + end;

            if (a == 0f || a < Mathf.Abs(end))
            {
                a = end;
                s = p / 4;
            }
            else
            {
                s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
            }

            if (value < 1) return -0.5f * (a * Mathf.Pow(2, 10 * (value -= 1)) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p)) + start;
            return a * Mathf.Pow(2, -10 * (value -= 1)) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p) * 0.5f + end + start;
        }
        
        public static float SmoothStart1(float start, float end, float value)
        {
            return Mathf.Lerp(start, end, SmoothStart1(value));
        }

        public static float SmoothStart2(float start, float end, float value)
        {
            return Mathf.Lerp(start, end, SmoothStart2(value));
        }

        public static float SmoothStart3(float start, float end, float value)
        {
            return Mathf.Lerp(start, end, SmoothStart3(value));
        }

        public static float SmoothStart4(float start, float end, float value)
        {
            return Mathf.Lerp(start, end, SmoothStart4(value));
        }

        public static float SmoothStart5(float start, float end, float value)
        {
            return Mathf.Lerp(start, end, SmoothStart5(value));
        }

        public static float SmoothStart6(float start, float end, float value)
        {
            return Mathf.Lerp(start, end, SmoothStart6(value));
        }

        public static float SmoothStop1(float start, float end, float value)
        {
            return Mathf.Lerp(start, end, SmoothStop1(value));
        }

        public static float SmoothStop2(float start, float end, float value)
        {
            return Mathf.Lerp(start, end, SmoothStop2(value));
        }

        public static float SmoothStop3(float start, float end, float value)
        {
            return Mathf.Lerp(start, end, SmoothStop3(value));
        }

        public static float SmoothStop4(float start, float end, float value)
        {
            return Mathf.Lerp(start, end, SmoothStop4(value));
        }

        public static float SmoothStop5(float start, float end, float value)
        {
            return Mathf.Lerp(start, end, SmoothStop5(value));
        }

        public static float SmoothStop6(float start, float end, float value)
        {
            return Mathf.Lerp(start, end, SmoothStop6(value));
        }

        public static float SmoothStartAndStop1(float start, float end, float value)
        {
            float smoothStart = SmoothStart1(value);
            float smoothStop = SmoothStop1(value);
            return Mathf.Lerp(start, end, Mathf.Lerp(smoothStart, smoothStop, value));
        }

        public static float SmoothStartAndStop2(float start, float end, float value)
        {
            float smoothStart = SmoothStart2(value);
            float smoothStop = SmoothStop2(value);
            return Mathf.Lerp(start, end, Mathf.Lerp(smoothStart, smoothStop, value));
        }

        public static float SmoothStartAndStop3(float start, float end, float value)
        {
            float smoothStart = SmoothStart3(value);
            float smoothStop = SmoothStop3(value);
            return Mathf.Lerp(start, end, Mathf.Lerp(smoothStart, smoothStop, value));
        }

        public static float SmoothStartAndStop4(float start, float end, float value)
        {
            float smoothStart = SmoothStart4(value);
            float smoothStop = SmoothStop4(value);
            return Mathf.Lerp(start, end, Mathf.Lerp(smoothStart, smoothStop, value));
        }

        public static float SmoothStartAndStop5(float start, float end, float value)
        {
            float smoothStart = SmoothStart5(value);
            float smoothStop = SmoothStop5(value);
            return Mathf.Lerp(start, end, Mathf.Lerp(smoothStart, smoothStop, value));
        }

        public static float SmoothStartAndStop6(float start, float end, float value)
        {
            float smoothStart = SmoothStart6(value) * SmoothStart6(value);
            float smoothStop = SmoothStop6(value) * SmoothStop6(value);
            return Mathf.Lerp(start, end, Mathf.Lerp(smoothStart, smoothStop, value));
        }

        //
        // These are derived functions that the motor can use to get the speed at a specific time.
        //
        // The easing functions all work with a normalized time (0 to 1) and the returned value here
        // reflects that. Values returned here should be divided by the actual time.
        //
        // TODO: These functions have not had the testing they deserve. If there is odd behavior around
        //       dash speeds then this would be the first place I'd look.

        public static float LinearD(float start, float end, float value)
        {
            return end - start;
        }

        public static float EaseInQuadD(float start, float end, float value)
        {
            return 2f * (end - start) * value;
        }

        public static float EaseOutQuadD(float start, float end, float value)
        {
            end -= start;
            return -end * value - end * (value - 2);
        }

        public static float EaseInOutQuadD(float start, float end, float value)
        {
            value /= .5f;
            end -= start;

            if (value < 1)
            {
                return end * value;
            }

            value--;

            return end * (1 - value);
        }

        public static float EaseInCubicD(float start, float end, float value)
        {
            return 3f * (end - start) * value * value;
        }

        public static float EaseOutCubicD(float start, float end, float value)
        {
            value--;
            end -= start;
            return 3f * end * value * value;
        }

        public static float EaseInOutCubicD(float start, float end, float value)
        {
            value /= .5f;
            end -= start;

            if (value < 1)
            {
                return (3f / 2f) * end * value * value;
            }

            value -= 2;

            return (3f / 2f) * end * value * value;
        }

        public static float EaseInQuartD(float start, float end, float value)
        {
            return 4f * (end - start) * value * value * value;
        }

        public static float EaseOutQuartD(float start, float end, float value)
        {
            value--;
            end -= start;
            return -4f * end * value * value * value;
        }

        public static float EaseInOutQuartD(float start, float end, float value)
        {
            value /= .5f;
            end -= start;

            if (value < 1)
            {
                return 2f * end * value * value * value;
            }

            value -= 2;

            return -2f * end * value * value * value;
        }

        public static float EaseInQuintD(float start, float end, float value)
        {
            return 5f * (end - start) * value * value * value * value;
        }

        public static float EaseOutQuintD(float start, float end, float value)
        {
            value--;
            end -= start;
            return 5f * end * value * value * value * value;
        }

        public static float EaseInOutQuintD(float start, float end, float value)
        {
            value /= .5f;
            end -= start;

            if (value < 1)
            {
                return (5f / 2f) * end * value * value * value * value;
            }

            value -= 2;

            return (5f / 2f) * end * value * value * value * value;
        }

        public static float EaseInSineD(float start, float end, float value)
        {
            return (end - start) * 0.5f * Mathf.PI * Mathf.Sin(0.5f * Mathf.PI * value);
        }

        public static float EaseOutSineD(float start, float end, float value)
        {
            end -= start;
            return (Mathf.PI * 0.5f) * end * Mathf.Cos(value * (Mathf.PI * 0.5f));
        }

        public static float EaseInOutSineD(float start, float end, float value)
        {
            end -= start;
            return end * 0.5f * Mathf.PI * Mathf.Sin(Mathf.PI * value);
        }
        public static float EaseInExpoD(float start, float end, float value)
        {
            return (10f * NATURAL_LOG_OF_2 * (end - start) * Mathf.Pow(2f, 10f * (value - 1)));
        }

        public static float EaseOutExpoD(float start, float end, float value)
        {
            end -= start;
            return 5f * NATURAL_LOG_OF_2 * end * Mathf.Pow(2f, 1f - 10f * value);
        }

        public static float EaseInOutExpoD(float start, float end, float value)
        {
            value /= .5f;
            end -= start;

            if (value < 1)
            {
                return 5f * NATURAL_LOG_OF_2 * end * Mathf.Pow(2f, 10f * (value - 1));
            }

            value--;

            return (5f * NATURAL_LOG_OF_2 * end) / (Mathf.Pow(2f, 10f * value));
        }

        public static float EaseInCircD(float start, float end, float value)
        {
            return ((end - start) * value) / Mathf.Sqrt(1f - value * value);
        }

        public static float EaseOutCircD(float start, float end, float value)
        {
            value--;
            end -= start;
            return (-end * value) / Mathf.Sqrt(1f - value * value);
        }

        public static float EaseInOutCircD(float start, float end, float value)
        {
            value /= .5f;
            end -= start;

            if (value < 1)
            {
                return (end * value) / (2f * Mathf.Sqrt(1f - value * value));
            }

            value -= 2;

            return (-end * value) / (2f * Mathf.Sqrt(1f - value * value));
        }

        public static float EaseInBounceD(float start, float end, float value)
        {
            end -= start;
            float d = 1f;

            return EaseOutBounceD(0, end, d - value);
        }

        public static float EaseOutBounceD(float start, float end, float value)
        {
            value /= 1f;
            end -= start;

            if (value < (1 / 2.75f))
            {
                return 2f * end * 7.5625f * value;
            }
            else if (value < (2 / 2.75f))
            {
                value -= (1.5f / 2.75f);
                return 2f * end * 7.5625f * value;
            }
            else if (value < (2.5 / 2.75))
            {
                value -= (2.25f / 2.75f);
                return 2f * end * 7.5625f * value;
            }
            else
            {
                value -= (2.625f / 2.75f);
                return 2f * end * 7.5625f * value;
            }
        }

        public static float EaseInOutBounceD(float start, float end, float value)
        {
            end -= start;
            float d = 1f;

            if (value < d * 0.5f)
            {
                return EaseInBounceD(0, end, value * 2) * 0.5f;
            }
            else
            {
                return EaseOutBounceD(0, end, value * 2 - d) * 0.5f;
            }
        }

        public static float EaseInBackD(float start, float end, float value)
        {
            float s = 1.70158f;

            return 3f * (s + 1f) * (end - start) * value * value - 2f * s * (end - start) * value;
        }

        public static float EaseOutBackD(float start, float end, float value)
        {
            float s = 1.70158f;
            end -= start;
            value = (value) - 1;

            return end * ((s + 1f) * value * value + 2f * value * ((s + 1f) * value + s));
        }

        public static float EaseInOutBackD(float start, float end, float value)
        {
            float s = 1.70158f;
            end -= start;
            value /= .5f;

            if ((value) < 1)
            {
                s *= (1.525f);
                return 0.5f * end * (s + 1) * value * value + end * value * ((s + 1f) * value - s);
            }

            value -= 2;
            s *= (1.525f);
            return 0.5f * end * ((s + 1) * value * value + 2f * value * ((s + 1f) * value + s));
        }

        public static float EaseInElasticD(float start, float end, float value)
        {
            return EaseOutElasticD(start, end, 1f - value);
        }

        public static float EaseOutElasticD(float start, float end, float value)
        {
            end -= start;

            float d = 1f;
            float p = d * .3f;
            float s;
            float a = 0;

            if (a == 0f || a < Mathf.Abs(end))
            {
                a = end;
                s = p * 0.25f;
            }
            else
            {
                s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
            }

            return (a * Mathf.PI * d * Mathf.Pow(2f, 1f - 10f * value) *
                    Mathf.Cos((2f * Mathf.PI * (d * value - s)) / p)) / p - 5f * NATURAL_LOG_OF_2 * a *
                Mathf.Pow(2f, 1f - 10f * value) * Mathf.Sin((2f * Mathf.PI * (d * value - s)) / p);
        }

        public static float EaseInOutElasticD(float start, float end, float value)
        {
            end -= start;

            float d = 1f;
            float p = d * .3f;
            float s;
            float a = 0;

            if (a == 0f || a < Mathf.Abs(end))
            {
                a = end;
                s = p / 4;
            }
            else
            {
                s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
            }

            if (value < 1)
            {
                value -= 1;

                return -5f * NATURAL_LOG_OF_2 * a * Mathf.Pow(2f, 10f * value) * Mathf.Sin(2 * Mathf.PI * (d * value - 2f) / p) -
                       a * Mathf.PI * d * Mathf.Pow(2f, 10f * value) * Mathf.Cos(2 * Mathf.PI * (d * value - s) / p) / p;
            }

            value -= 1;

            return a * Mathf.PI * d * Mathf.Cos(2f * Mathf.PI * (d * value - s) / p) / (p * Mathf.Pow(2f, 10f * value)) -
                   5f * NATURAL_LOG_OF_2 * a * Mathf.Sin(2f * Mathf.PI * (d * value - s) / p) / (Mathf.Pow(2f, 10f * value));
        }

        public static float SpringD(float start, float end, float value)
        {
            value = Mathf.Clamp01(value);
            end -= start;

            // Damn... Thanks http://www.derivative-calculator.net/
            // TODO: And it's a little bit wrong
            return end * (6f * (1f - value) / 5f + 1f) * (-2.2f * Mathf.Pow(1f - value, 1.2f) *
                       Mathf.Sin(Mathf.PI * value * (2.5f * value * value * value + 0.2f)) + Mathf.Pow(1f - value, 2.2f) *
                       (Mathf.PI * (2.5f * value * value * value + 0.2f) + 7.5f * Mathf.PI * value * value * value) *
                       Mathf.Cos(Mathf.PI * value * (2.5f * value * value * value + 0.2f)) + 1f) -
                   6f * end * (Mathf.Pow(1 - value, 2.2f) * Mathf.Sin(Mathf.PI * value * (2.5f * value * value * value + 0.2f)) + value
                       / 5f);

        }

        public delegate float Function(float s, float e, float v);

        /// <summary>
        /// Returns the function associated to the easingFunction enum. This value returned should be cached as it allocates memory
        /// to return.
        /// </summary>
        /// <param name="easingFunction">The enum associated with the easing function.</param>
        /// <returns>The easing function</returns>
        public static Function GetEasingFunction(Ease easingFunction)
        {
            switch (easingFunction)
            {
                case Ease.EaseInQuad:
                    return EaseInQuad;
                case Ease.EaseOutQuad:
                    return EaseOutQuad;
                case Ease.EaseInOutQuad:
                    return EaseInOutQuad;
                case Ease.EaseInCubic:
                    return EaseInCubic;
                case Ease.EaseOutCubic:
                    return EaseOutCubic;
                case Ease.EaseInOutCubic:
                    return EaseInOutCubic;
                case Ease.EaseInQuart:
                    return EaseInQuart;
                case Ease.EaseOutQuart:
                    return EaseOutQuart;
                case Ease.EaseInOutQuart:
                    return EaseInOutQuart;
                case Ease.EaseInQuint:
                    return EaseInQuint;
                case Ease.EaseOutQuint:
                    return EaseOutQuint;
                case Ease.EaseInOutQuint:
                    return EaseInOutQuint;
                case Ease.EaseInSine:
                    return EaseInSine;
                case Ease.EaseOutSine:
                    return EaseOutSine;
                case Ease.EaseInOutSine:
                    return EaseInOutSine;
                case Ease.EaseInExpo:
                    return EaseInExpo;
                case Ease.EaseOutExpo:
                    return EaseOutExpo;
                case Ease.EaseInOutExpo:
                    return EaseInOutExpo;
                case Ease.EaseInCirc:
                    return EaseInCirc;
                case Ease.EaseOutCirc:
                    return EaseOutCirc;
                case Ease.EaseInOutCirc:
                    return EaseInOutCirc;
                case Ease.Linear:
                    return Linear;
                case Ease.Spring:
                    return Spring;
                case Ease.EaseInBounce:
                    return EaseInBounce;
                case Ease.EaseOutBounce:
                    return EaseOutBounce;
                case Ease.EaseInOutBounce:
                    return EaseInOutBounce;
                case Ease.EaseInBack:
                    return EaseInBack;
                case Ease.EaseOutBack:
                    return EaseOutBack;
                case Ease.EaseInOutBack:
                    return EaseInOutBack;
                case Ease.EaseInElastic:
                    return EaseInElastic;
                case Ease.EaseOutElastic:
                    return EaseOutElastic;
                case Ease.EaseInOutElastic:
                    return EaseInOutElastic;
                case Ease.EaseSmoothStart1:
                    return SmoothStart1;
                case Ease.EaseSmoothStart2:
                    return SmoothStart2;
                case Ease.EaseSmoothStart3:
                    return SmoothStart3;
                case Ease.EaseSmoothStart4:
                    return SmoothStart4;
                case Ease.EaseSmoothStart5:
                    return SmoothStart5;
                case Ease.EaseSmoothStart6:
                    return SmoothStart6;
                case Ease.EaseSmoothStop1:
                    return SmoothStop1;
                case Ease.EaseSmoothStop2:
                    return SmoothStop2;
                case Ease.EaseSmoothStop3:
                    return SmoothStop3;
                case Ease.EaseSmoothStop4:
                    return SmoothStop4;
                case Ease.EaseSmoothStop5:
                    return SmoothStop5;
                case Ease.EaseSmoothStop6:
                    return SmoothStop6;
                case Ease.EaseSmoothStartAndStop1:
                    return SmoothStartAndStop1;
                case Ease.EaseSmoothStartAndStop2:
                    return SmoothStartAndStop2;
                case Ease.EaseSmoothStartAndStop3:
                    return SmoothStartAndStop3;
                case Ease.EaseSmoothStartAndStop4:
                    return SmoothStartAndStop4;
                case Ease.EaseSmoothStartAndStop5:
                    return SmoothStartAndStop5;
                case Ease.EaseSmoothStartAndStop6:
                    return SmoothStartAndStop6;
                default:
                    Debug.LogError(easingFunction + " is not implemented");
                    return Linear;
            }
        }

        /// <summary>
        /// Gets the derivative function of the appropriate easing function. If you use an easing function for position then this
        /// function can get you the speed at a given time (normalized).
        /// </summary>
        /// <param name="easingFunction"></param>
        /// <returns>The derivative function</returns>
        public static Function GetEasingFunctionDerivative(Ease easingFunction)
        {
            if (easingFunction == Ease.EaseInQuad)
            {
                return EaseInQuadD;
            }

            if (easingFunction == Ease.EaseOutQuad)
            {
                return EaseOutQuadD;
            }

            if (easingFunction == Ease.EaseInOutQuad)
            {
                return EaseInOutQuadD;
            }

            if (easingFunction == Ease.EaseInCubic)
            {
                return EaseInCubicD;
            }

            if (easingFunction == Ease.EaseOutCubic)
            {
                return EaseOutCubicD;
            }

            if (easingFunction == Ease.EaseInOutCubic)
            {
                return EaseInOutCubicD;
            }

            if (easingFunction == Ease.EaseInQuart)
            {
                return EaseInQuartD;
            }

            if (easingFunction == Ease.EaseOutQuart)
            {
                return EaseOutQuartD;
            }

            if (easingFunction == Ease.EaseInOutQuart)
            {
                return EaseInOutQuartD;
            }

            if (easingFunction == Ease.EaseInQuint)
            {
                return EaseInQuintD;
            }

            if (easingFunction == Ease.EaseOutQuint)
            {
                return EaseOutQuintD;
            }

            if (easingFunction == Ease.EaseInOutQuint)
            {
                return EaseInOutQuintD;
            }

            if (easingFunction == Ease.EaseInSine)
            {
                return EaseInSineD;
            }

            if (easingFunction == Ease.EaseOutSine)
            {
                return EaseOutSineD;
            }

            if (easingFunction == Ease.EaseInOutSine)
            {
                return EaseInOutSineD;
            }

            if (easingFunction == Ease.EaseInExpo)
            {
                return EaseInExpoD;
            }

            if (easingFunction == Ease.EaseOutExpo)
            {
                return EaseOutExpoD;
            }

            if (easingFunction == Ease.EaseInOutExpo)
            {
                return EaseInOutExpoD;
            }

            if (easingFunction == Ease.EaseInCirc)
            {
                return EaseInCircD;
            }

            if (easingFunction == Ease.EaseOutCirc)
            {
                return EaseOutCircD;
            }

            if (easingFunction == Ease.EaseInOutCirc)
            {
                return EaseInOutCircD;
            }

            if (easingFunction == Ease.Linear)
            {
                return LinearD;
            }

            if (easingFunction == Ease.Spring)
            {
                return SpringD;
            }

            if (easingFunction == Ease.EaseInBounce)
            {
                return EaseInBounceD;
            }

            if (easingFunction == Ease.EaseOutBounce)
            {
                return EaseOutBounceD;
            }

            if (easingFunction == Ease.EaseInOutBounce)
            {
                return EaseInOutBounceD;
            }

            if (easingFunction == Ease.EaseInBack)
            {
                return EaseInBackD;
            }

            if (easingFunction == Ease.EaseOutBack)
            {
                return EaseOutBackD;
            }

            if (easingFunction == Ease.EaseInOutBack)
            {
                return EaseInOutBackD;
            }

            if (easingFunction == Ease.EaseInElastic)
            {
                return EaseInElasticD;
            }

            if (easingFunction == Ease.EaseOutElastic)
            {
                return EaseOutElasticD;
            }

            if (easingFunction == Ease.EaseInOutElastic)
            {
                return EaseInOutElasticD;
            }

            return null;
        }
    }
}