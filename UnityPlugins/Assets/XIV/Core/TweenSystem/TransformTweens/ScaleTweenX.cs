using UnityEngine;
using XIV.Core.Extensions;
using XIV.Core.TweenSystem.Drivers;

namespace XIV.Core.TweenSystem.TransformTweens
{
    internal sealed class ScaleTweenX : TweenDriver<float, Transform>
    {
        protected override void OnUpdate(float normalizedEasedTime)
        {
            component.localScale = component.localScale.SetX(Mathf.Lerp(startValue, endValue, normalizedEasedTime));
        }
    }
}