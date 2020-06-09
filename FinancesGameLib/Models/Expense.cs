using System;

namespace FinancesGameLib.Models
{
    /// <summary>Represents a monthly expenses which may vary monthly and isn't a <see cref="Bill"/>.</summary>
    public class Expense : BaseINPC
    {
        private string _name;
        private decimal _cost;

        /// <summary>The name of the <see cref="Liability"/>.</summary>
        public string Name
        {
            get => _name;
            set { _name = value; NotifyPropertyChanged(nameof(Name)); }
        }

        /// <summary>The cost of the <see cref="Liability"/>.</summary>
        public decimal Cost
        {
            get => _cost;
            set { _cost = value; NotifyPropertyChanged(nameof(Cost)); }
        }

        /// <summary>The cost of the <see cref="Liability"/>, formatted.</summary>
        public string CostToString => Cost.ToString("C2");

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