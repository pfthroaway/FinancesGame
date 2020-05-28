using System;
using System.Collections.Generic;
using System.Text;

namespace FinancesGameLib.Models
{
    /// <summary>Represents a monthly expenses which may vary monthly and isn't a <see cref="Bill"/>.</summary>
    public class Expense : Liability
    {
        // Expenses should vary month to month. Diapers, food, clothing, light bulbs, etc.

        #region Override Operators

        public static bool Equals(Expense left, Expense right)
        {
            if (left is null && right is null) return true;
            if (left is null ^ right is null) return false;
            return string.Equals(left.Name, right.Name, StringComparison.OrdinalIgnoreCase) && left.Cost == right.Cost;
        }

        public sealed override bool Equals(object obj) => Equals(this, obj as Expense);

        public bool Equals(Expense otherExpense) => Equals(this, otherExpense);

        public static bool operator ==(Expense left, Expense right) => Equals(left, right);

        public static bool operator !=(Expense left, Expense right) => !Equals(left, right);

        public sealed override int GetHashCode() => base.GetHashCode() ^ 17;

        public sealed override string ToString() => $"{Name} - {CostToString}";

        #endregion Override Operators

        /// <summary>Initializes a new instance of <see cref="Expense"/> by assigning values to properties.</summary>
        /// <param name="name">The name of the <see cref="Expense"/></param>
        /// <param name="cost">The cost of the <see cref="Expense"/></param>
        public Expense(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}