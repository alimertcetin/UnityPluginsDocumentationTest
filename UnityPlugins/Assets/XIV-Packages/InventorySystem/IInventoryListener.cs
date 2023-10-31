namespace XIV_Packages.InventorySystem
{
    public interface IInventoryListener
    {
        void OnInventoryChanged(InventoryChange inventoryChange);
    }
}