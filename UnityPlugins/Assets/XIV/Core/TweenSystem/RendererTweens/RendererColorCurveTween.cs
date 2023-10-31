using UnityEngine;
using XIV.Core.TweenSystem.Drivers;
using XIV.Core.XIVMath;

namespace XIV.Core.TweenSystem.RendererTweens
{
    internal sealed class RendererColorCurveTween : CurveTweenDriver<Color, Renderer>
    {
        protected override void OnUpdate(float easedTime)
        {
            var color = BezierMath4D.GetPoint(startValue[0], startValue[1], startValue[2], startValue[3], easedTime);
            component.material.color = color;
        }
    }
}