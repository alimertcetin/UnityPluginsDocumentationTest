using System;

namespace XIV_Packages.InventorySystem
{
    [Serializable]
    public abstract class ItemBase : IEquatable<ItemBase>
    {
        public string title;
        public string description;
        public int StackableAmount = 1;

        public bool Equals(ItemBase other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return title == other.title && description == other.description && StackableAmount == other.StackableAmount;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is ItemBase other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(title, description, StackableAmount);
        }
    }
}