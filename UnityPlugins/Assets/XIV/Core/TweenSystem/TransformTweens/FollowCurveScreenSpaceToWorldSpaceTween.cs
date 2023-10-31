using UnityEngine;
using XIV.Core.TweenSystem.Drivers;
using XIV.Core.XIVMath;

namespace XIV.Core.TweenSystem.TransformTweens
{
    internal sealed class FollowCurveScreenSpaceToWorldSpaceTween : CurveTweenDriver<Vector3, Transform>
    {
        public Camera cam;
        
        protected override void OnUpdate(float easedTime)
        {
            var point = cam.ScreenToWorldPoint(BezierMath.GetPoint(startValue[0], startValue[1], startValue[2], startValue[3], easedTime));
            component.position = point;
        }
    }
}