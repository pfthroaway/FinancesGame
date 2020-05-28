using FinancesGameLib.Models.Enums;
using System;

namespace FinancesGameLib.Models
{
    /// <summary>Represents a <see cref="Job"/> that the <see cref="Player"/> can have.</summary>
    public class Job : BaseINPC
    {
        private string _employerName, _employeeTitle;
        private bool _isSalary;
        private decimal _hourlyWage, _dailySalary, _weeklySalary, _monthlySalary, _hoursPerDay, _hoursPerWeek, _hoursPerMonth, _dailyTravelExpenses;
        private int _daysPerWeek, _daysPerMonth;
        private EducationLevel _minimumEducationLevel;

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
        public EducationLevel MinimumEducationLevel { get => _minimumEducationLevel; set => _minimumEducationLevel = value; }

        /// <summary>Is the <see cref="Job"/> paid as salary?</summary>
        public bool IsSalary
        {
            get => _isSalary;
            set { _isSalary = value; NotifyPropertyChanged(nameof(IsSalary)); }
        }

        /// <summary>The hourly wage paid to the <see cref="Player"/> at the <see cref="Job"/>.</summary>
        public decimal HourlyWage
        {
            get => _hourlyWage;
            set { _hourlyWage = value; NotifyPropertyChanged(nameof(HourlyWage)); }
        }

        /// <summary>The daily salary paid to the <see cref="Player"/> at the <see cref="Job"/>.</summary>
        public decimal DailySalary
        {
            get => _dailySalary;
            set { _dailySalary = value; NotifyPropertyChanged(nameof(DailySalary)); }
        }

        /// <summary>The weekly salary paid to the <see cref="Player"/> at the <see cref="Job"/>.</summary>
        public decimal WeeklySalary
        {
            get => _weeklySalary;
            set { _weeklySalary = value; NotifyPropertyChanged(nameof(WeeklySalary)); }
        }

        /// <summary>The monthly salary paid to the <see cref="Player"/> at the <see cref="Job"/>.</summary>
        public decimal MonthlySalary
        {
            get => _monthlySalary;
            set { _monthlySalary = value; NotifyPropertyChanged(nameof(MonthlySalary)); }
        }

        /// <summary>The hours worked per day by the <see cref="Player"/> at the <see cref="Job"/>.</summary>
        public decimal HoursPerDay
        {
            get => _hoursPerDay;
            set { _hoursPerDay = value; NotifyPropertyChanged(nameof(HoursPerDay)); }
        }

        /// <summary>The hours worked per week by the <see cref="Player"/> at the <see cref="Job"/>.</summary>
        public decimal HoursPerWeek
        {
            get => _hoursPerWeek;
            set { _hoursPerWeek = value; NotifyPropertyChanged(nameof(HoursPerWeek)); }
        }

        /// <summary>The hours worked per month by the <see cref="Player"/> at the <see cref="Job"/>.</summary>
        public decimal HoursPerMonth
        {
            get => _hoursPerMonth;
            set { _hoursPerMonth = value; NotifyPropertyChanged(nameof(HoursPerMonth)); }
        }

        /// <summary>The days worked per week by the <see cref="Player"/> at the <see cref="Job"/>.</summary>
        public int DaysPerWeek
        {
            get => _daysPerWeek;
            set { _daysPerWeek = value; NotifyPropertyChanged(nameof(DaysPerWeek)); }
        }

        /// <summary>The days worked per month by the <see cref="Player"/> at the <see cref="Job"/>.</summary>
        public int DaysPerMonth
        {
            get => _daysPerMonth;
            set { _daysPerMonth = value; NotifyPropertyChanged(nameof(DaysPerMonth)); }
        }

        /// <summary>The daily cost of travelling to/from the <see cref="Job"/>.</summary>
        public decimal DailyTravelExpenses
        {
            get => _dailyTravelExpenses;
            set { _dailyTravelExpenses = value; NotifyPropertyChanged(nameof(DailyTravelExpenses)); }
        }

        #endregion Modifying Properties

        #region Helper Properties

        /// <summary>The hourly wage paid to the <see cref="Player"/> at the <see cref="Job"/>, formatted.</summary>
        public string HourlyWageToString => $"{HourlyWage:C2}/hour";

        /// <summary>The daily salary paid to the <see cref="Player"/> at the <see cref="Job"/>, formatted.</summary>
        public string DailySalaryToString => $"{DailySalary:C2}/day";

        /// <summary>Total daily wages paid to the <see cref="Player"/>.</summary>
        public decimal DailyWages => !IsSalary ? HourlyWage * HoursPerDay : 0;

        /// <summary>Total weekly wages paid to the <see cref="Player"/>.</summary>
        public decimal WeeklyWages => !IsSalary ? (HourlyWage * HoursPerWeek) + (HoursPerWeek > 40 ? (HoursPerWeek - 40) * HourlyWage * 1.5m : 0) : 0;

        /// <summary>Total monthly wages paid to the <see cref="Player"/>.</summary>
        public decimal MonthlyWages => !IsSalary ? (HourlyWage * HoursPerMonth) + (HoursPerWeek > 160 ? (HoursPerWeek - 160) * HourlyWage * 1.5m : 0) : 0;

        #endregion Helper Properties

        #region Override Operators

        public static bool Equals(Job left, Job right)
        {
            if (left is null && right is null) return true;
            if (left is null ^ right is null) return false;
            return string.Equals(left.EmployerName, right.EmployerName, StringComparison.OrdinalIgnoreCase) && string.Equals(left.EmployeeTitle, right.EmployeeTitle, StringComparison.OrdinalIgnoreCase) && left.MinimumEducationLevel == right.MinimumEducationLevel && left.IsSalary == right.IsSalary && left.HourlyWage == right.HourlyWage && left.DailySalary == right.DailySalary && left.WeeklySalary == right.WeeklySalary && left.MonthlySalary == right.MonthlySalary && left.HoursPerDay == right.HoursPerDay && left.HoursPerWeek == right.HoursPerWeek && left.HoursPerMonth == right.HoursPerMonth && left.DailyTravelExpenses == right.DailyTravelExpenses && left.DaysPerWeek == right.DaysPerWeek && left.DaysPerMonth == right.DaysPerMonth;
        }

        public sealed override bool Equals(object obj) => Equals(this, obj as Job);

        public bool Equals(Job otherJob) => Equals(this, otherJob);

        public static bool operator ==(Job left, Job right) => Equals(left, right);

        public static bool operator !=(Job left, Job right) => !Equals(left, right);

        public sealed override int GetHashCode() => base.GetHashCode() ^ 17;

        public sealed override string ToString() => $"{EmployerName}: {EmployeeTitle} - {(IsSalary ? DailySalaryToString : HourlyWageToString)}";

        #endregion Override Operators

        /// <summary>Initializes an instance of <see cref="Job"/> by assigning values to properties.</summary>
        /// <param name="employerName">The name of the employer at the <see cref="Job"/></param>
        /// <param name="employeeTitle">The title of the <see cref="Player"/> at the <see cref="Job"/></param>
        /// <param name="isSalary">Is the <see cref="Job"/> paid as salary?</param>
        /// <param name="hourlyWage">The hourly wage paid to the <see cref="Player"/> at the <see cref="Job"/></param>
        /// <param name="dailySalary">The daily salary paid to the <see cref="Player"/> at the <see cref="Job"/></param>
        /// <param name="weeklySalary">The weekly salary paid to the <see cref="Player"/> at the <see cref="Job"/></param>
        /// <param name="monthlySalary">The monthly salary paid to the <see cref="Player"/> at the <see cref="Job"/></param>
        /// <param name="hoursPerDay">The hours worked per day by the <see cref="Player"/> at the <see cref="Job"/></param>
        /// <param name="hoursPerWeek">The hours worked per week by the <see cref="Player"/> at the <see cref="Job"/></param>
        /// <param name="hoursPerMonth">The hours worked per month by the <see cref="Player"/> at the <see cref="Job"/></param>
        /// <param name="daysPerWeek">The days worked per week by the <see cref="Player"/> at the <see cref="Job"/></param>
        /// <param name="daysPerMonth">The days worked per month by the <see cref="Player"/> at the <see cref="Job"/></param>
        /// <param name="dailyTravelExpenses">The daily cost of travelling to/from the <see cref="Job"/></param>
        public Job(string employerName, string employeeTitle, EducationLevel minimumEducationLevel, bool isSalary, decimal hourlyWage, decimal dailySalary, decimal weeklySalary, decimal monthlySalary, decimal hoursPerDay, decimal hoursPerWeek, decimal hoursPerMonth, int daysPerWeek, int daysPerMonth, decimal dailyTravelExpenses)
        {
            EmployerName = employerName;
            EmployeeTitle = employeeTitle;
            MinimumEducationLevel = minimumEducationLevel;
            IsSalary = isSalary;
            HourlyWage = hourlyWage;
            DailySalary = dailySalary;
            WeeklySalary = weeklySalary;
            MonthlySalary = monthlySalary;
            HoursPerDay = hoursPerDay;
            HoursPerWeek = hoursPerWeek;
            HoursPerMonth = hoursPerMonth;
            DaysPerWeek = daysPerWeek;
            DaysPerMonth = daysPerMonth;
            DailyTravelExpenses = dailyTravelExpenses;
        }
    }
}