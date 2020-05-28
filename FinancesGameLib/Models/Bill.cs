using System;

namespace FinancesGameLib.Models
{
    /// <summary>Represents a <see cref="Bill"/> the <see cref="Player"/> has to pay every month.</summary>
    public class Bill : Liability
    {
        #region Override Operators

        public static bool Equals(Bill left, Bill right)
        {
            if (left is null && right is null) return true;
            if (left is null ^ right is null) return false;
            return string.Equals(left.Name, right.Name, StringComparison.OrdinalIgnoreCase) && left.Cost == right.Cost;
        }

        public sealed override bool Equals(object obj) => Equals(this, obj as Bill);

        public bool Equals(Bill otherBill) => Equals(this, otherBill);

        public static bool operator ==(Bill left, Bill right) => Equals(left, right);

        public static bool operator !=(Bill left, Bill right) => !Equals(left, right);

        public sealed override int GetHashCode() => base.GetHashCode() ^ 17;

        public sealed override string ToString() => $"{Name} - {CostToString}";

        #endregion Override Operators

        /// <summary>Initializes a new instance of <see cref="Bill"/> by assigning values to properties.</summary>
        /// <param name="name">The name of the <see cref="Bill"/></param>
        /// <param name="cost">The cost of the <see cref="Bill"/></param>
        public Bill(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}