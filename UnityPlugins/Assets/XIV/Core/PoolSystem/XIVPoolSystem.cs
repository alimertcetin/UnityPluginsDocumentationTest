using System;
using System.Collections.Generic;

namespace XIV.PoolSystem
{
    public static class XIVPoolSystem
    {
        static Dictionary<Type, IPool> pools = new Dictionary<Type, IPool>();

        [UnityEngine.RuntimeInitializeOnLoadMethod]
        static void Init()
        {
            pools.Clear();
        }

        public static void SetOnGetAction<T>(Action<T> onGet)
        {
            GetPool<T>().SetOnGetItem(onGet);
        }

        public static void SetOnReleaseAction<T>(Action<T> onRelease)
        {
            GetPool<T>().SetOnReleaseItem(onRelease);
        }

        public static T GetItem<T>()
        {
            return GetPool<T>().GetItem();
        }

        public static void ReleaseItem<T>(T item)
        {
            var type = item.GetType();
#if UNITY_EDITOR
            if (HasPool(type) == false)
            {
                throw new NullReferenceException($"There is no pool for {type.Name} but you are calling {nameof(ReleaseItem)}");
            }
#endif
            pools.TryGetValue(type, out var pool);
            pool!.Release(item);
        }

        public static bool HasPool<T>() => HasPool(typeof(T));

        public static bool HasPool(Type type) => pools.ContainsKey(type);

        static XIVPool<T> GetPool<T>()
        {
            var type = typeof(T);
            if (pools.TryGetValue(type, out var p))
            {
                return (XIVPool<T>)p;
            }

            var pool = new XIVPool<T>(Activator.CreateInstance<T>);
            pools.Add(type, pool);
            return pool;
        }
    }
}