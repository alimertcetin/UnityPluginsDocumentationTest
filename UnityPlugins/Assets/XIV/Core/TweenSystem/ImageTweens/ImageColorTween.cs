using UnityEngine;
using UnityEngine.UI;
using XIV.Core.TweenSystem.Drivers;

namespace XIV.Core.TweenSystem.ImageTweens
{
    internal sealed class ImageColorTween : TweenDriver<Color, Image>
    {
        protected override void OnUpdate(float easedTime)
        {
            component.color = Color.Lerp(startValue, endValue, easedTime);
        }
    }
}