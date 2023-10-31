using System.Collections.Generic;
using UnityEngine;
using XIV.PoolSystem;

namespace XIV.Core.TweenSystem
{
    internal static class XIVTweenSystem
    {
        class TweenHelperMono : MonoBehaviour
        {
            void Update()
            {
                int count = XIVTweenSystem.tweenTimelines.Count;
                for (int i = count - 1; i >= 0; i--)
                {
                    List<TweenTimeline> timelines = XIVTweenSystem.tweenTimelines[i];
                    TweenTimeline timeline = timelines[0];
                    timeline.Update();
                    if (timeline.IsDone())
                    {
                        timelines.RemoveAt(0);
                        timeline.Clear();
                        XIVTweenSystem.ReleaseItem(timeline);
                    }

                    if (timelines.Count == 0)
                    {
                        XIVTweenSystem.tweenTimelines.RemoveAt(i);
                        XIVTweenSystem.instanceIDLookup.RemoveAt(i);
                        timelines.Clear();
                        XIVTweenSystem.ReleaseItem(timelines);
                    }
                }
            }

            void OnDestroy()
            {
                XIVTweenSystem.tweenHelperMono = null;
                XIVTweenSystem.Clear();
            }
        }

        static List<List<TweenTimeline>> tweenTimelines = new List<List<TweenTimeline>>(8);
        static List<int> instanceIDLookup = new List<int>(8);
        static TweenHelperMono tweenHelperMono;

        internal static T GetTween<T>() where T : ITween
        {
            return GetItem<T>();
        }

        internal static TweenTimeline GetTimeline(params ITween[] tweens)
        {
            var timeline = GetItem<TweenTimeline>();
            timeline.SetDeltaTimeFunc(TweenTimeline.defaulDeltaTimeFunc);

            int length = tweens.Length;
            for (int i = 0; i < length; i++)
            {
                timeline.AddTween(tweens[i]);
            }

            return timeline;
        }

        internal static void ReleaseTween(ITween tween)
        {
            ReleaseItem(tween);
        }

        internal static void AddTween(int instanceID, TweenTimeline timeline)
        {
            if (tweenHelperMono is null)
            {
                tweenHelperMono = new GameObject("XIV-TweenSystem-Helper").AddComponent<TweenHelperMono>();
                Object.DontDestroyOnLoad(tweenHelperMono);
            }

            GetTweenTimelines(instanceID).Add(timeline);
        }

        internal static void CancelTween(int instanceID, bool forceComplete = true)
        {
            var index = instanceIDLookup.IndexOf(instanceID);
            if (index < 0) return;

            List<TweenTimeline> timelines = tweenTimelines[index];
            
            int timelineCount = timelines.Count;
            for (int i = 0; i < timelineCount; i++)
            {
                TweenTimeline timeline = timelines[i];
                if (forceComplete) timeline.ForceComplete();
                else timeline.Cancel();
                
                timeline.Clear();
            }
            
            timelines.Clear();
            ReleaseItem(timelines);
            
            tweenTimelines.RemoveAt(index);
            instanceIDLookup.RemoveAt(index);
        }

        internal static bool HasTween(int instanceID)
        {
            return instanceIDLookup.IndexOf(instanceID) > -1;
        }

        static List<TweenTimeline> GetTweenTimelines(int instanceID)
        {
            var index = instanceIDLookup.IndexOf(instanceID);
            if (index > -1) return tweenTimelines[index];

            List<TweenTimeline> timelines = GetItem<List<TweenTimeline>>();
            instanceIDLookup.Add(instanceID);
            tweenTimelines.Add(timelines);
            return timelines;
        }

        static T GetItem<T>()
        {
            return XIVPoolSystem.GetItem<T>();
        }

        static void ReleaseItem<T>(T item)
        {
            XIVPoolSystem.ReleaseItem(item);
        }

        static void Clear()
        {
            instanceIDLookup.Clear();
            tweenTimelines.Clear();
        }
    }
}
