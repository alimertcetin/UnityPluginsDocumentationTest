using System;
using UnityEditor;
using UnityEngine;

namespace XIV.UpgradeSystem.Integration
{
    public abstract class UpgradeSO : ScriptableObject
    {
#if UNITY_EDITOR
        /// <summary>
        /// Make sure overriden method is editor only
        /// </summary>
        protected abstract void GetName(out string name, out int instanceID);
        // protected override void GetName(out string name, out int instanceID)
        // {
        //     name = this.title + "_UpgradeDB";
        //     instanceID = this.GetInstanceID();
        // }
#endif
    }
    
    public abstract class UpgradeSO<T> : UpgradeSO, IUpgrade<T> where T : Enum
    {
        [SerializeField] int level;
        [SerializeField] float power;
        [SerializeField] T type;
        public int upgradeLevel => level;
        public T upgradeType => type;
        public float upgradePower => power;
        
        public abstract bool IsBetterThan(IUpgrade<T> other);
        public abstract bool Equals(IUpgrade<T> other);
    }
}