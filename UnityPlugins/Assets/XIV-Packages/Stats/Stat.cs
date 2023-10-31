using UnityEngine;

namespace XIV.Stats
{
    [System.Serializable]
    public struct Stat
    {
        // TODO : Try [field : SerializedField] public float variable { get; set; }
        public StatTypeSO StatType => statType;
        public float Total => total;
        public float Current => current;
        public float NormalizedValue => current / total;
        
        [SerializeField] StatTypeSO statType;
        [SerializeField] float total;
        [SerializeField] float current;

        public bool SetStat(Stat newValue)
        {
            SetTotal(newValue.total);
            SetCurrent(newValue.current);
            return true;
        }

        public bool SetTotal(float newValue)
        {
            total = newValue;
            SetCurrent(current);
            return true;
        }

        public bool SetCurrent(float newValue)
        {
            current = newValue > total ? total : newValue;
            return true;
        }
        
        public static Stat operator +(Stat a, Stat b)
        {
            a.total += b.total;
            a.SetCurrent(a.current + b.current);
            return a;
        }
        
        public static Stat operator -(Stat a, Stat b)
        {
            a.total -= b.total;
            a.SetCurrent(a.current - b.current);
            return a;
        }
    }
}