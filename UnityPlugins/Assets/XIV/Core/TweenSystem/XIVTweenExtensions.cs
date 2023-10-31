using UnityEngine;

namespace XIV.Core.TweenSystem
{
    public static class XIVTweenExtensions
    {
        public static bool HasTween(this Component component)
        {
            int instanceID = component.gameObject.GetInstanceID();
            return XIVTweenSystem.HasTween(instanceID);
        }

        public static void CancelTween(this Component component, bool forceComplete = true)
        {
            int instanceID = component.gameObject.GetInstanceID();
            XIVTweenSystem.CancelTween(instanceID, forceComplete);
        }

        public static XIVTweenBuilder XIVTween(this Component component)
        {
            return XIVTweenBuilder.GetTween(component);
        }
    }
}