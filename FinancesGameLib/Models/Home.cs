using FinancesGameLib.Models.Enums;
using System;

namespace FinancesGameLib.Models
{/// <summary>Represents a <see cref="Home"/> that the <see cref="Player"/> can have.</summary>
    public class Home : Asset
    {
        private HomeStatus _status;

        /// <summary>The ownership status of the <see cref="Home"/>.</summary>
        public HomeStatus Status
        {
            get => _status;
            set { _status = value; NotifyPropertyChanged(nameof(Status)); }
        }

        #region Helper Properties

        /// <summary>Amount of money required to insure the <see cref="Vehicle"/> every month.</summary>
        public decimal Insurance
        {
            get
            {
                switch (Status)
                {
                    case HomeStatus.Rent:
                        return Value / 4000;

                    case HomeStatus.Own:
                    case HomeStatus.Mortgage:
                        return Value / 1000;
                }
                return 0;
            }
        }

        /// <summary>The money required for monthly maintenance for this <see cref="Home"/>.</summary>
        public decimal Maintenance
        {
            get
            {
                decimal maintenance = 0m;
                switch (Status)
                {
                    case HomeStatus.Mortgage:
                    case HomeStatus.Own:
                        {
                            maintenance += Condition switch
                            {
                                Condition.Excellent => Value * 0.01m,
                                Condition.Good => Value * 0.02m,
                                Condition.Fair => Value * 0.035m,
                                Condition.Poor => Value * 0.1m,
                                Condition.Terrible => Value * 0.25m,
                                _ => 0,
                            };
                            break;
                        }
                    case HomeStatus.Rent:
                        {
                            maintenance += Condition switch
                            {
                                Condition.Excellent => Value * 0.001m,
                                Condition.Good => Value * 0.002m,
                                Condition.Fair => Value * 0.0035m,
                                Condition.Poor => Value * 0.01m,
                                Condition.Terrible => Value * 0.025m,
                                _ => 0,
                            };
                            break;
                        }
                }

                return maintenance;
            }
        }

        /// <summary>The money required for monthly maintenance for this <see cref="Home"/>, formatted.</summary>
        public string MaintenanceToString => Maintenance.ToString("C2");

        #endregion Helper Properties

        #region Override Operators

        public static bool Equals(Home left, Home right)
        {
            if (left is null && right is null) return true;
            if (left is null ^ right is null) return false;
            return left.Status == right.Status && left.Condition == right.Condition && left.Payment == right.Payment && string.Equals(left.Name, right.Name, StringComparison.OrdinalIgnoreCase) && left.Value == right.Value;
        }

        public sealed override bool Equals(object obj) => Equals(this, obj as Home);

        public bool Equals(Home otherHome) => Equals(this, otherHome);

        public static bool operator ==(Home left, Home right) => Equals(left, right);

        public static bool operator !=(Home left, Home right) => !Equals(left, right);

        public sealed override int GetHashCode() => base.GetHashCode() ^ 17;

        public sealed override string ToString() => $"{Name} - {ValueToString}";

        #endregion Override Operators

        /// <summary>Initializes an instance of <see cref="Home"/> by assigning values to properties.</summary>
        /// <param name="status">The ownership status of the <see cref="Home"/></param>
        /// <param name="condition">The current condition of the <see cref="Home"/></param>
        /// <param name="payment">The monthly payment required for the <see cref="Home"/></param>
        /// <param name="name">The name of the <see cref="Home"/></param>
        /// <param name="value">The value of the <see cref="Home"/></param>
        /// <param name="year">The year the <see cref="Home"/> was manufactured</param>
        public Home(HomeStatus status, Condition condition, decimal payment, string name, decimal value, int year)
        {
            Status = status;
            Condition = condition;
            Payment = payment;
            Name = name;
            Value = value;
            Year = year;
        }
    }
}