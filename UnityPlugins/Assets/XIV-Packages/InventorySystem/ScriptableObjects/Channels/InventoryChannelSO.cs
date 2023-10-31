using System;
using UnityEngine;

namespace XIV_Packages.InventorySystem.ScriptableObjects.Channels
{
    [CreateAssetMenu(menuName = MenuPaths.CHANNELS_MENU + nameof(InventoryChannelSO))]
    public class InventoryChannelSO : ScriptableObject
    {
        Action<Inventory> action;

        public void Register(Action<Inventory> action)
        {
            this.action += action;
        }

        public void Unregister(Action<Inventory> action)
        {
            this.action -= action;
        }
        
        public void RaiseEvent(Inventory inventory)
        {
            action?.Invoke(inventory);
        }
    }
}