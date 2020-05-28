using FinancesGameLib.Models.Enums;

namespace FinancesGameLib.Models
{
    /// <summary>Represents a <see cref="Vehicle"/> that the <see cref="Player"/> can have.</summary>
    public class Vehicle : Asset
    {
        private VehicleStatus _status;
        private string _make, _model;

        #region Modifying Properties

        /// <summary>The ownership status of the <see cref="Vehicle"/>.</summary>
        public VehicleStatus Status
        {
            get => _status;
            set { _status = value; NotifyPropertyChanged(nameof(Status)); }
        }

        /// <summary>The company who manufactured the <see cref="Vehicle"/>.</summary>
        public string Make
        {
            get => _make;
            set { _make = value; NotifyPropertyChanged(nameof(Make)); }
        }

        /// <summary>The model of the <see cref="Vehicle"/>.</summary>
        public string Model
        {
            get => _model;
            set { _model = value; NotifyPropertyChanged(nameof(Model)); }
        }

        #endregion Modifying Properties

        #region Helper Properties

        /// <summary>Amount of money required to insure the <see cref="Vehicle"/> every month.</summary>
        public decimal Insurance
        {
            get
            {
                switch (Status)
                {
                    case VehicleStatus.Finance:
                    case VehicleStatus.Lease:
                        return Value / 100;

                    case VehicleStatus.Own:
                        return Value / 200;
                }
                return 0;
            }
        }

        /// <summary>The money required for monthly maintenance for this <see cref="Vehicle"/>.</summary>
        public decimal Maintenance
        {
            get
            {
                decimal maintenance = 0m;
                maintenance += Condition switch
                {
                    Condition.Excellent => Value * 0.01m,
                    Condition.Good => Value * 0.02m,
                    Condition.Fair => Value * 0.035m,
                    Condition.Poor => Value * 0.1m,
                    Condition.Terrible => Value * 0.25m,
                    _ => 0,
                };
                return maintenance;
            }
        }

        /// <summary>Formatted text displaying the year, make, and model of the <see cref="Vehicle"/>.</summary>
        public string YearMakeModel => $"{Year} {Make} {Model}";

        /// <summary>The money required for monthly maintenance for this <see cref="Home"/>, formatted.</summary>
        public string MaintenanceToString => Maintenance.ToString("C2");

        #endregion Helper Properties

        /// <summary>Initializes an instance of <see cref="Vehicle"/> by assigning values to properties.</summary>
        /// <param name="status">The ownership status of the <see cref="Vehicle"/></param>
        /// <param name="condition">The current condition of the <see cref="Vehicle"/></param>
        /// <param name="payment">The monthly payment required for the <see cref="Vehicle"/></param>
        /// <param name="name">The name of the <see cref="Vehicle"/></param>
        /// <param name="value">The value of the <see cref="Vehicle"/></param>
        /// <param name="make">The company who manufactured the <see cref="Vehicle"/></param>
        /// <param name="model">The model of the <see cref="Vehicle"/></param>
        /// <param name="year">The year the <see cref="Vehicle"/> was manufactured</param>
        public Vehicle(VehicleStatus status, Condition condition, decimal payment, string name, string make, string model, int year, decimal value)
        {
            Status = status;
            Condition = condition;
            Payment = payment;
            Name = name;
            Make = make;
            Model = model;
            Year = year;
            Value = value;
        }
    }
}