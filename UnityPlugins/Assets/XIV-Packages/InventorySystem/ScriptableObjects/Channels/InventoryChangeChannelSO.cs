using System;
using UnityEngine;

namespace XIV_Packages.InventorySystem.ScriptableObjects.Channels
{
    [CreateAssetMenu(menuName = MenuPaths.CHANNELS_MENU + nameof(InventoryChangeChannelSO))]
    public class InventoryChangeChannelSO : ScriptableObject
    {
        Action<InventoryChange> action;

        public void Register(Action<InventoryChange> action)
        {
            this.action += action;
        }

        public void Unregister(Action<InventoryChange> action)
        {
            this.action -= action;
        }
        
        public void RaiseEvent(InventoryChange inventoryChange)
        {
            action?.Invoke(inventoryChange);
        }
    }
}