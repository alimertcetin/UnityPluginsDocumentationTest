using UnityEngine;

namespace XIV_Packages.InventorySystem.ScriptableObjects
{
    public abstract class ItemSO : ScriptableObject
    {
        public Sprite uiSprite;
        
        public abstract ItemBase GetItem();
    }

    public abstract class ItemSO<T> : ItemSO where T : ItemBase
    {
        [SerializeField] T item;

        public override ItemBase GetItem() => item;
    }
}