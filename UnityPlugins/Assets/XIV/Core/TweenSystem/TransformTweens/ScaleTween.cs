using UnityEngine;
using XIV.Core.TweenSystem.Drivers;

namespace XIV.Core.TweenSystem.TransformTweens
{
    internal sealed class ScaleTween : TweenDriver<Vector3, Transform>
    {
        protected override void OnUpdate(float normalizedEasedTime)
        {
            component.localScale = Vector3.Lerp(startValue, endValue, normalizedEasedTime);
        }
    }
}