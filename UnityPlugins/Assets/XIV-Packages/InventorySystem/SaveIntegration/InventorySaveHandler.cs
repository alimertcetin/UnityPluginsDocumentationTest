using UnityEngine;
using XIV_Packages.SaveSystems;

namespace XIV_Packages.InventorySystem.SaveIntegration
{
    [RequireComponent(typeof(InventoryManager))]
    public class InventorySaveHandler : MonoBehaviour, ISavable
    {
        InventoryManager inventoryManager;

        void Awake()
        {
            inventoryManager = GetComponent<InventoryManager>();
        }

        [System.Serializable]
        struct SaveData
        {
            public ItemBase[] items;
            public int[] amounts;
        }
        
        object ISavable.GetSaveData()
        {
            var inventory = inventoryManager.inventory;
            int count = inventory.slotCount;
            ItemBase[] items = new ItemBase[count];
            int[] amounts = new int[count];
            for (int i = 0; i < count; i++)
            {
                ReadOnlyInventoryItem readOnlyInventoryItem = inventory[i];
                items[i] = readOnlyInventoryItem.Item;
                amounts[i] = readOnlyInventoryItem.Quantity;
            }
            return new SaveData
            {
                items = items,
                amounts = amounts,
            };
        }

        void ISavable.LoadSaveData(object state)
        {
            SaveData saveData = (SaveData)state;
            if (saveData.items == null || saveData.items.Length == 0) return;

            var inventory = inventoryManager.inventory;
            
            inventory.informListeners = true;
            inventory.Clear();
            inventory.informListeners = false;
            for (int i = 0; i < saveData.items.Length; i++)
            {
                inventory.Add(saveData.items[i], saveData.amounts[i]);
            }
            inventory.informListeners = true;
        }
    }
}