using System;
using UnityEngine;
using XIV.Core.Utils;
using XIV.PoolSystem;

namespace XIV.Core.TweenSystem.Drivers
{
    public abstract class TweenDriver<TValueType, TComponentType> : TweenDriver<TValueType> where TComponentType : Component
    {
        public TComponentType component { get; private set; }

        public TweenDriver<TValueType, TComponentType> Set(TComponentType component, TValueType startValue, TValueType endValue, float duration, EasingFunction.Function easingFunction, bool isPingPong = false, int loopCount = 0)
        {
            base.Set(startValue, endValue, duration, easingFunction, isPingPong, loopCount);
            this.component = component;
            return this;
        }

        protected override void OnComplete()
        {
            component = default;
        }

        protected override void OnCancel()
        {
            component = default;
        }
    }

    public abstract class TweenDriver<TValueType> : ITween
    {
        protected TValueType startValue;
        protected TValueType endValue;
        protected EasingFunction.Function easingFunction;
        protected Timer timer;
        bool isPingPong;
        bool reversed;
        int loopCount;

        public TweenDriver<TValueType> Set(TValueType startValue, TValueType endValue, float duration, EasingFunction.Function easingFunction, bool isPingPong = false, int loopCount = 0)
        {
            Clear(this);
            this.startValue = startValue;
            this.endValue = endValue;
            this.easingFunction = easingFunction;
            this.timer = new Timer(duration);
            this.isPingPong = isPingPong;
            this.loopCount = loopCount;
            return this;
        }

        protected abstract void OnUpdate(float easedTime);
        protected abstract void OnComplete();
        protected abstract void OnCancel();
        
        static void Clear(TweenDriver<TValueType> tweenDriver)
        {
            tweenDriver.startValue = default;
            tweenDriver.endValue = default;
            tweenDriver.timer = default;
            tweenDriver.reversed = false;
        }

        void ITween.Update(float deltaTime)
        {
            timer.Update(deltaTime);
            if (timer.NormalizedTime > 0.5f && reversed == false && isPingPong)
            {
                Reverse();
            }

            var easedTime = easingFunction.Invoke(0f, 1f, isPingPong ? timer.NormalizedTimePingPong : timer.NormalizedTime);
            
            // Thats how you should not solve your problems.
            try
            {
                OnUpdate(easedTime);
            }
            catch (Exception e)
            {
                Debug.LogWarning(e);
                timer.Update(float.MaxValue);
                loopCount = 0;
            }

            if (timer.IsDone == false) return;
            
            if (loopCount > 0)
            {
                timer.Restart();
            }
            loopCount--;
            if (isPingPong)
            {
                Reverse();
            }
        }

        void Reverse()
        {
            (startValue, endValue) = (endValue, startValue);
            reversed = !reversed;
        }

        bool ITween.IsDone() => timer.IsDone && loopCount <= 0;

        void ITween.Complete()
        {
            OnComplete();
        }

        void ITween.Cancel()
        {
            OnCancel();
        }
    }
}