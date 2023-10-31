using UnityEngine;
using XIV.Core.TweenSystem.Drivers;

namespace XIV.Core.TweenSystem.TransformTweens
{
    internal sealed class RotationTweenZ : TweenDriver<float, Transform>
    {
        protected override void OnUpdate(float normalizedEasedTime)
        {
            component.rotation = Quaternion.AngleAxis(Mathf.Lerp(startValue, endValue, normalizedEasedTime), Vector3.forward);
        }
    }
}