using UnityEngine;
using XIV.Core.TweenSystem.Drivers;

namespace XIV.Core.TweenSystem.RendererTweens
{
    internal sealed class RendererColorTween : TweenDriver<Color, Renderer>
    {
        protected override void OnUpdate(float easedTime)
        {
            component.material.color = Color.Lerp(startValue, endValue, easedTime);
        }
    }
}