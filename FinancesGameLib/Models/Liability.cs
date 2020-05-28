using System;
using System.Collections.Generic;
using System.Text;

namespace FinancesGameLib.Models
{
    /// <summary>Represents a cost to the <see cref="Player"/>.</summary>
    public abstract class Liability : BaseINPC
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
    }
}