namespace XIV_Packages.InventorySystem
{
    public readonly struct InventoryItemChange
    {
        /// <summary>
        /// Before the changes
        /// </summary>
        public readonly ReadOnlyInventoryItem before;
        /// <summary>
        /// After the changes
        /// </summary>
        public readonly ReadOnlyInventoryItem after;
        public readonly bool isMoved;
        public readonly bool isMerged;
        public readonly bool isDiscarded;
        
        public InventoryItemChange(ReadOnlyInventoryItem before, ReadOnlyInventoryItem after, bool isDiscarded)
        {
            this.before = before;
            this.after = after;
            this.isDiscarded = isDiscarded;
            this.isMoved = this.before.Index != this.after.Index;
            this.isMerged = isMoved && before.Quantity < after.Quantity;
        }
    }
}