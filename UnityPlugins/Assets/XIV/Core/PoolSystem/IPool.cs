using System;

namespace XIV.PoolSystem
{
    public interface IPool
    {
        Type StoredType { get; }
        bool Release<T>(T item);
    }

    public interface IPool<out T> : IPool
    {
        T GetItem();
    }
}