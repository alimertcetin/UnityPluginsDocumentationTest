using System;
using UnityEngine;
using XIV.Core.Collections;

namespace XIV.Core.TweenSystem
{
    public sealed class TweenTimeline
    {
        /// <summary>
        /// Equivalent of <see cref="UnityEngine.Time.deltaTime"/>
        /// </summary>
        public static readonly Func<float> defaulDeltaTimeFunc;
        /// <summary>
        /// Equivalent of <see cref="UnityEngine.Time.unscaledDeltaTime"/>
        /// </summary>
        public static readonly Func<float> unscaledDeltaTimeFunc;
        // /// <summary>
        // /// Equivalent of <see cref="UnityEngine.Time.fixedDeltaTime"/>
        // /// </summary>
        // public static readonly Func<float> fixedDeltaTimeFunc;
        // /// <summary>
        // /// Equivalent of <see cref="UnityEngine.Time.fixedUnscaledDeltaTime"/>
        // /// </summary>
        // public static readonly Func<float> fixedUnscaledDeltaTimeFunc;
        
        DynamicArray<ITween> tweens = new DynamicArray<ITween>(2);
        
        Func<float> dtFunc;

        static TweenTimeline()
        {
            defaulDeltaTimeFunc = () => Time.deltaTime;
            unscaledDeltaTimeFunc = () => Time.unscaledDeltaTime;
            // fixedDeltaTimeFunc = () => Time.fixedDeltaTime;
            // fixedUnscaledDeltaTimeFunc = () => Time.fixedUnscaledDeltaTime;
        }

        public void AddTween(ITween tween)
        {
            tweens.Add() = tween;
        }

        /// <summary>
        /// Use static readonly member Funcs to not generate garbage.
        /// <example>
        /// <see cref="defaulDeltaTimeFunc"/>
        /// <code>SetDeltaTimeFunc(TweenTimeline.defaulDeltaTimeFunc)</code>
        /// </example>
        /// </summary>
        public void SetDeltaTimeFunc(Func<float> func)
        {
            dtFunc = func ?? dtFunc;
        }

        public void ForceComplete()
        {
            Update(float.MaxValue);
        }

        public void Update()
        {
            Update(dtFunc.Invoke());
        }

        void Update(float deltaTime)
        {
            int count = tweens.Count;
            for (int i = 0; i < count; i++)
            {
                ref var tween = ref tweens[i];
                tween.Update(deltaTime);
                
                if (tween.IsDone() == false) continue;
                tween.Complete();
                XIVTweenSystem.ReleaseTween(tween);
                
                tweens.RemoveAt(i);
                i -= 1;
                count -= 1;
            }
        }

        public bool IsDone()
        {
            for (var i = 0; i < tweens.Count; i++)
            {
                if (tweens[i].IsDone() == false) return false;
            }

            return true;
        }

        public void Cancel()
        {
            int count = tweens.Count;
            for (var i = 0; i < count; i++)
            {
                tweens[i].Cancel();
            }
        }

        public void Clear()
        {
            int count = tweens.Count;
            for (int i = 0; i < count; i++)
            {
                XIVTweenSystem.ReleaseTween(tweens[i]);
            }
            
            tweens.Clear();
            dtFunc = default;
        }
    }
}