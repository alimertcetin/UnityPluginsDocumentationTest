using System;
using System.Collections.Generic;

namespace XIV.PoolSystem
{
    public class XIVPool<T> : IPool<T>
    {
        public Type StoredType { get; }

        readonly Func<T> createFunc;
        readonly Stack<T> poolables;

        Action<T> onGetItem;
        Action<T> onReleaseItem;

        public XIVPool(Func<T> createFunc) : this(2, createFunc)
        {
            
        }
        
        public XIVPool(int initialSize, Func<T> createFunc)
        {
            StoredType = typeof(T);
            this.createFunc = createFunc;
            initialSize = initialSize <= 0 ? 2 : initialSize;
            poolables = new Stack<T>(initialSize);
            for (int i = 0; i < initialSize; i++)
            {
                var item = createFunc.Invoke();
                poolables.Push(item);
            }
        }

        public void SetOnGetItem(Action<T> onGetItem)
        {
            this.onGetItem = onGetItem;
        }

        public void SetOnReleaseItem(Action<T> onReleaseItem)
        {
            this.onReleaseItem = onReleaseItem;
        }

        public T GetItem()
        {
            T item;
            if (poolables.Count > 0)
            {
                item = poolables.Pop();
                onGetItem?.Invoke(item);
                return item;
            }

            item = createFunc.Invoke();
            onGetItem?.Invoke(item);
            return item;
        }
        
        public void Release(T item)
        {
            poolables.Push(item);
            onReleaseItem?.Invoke(item);
        }
        
        bool IPool.Release<T1>(T1 item)
        {
            if (item is not T t) return false;
            Release(t);
            return true;
        }
        
    }
}