using UnityEngine;
using XIV.Core.Extensions;
using XIV.Core.TweenSystem.Drivers;

namespace XIV.Core.TweenSystem.TransformTweens
{
    internal sealed class ScaleTweenY : TweenDriver<float, Transform>
    {
        protected override void OnUpdate(float normalizedEasedTime)
        {
            component.localScale = component.localScale.SetY(Mathf.Lerp(startValue, endValue, normalizedEasedTime));
        }
    }
}