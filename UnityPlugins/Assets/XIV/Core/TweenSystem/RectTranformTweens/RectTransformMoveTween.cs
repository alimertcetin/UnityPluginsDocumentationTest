using UnityEngine;
using XIV.Core.TweenSystem.Drivers;

namespace XIV.Core.TweenSystem.RectTransformTweens
{
    internal sealed class RectTransformMoveTween : TweenDriver<Vector2, RectTransform>
    {
        protected override void OnUpdate(float normalizedEasedTime)
        {
            component.anchoredPosition = Vector2.Lerp(startValue, endValue, normalizedEasedTime);
        }
    }
}