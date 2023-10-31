using UnityEngine;
using XIV_Packages.InventorySystem.ScriptableObjects;
using XIV_Packages.InventorySystem.ScriptableObjects.Channels;
using XIV_Packages.ScriptableObjects.Channels;

namespace XIV_Packages.InventorySystem
{
    public class InventoryManager : MonoBehaviour, IInventoryListener
    {
        [SerializeField] InventorySO inventorySO;
        [SerializeField] InventoryChannelSO inventoryLoadedChannel;
        [SerializeField] InventoryChangeChannelSO inventoryChangedChannel;
        [SerializeField] VoidChannelSO onSceneReady;

        public Inventory inventory { get; private set; }

        void Awake() => inventory = inventorySO.GetInventory();
        void Start() => inventoryLoadedChannel.RaiseEvent(inventory);
        
        void OnEnable()
        {
            onSceneReady?.Register(OnSceneReady);
            inventory.Register(this);
        }

        void OnDisable()
        {
            onSceneReady?.Unregister(OnSceneReady);
            inventory.Unregister(this);
        }

        void OnSceneReady()
        {
            inventoryLoadedChannel.RaiseEvent(inventory);
        }

        void IInventoryListener.OnInventoryChanged(InventoryChange inventoryChange)
        {
            inventoryChangedChannel.RaiseEvent(inventoryChange);
        }
        
    }
}