using UnityEngine;

namespace XIV.DataTypes.ValueSOs
{
    [System.Serializable]
    public class ValueReference<T>
    {
        [SerializeField] ValueSO<T> valueSO;
        [SerializeField] T constant;
        [SerializeField] bool useConstant;
        
        public T Value
        {
            get => useConstant ? constant : valueSO.Value;
            set
            {
                if (useConstant) constant = value;
                else valueSO.Value = value;
            }
        }
    }
}