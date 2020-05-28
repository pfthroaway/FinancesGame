using FinancesGameLib.Models.Enums;

namespace FinancesGameLib.Models
{
    /// <summary>Represents an <see cref="Asset"/> that the <see cref="Player"/> can have.</summary>
    public abstract class Asset : BaseINPC
    {
        private Condition _condition;
        private string _name;
        private decimal _payment, _value;
        private int _year;

        #region Modifying Properties

        /// <summary>The current condition of the <see cref="Asset"/>.</summary>
        public Condition Condition
        {
            get => _condition;
            set { _condition = value; NotifyPropertyChanged(nameof(Condition)); }
        }

        /// <summary>The monthly payment required for the <see cref="Asset"/>.</summary>
        public decimal Payment
        {
            get => _payment;
            set { _payment = value; NotifyPropertyChanged(nameof(Payment)); }
        }

        /// <summary>The name of the <see cref="Asset"/>.</summary>
        public string Name
        {
            get => _name;
            set { _name = value; NotifyPropertyChanged(nameof(Name)); }
        }

        /// <summary>The value of the <see cref="Asset"/>.</summary>
        public decimal Value
        {
            get => _value;
            set { _value = value; NotifyPropertyChanged(nameof(Value)); }
        }

        /// <summary>The year the <see cref="Asset"/> was manufactured.</summary>
        public int Year
        {
            get => _year;
            set { _year = value; NotifyPropertyChanged(nameof(Year)); }
        }

        #endregion Modifying Properties

        #region Helper Properties

        /// <summary>The value of the <see cref="Asset"/>, formatted.</summary>
        public string ValueToString => Value.ToString("C2");

        #endregion Helper Properties
    }
}