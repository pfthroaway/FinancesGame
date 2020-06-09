using FinancesGameLib.Models.Enums;
using System;

namespace FinancesGameLib.Models
{
    /// <summary>Represents a <see cref="Job"/> that the <see cref="Player"/> can have.</summary>
    public class Job : BaseINPC
    {
        private string _employerName, _employeeTitle;
        private EducationLevel _minimumEducationLevel;
        private decimal _monthlyIncome, _hoursPerMonth;

        #region Modifying Properties

        /// <summary>The name of the employer at the <see cref="Job"/>.</summary>
        public string EmployerName
        {
            get => _employerName;
            set { _employerName = value; NotifyPropertyChanged(nameof(EmployerName)); }
        }

        /// <summary>The title of the <see cref="Player"/> at the <see cref="Job"/>.</summary>
        public string EmployeeTitle
        {
            get => _employeeTitle;
            set { _employeeTitle = value; NotifyPropertyChanged(nameof(EmployeeTitle)); }
        }

        /// <summary>The minimum education level required for a <see cref="Player"/> to get this <see cref="Job"/>.</summary>
        public EducationLevel MinimumEducationLevel
        {
            get => _minimumEducationLevel;
            set { _minimumEducationLevel = value; NotifyPropertyChanged(nameof(MinimumEducationLevel)); }
        }

        public decimal MonthlyIncome
        {
            get => _monthlyIncome;
            set { _monthlyIncome = value; NotifyPropertyChanged(nameof(MonthlyIncome)); }
        }

        /// <summary>The hours worked per month by the <see cref="Player"/> at the <see cref="Job"/>.</summary>
        public decimal HoursPerMonth
        {
            get => _hoursPerMonth;
            set { _hoursPerMonth = value; NotifyPropertyChanged(nameof(HoursPerMonth)); }
        }

        #endregion Modifying Properties

        #region Helper Properties

        /// <summary>Total monthly wages paid to the <see cref="Player"/>.</summary>
        public string MonthlyIncomeToString => MonthlyIncome.ToString("C2");

        #endregion Helper Properties

        #region Override Operators

        public static bool Equals(Job left, Job right)
        {
            if (left is null && right is null) return true;
            if (left is null ^ right is null) return false;
            return string.Equals(left.EmployerName, right.EmployerName, StringComparison.OrdinalIgnoreCase) && string.Equals(left.EmployeeTitle, right.EmployeeTitle, StringComparison.OrdinalIgnoreCase) && left.MinimumEducationLevel == right.MinimumEducationLevel && left.MonthlyIncome == right.MonthlyIncome && left.HoursPerMonth == right.HoursPerMonth;
        }

        public sealed override bool Equals(object obj) => Equals(this, obj as Job);

        public bool Equals(Job otherJob) => Equals(this, otherJob);

        public static bool operator ==(Job left, Job right) => Equals(left, right);

        public static bool operator !=(Job left, Job right) => !Equals(left, right);

        public sealed override int GetHashCode() => base.GetHashCode() ^ 17;

        public sealed override string ToString() => $"{EmployerName}: {EmployeeTitle} - {MonthlyIncomeToString}";

        #endregion Override Operators

        /// <summary>Initializes an instance of <see cref="Job"/> by assigning values to properties.</summary>
        /// <param name="employerName">The name of the employer at the <see cref="Job"/></param>
        /// <param name="employeeTitle">The title of the <see cref="Player"/> at the <see cref="Job"/></param>
        /// <param name="monthlyIncome">Is the <see cref="Job"/> paid as salary?</param>
        /// <param name="hoursPerMonth">The hours worked per month by the <see cref="Player"/> at the <see cref="Job"/></param>
        public Job(string employerName, string employeeTitle, EducationLevel minimumEducationLevel, decimal monthlyIncome, decimal hoursPerMonth)
        {
            EmployerName = employerName;
            EmployeeTitle = employeeTitle;
            MinimumEducationLevel = minimumEducationLevel;
            MonthlyIncome = monthlyIncome;
            HoursPerMonth = hoursPerMonth;
        }
    }
}