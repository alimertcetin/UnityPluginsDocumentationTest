using UnityEngine;
using XIV.Core.Extensions;
using XIV.Core.TweenSystem.Drivers;

namespace XIV.Core.TweenSystem.TransformTweens
{
    internal sealed class MoveTweenX : TweenDriver<float, Transform>
    {
        protected override void OnUpdate(float normalizedEasedTime)
        {
            component.position = component.position.SetX(Mathf.Lerp(startValue, endValue, normalizedEasedTime));
        }
    }
}