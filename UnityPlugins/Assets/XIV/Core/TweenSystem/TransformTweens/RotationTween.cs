using UnityEngine;
using XIV.Core.TweenSystem.Drivers;

namespace XIV.Core.TweenSystem.TransformTweens
{
    internal sealed class RotationTween : TweenDriver<Quaternion, Transform>
    {
        protected override void OnUpdate(float normalizedEasedTime)
        {
            component.rotation = Quaternion.Lerp(startValue, endValue, normalizedEasedTime);
        }
    }
}