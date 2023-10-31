using UnityEngine;
using XIV.Core.Extensions;
using XIV.Core.TweenSystem.Drivers;

namespace XIV.Core.TweenSystem.TransformTweens
{
    internal sealed class MoveTweenY : TweenDriver<float, Transform>
    {
        protected override void OnUpdate(float normalizedEasedTime)
        {
            component.position = component.position.SetY(Mathf.Lerp(startValue, endValue, normalizedEasedTime));
        }
    }
}