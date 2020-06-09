using Extensions;
using FinancesGameLib.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinancesGameLib.Models
{
    /// <summary>Represents a living entity in the game.</summary>
    public class Person : BaseINPC
    {
        private string _firstName, _lastName;
        private DateTime _birthDate;
        private EducationLevel _educationLevel;
        private List<Job> _jobs = new List<Job>();

        #region Modifying Properties

        /// <summary>The <see cref="Person"/>'s first name.</summary>
        public string FirstName
        {
            get => _firstName;
            set { _firstName = value; NotifyPropertyChanged(nameof(FirstName), nameof(Name)); }
        }

        /// <summary>The <see cref="Person"/>'s last name.</summary>
        public string LastName
        {
            get => _lastName;
            set { _lastName = value; NotifyPropertyChanged(nameof(LastName), nameof(Name)); }
        }

        /// <summary>The <see cref="Person"/>'s age.</summary>
        public DateTime BirthDate
        {
            get => _birthDate;
            set { _birthDate = value; NotifyPropertyChanged(nameof(BirthDate)); }
        }

        /// <summary>All <see cref="Job"/>s the <see cref="Player"/> has.</summary>
        public List<Job> Jobs
        {
            get => _jobs;
            set { _jobs = value; NotifyPropertyChanged(nameof(Jobs)); }
        }

        /// <summary>The highest level of education the <see cref="Person"/> has achieved.</summary>
        public EducationLevel EducationLevel
        {
            get => _educationLevel;
            set { _educationLevel = value; NotifyPropertyChanged(nameof(EducationLevel)); }
        }

        #endregion Modifying Properties

        #region Helper Properties

        /// <summary>The first and last names of the <see cref="Person"/>.</summary>
        public string Name => $"{FirstName} {LastName}";

        /// <summary>The last then first names of the <see cref="Person"/>.</summary>
        public string LastFirst => $"{LastName}, {FirstName}";

        /// <summary>The <see cref="Player"/>'s daily income from all <see cref="Job"/>s.</summary>
        public decimal DailyIncome
        {
            get
            {
                decimal income = 0m;
                foreach (Job job in Jobs)
                {
                    if (job.IsSalary)
                        income += job.DailySalary;
                    else
                        income += job.DailyWages;
                }
                return income;
            }
        }

        /// <summary>The <see cref="Player"/>'s weekly income from all <see cref="Job"/>s.</summary>
        public decimal WeeklyIncome
        {
            get
            {
                decimal income = 0m;
                foreach (Job job in Jobs)
                {
                    if (job.IsSalary)
                        income += job.WeeklySalary;
                    else
                        income += job.WeeklyWages;
                }
                return income;
            }
        }

        /// <summary>The <see cref="Player"/>'s monthly income from all <see cref="Job"/>s.</summary>
        public decimal MonthlyIncome
        {
            get
            {
                decimal income = 0m;
                foreach (Job job in Jobs)
                {
                    if (job.IsSalary)
                        income += job.MonthlySalary;
                    else
                        income += job.MonthlyWages;
                }
                return income;
            }
        }

        /// <summary>The money required for all travel expenses.</summary>
        public decimal MonthlyTravelExpenses => Jobs.Sum(job => job.DailyTravelExpenses * job.DaysPerMonth);

        #endregion Helper Properties

        #region Job Management

        /// <summary>Adds a <see cref="Job"/> to the list of <see cref="Player"/>'s <see cref="Job"/>s.</summary>
        /// <param name="newJob"><see cref="Job"/> to be added</param>
        public void AddJob(Job newJob)
        {
            Jobs.Add(newJob);
            UpdateJobs();
        }

        /// <summary>Replaces an old <see cref="Job"/> in the list of <see cref="Player"/>'s <see cref="Job"/>s with a new one.</summary>
        /// <param name="oldJob"><see cref="Job"/> to be replaced</param>
        /// <param name="newJob"><see cref="Job"/> to replace the old one</param>
        public void ModifyJob(Job oldJob, Job newJob)
        {
            Jobs.Replace(oldJob, newJob);
            UpdateJobs();
        }

        /// <summary>Removes a <see cref="Job"/> from the list of <see cref="Player"/>'s <see cref="Job"/>s.</summary>
        /// <param name="removeJob"><see cref="Job"/> to be removed</param>
        public void RemoveJob(Job removeJob)
        {
            Jobs.Remove(removeJob);
            NotifyPropertyChanged(nameof(Jobs));
        }

        /// <summary>Sorts and refreshes the list of <see cref="Job"/>s.</summary>
        private void UpdateJobs()
        {
            Jobs = Jobs.OrderBy(job => job.EmployerName).ToList();
            NotifyPropertyChanged(nameof(Jobs));
        }

        #endregion Job Management

        public Person(string firstName, string lastName, DateTime birthDate, EducationLevel educationLevel, List<Job> jobs)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            EducationLevel = educationLevel;
            Jobs = jobs;
        }
    }
}