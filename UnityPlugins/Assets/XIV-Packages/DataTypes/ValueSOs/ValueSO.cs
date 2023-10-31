using UnityEngine;

namespace XIV.DataTypes.ValueSOs
{
    public abstract class ValueSO<T> : ScriptableObject
    {
        public T Value;
    }
}