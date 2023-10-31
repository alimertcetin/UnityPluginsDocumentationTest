using UnityEngine;

namespace XIV_Packages.InventorySystem
{
    [System.Serializable]
    public readonly struct ReadOnlyInventoryItem
    {
        public static readonly ReadOnlyInventoryItem InvalidReadonlyInventoryItem = new ReadOnlyInventoryItem(InventoryItem.InvalidInventoryItem);
        [field: SerializeField] public int Index { get; }
        [field: SerializeField] public int Quantity { get; }
        [field: SerializeField] public ItemBase Item { get; }
        public bool IsEmpty => Quantity <= 0;

        public ReadOnlyInventoryItem(InventoryItem inventoryItem)
        {
            this.Index = inventoryItem.Index;
            this.Quantity = inventoryItem.Quantity;
            this.Item = inventoryItem.Item;
        }
    }
}