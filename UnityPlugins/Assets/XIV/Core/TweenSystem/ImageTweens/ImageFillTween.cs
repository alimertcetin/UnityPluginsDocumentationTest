using UnityEngine;
using UnityEngine.UI;
using XIV.Core.TweenSystem.Drivers;

namespace XIV.Core.TweenSystem.ImageTweens
{
    internal sealed class ImageFillTween : TweenDriver<float, Image>
    {
        protected override void OnUpdate(float easedTime)
        {
            component.fillAmount = Mathf.Lerp(startValue, endValue, easedTime);
        }
    }
}