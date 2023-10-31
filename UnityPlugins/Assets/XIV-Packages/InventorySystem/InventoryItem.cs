using UnityEngine;

namespace XIV_Packages.InventorySystem
{
    [System.Serializable]
    public struct InventoryItem
    {
        public static readonly InventoryItem InvalidInventoryItem = new InventoryItem(-1, -1, null);
        [field: SerializeField] public int Index { get; set; }
        [field: SerializeField] public int Quantity { get; set; }
        [field: SerializeField] public ItemBase Item { get; set; }
        public bool IsEmpty => Quantity <= 0;

        public InventoryItem(int index, int quantity, ItemBase item)
        {
            this.Index = index;
            this.Quantity = quantity;
            this.Item = item;
        }
    }
}