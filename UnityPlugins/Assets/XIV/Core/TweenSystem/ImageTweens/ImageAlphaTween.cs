using UnityEngine;
using UnityEngine.UI;
using XIV.Core.Extensions;
using XIV.Core.TweenSystem.Drivers;

namespace XIV.Core.TweenSystem.ImageTweens
{
    internal sealed class ImageAlphaTween : TweenDriver<float, Image>
    {
        protected override void OnUpdate(float easedTime)
        {
            component.color = component.color.SetA(Mathf.Lerp(startValue, endValue, easedTime));
        }
    }
}