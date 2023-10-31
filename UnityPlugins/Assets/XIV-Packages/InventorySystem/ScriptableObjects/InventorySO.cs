using System;
using System.Collections.Generic;
using UnityEngine;

namespace XIV_Packages.InventorySystem.ScriptableObjects
{
    /// <summary>
    /// Stores the quantity and the associated itemSO
    /// </summary>
    [System.Serializable]
    public struct ItemSOData
    {
        public ItemSO itemSO;
        public int quantity;
    }
    
    [CreateAssetMenu(menuName = MenuPaths.BASE_MENU + nameof(InventorySO))]
    public class InventorySO : ScriptableObject
    {
        public int SlotCount;
        public List<ItemSOData> items;
#if UNITY_EDITOR
        [System.Serializable]
        struct RuntimeItemData
        {
            public string name;
            public ItemBase item;
            public int quantity;
        }
        [SerializeField] List<RuntimeItemData> runtimeItems;
#endif

        public Inventory GetInventory()
        {
            var inventory = new Inventory(SlotCount);

            int itemsCount = items.Count;
            for (var i = 0; i < itemsCount; i++)
            {
                var itemData = items[i];
                if (itemData.quantity <= 0)
                {
                    Debug.LogError(new InvalidOperationException("Quantity is less than or equal to 0 at index : " + i));
                    continue;
                }
                
                if (inventory.Add(itemData.itemSO.GetItem(), itemData.quantity) > 0)
                {
                    Debug.LogError("Inventory is full! Couldn't add the item at index : " + i);
                    break;
                }
            }
            
#if UNITY_EDITOR
            runtimeItems = new List<RuntimeItemData>(SlotCount);
            for (var i = 0; i < inventory.slotCount; i++)
            {
                ReadOnlyInventoryItem item = inventory[i];
                var runtimeItem = new RuntimeItemData
                {
                    name = item.IsEmpty ? "EMPTY" : item.Item.GetType().Name.Split('.')[^1],
                    quantity = item.Quantity,
                    item = item.Item,
                };
                runtimeItems.Add(runtimeItem);
            }
            inventory.Register(new InventoryRuntimeListener(inventory, runtimeItems));
#endif
            
            return inventory;
        }

#if UNITY_EDITOR
        class InventoryRuntimeListener : IInventoryListener
        {
            Inventory inventory;
            List<RuntimeItemData> runtimeItems;
            
            public InventoryRuntimeListener(Inventory inventory, List<RuntimeItemData> runtimeItems)
            {
                this.inventory = inventory;
                this.runtimeItems = runtimeItems;
                Refresh();
            }
            
            void IInventoryListener.OnInventoryChanged(InventoryChange inventoryChange)
            {
                Refresh();
            }

            void Refresh()
            {
                runtimeItems.Clear();
                for (int i = 0; i < inventory.slotCount; i++)
                {
                    ReadOnlyInventoryItem item = inventory[i];
                    var name = item.IsEmpty == false ? item.Item.GetType().Name.Split('.')[^1] : "Empty";
                    var quantity = item.Quantity;
                    var itemBase = item.Item;
                    var runtimeItem = new RuntimeItemData { name = name, quantity = quantity, item = itemBase, };
                    runtimeItems.Add(runtimeItem);
                }
            }
        }
#endif
    }
}