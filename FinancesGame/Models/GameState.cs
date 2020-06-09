using Extensions;
using Extensions.DataTypeHelpers;
using FinancesGameLib.Models;
using FinancesGameLib.Models.Enums;
using System;
using System.Collections.Generic;

namespace FinancesGame.Models
{
    /// <summary>Represents the current state of the game.</summary>
    public static class GameState
    {
        public static DateTime CurrentDate;
        public static Player CurrentPlayer;
        public static List<Vehicle> AllVehicles;
        public static List<string> FemaleFirstNames;
        public static List<string> MaleFirstNames;
        public static List<string> Surnames;

        public static void GeneratePlayer()
        {
            Player newPlayer = new Player(
                household: new List<Person>
                {
                    new Person("Quincy", "Quirk", Gender.Male, new DateTime(1995, 1, 1), EducationLevel.HighSchool,
                    new List<Job> {
                        new Job("Teach Students Today!", "Tutor", EducationLevel.HighSchool,1600m,160),
                        new Job("McDonald's","Cook", EducationLevel.None,1280,160)
                    }),
                }
                ,
                money: 12534.34m,
                new List<Expense>
                {
                    new Expense("Car Insurance",135.62m),
                    new Expense("Rent", 350m),
                    new Expense("Cell Phone", 50m)
                },
                new List<Home>
                { new Home(HomeStatus.Rent, Condition.Good, 750m, "My Small-Ass Apartment", 50000m, 2008) },
                new List<Vehicle>
                { new Vehicle(VehicleStatus.Own, Condition.Good, 0m, "Mazda, Bro!", "Mazda", "Mazda 3", 2012, 6000m) }
                );
        }

        public static Person GeneratePerson(string lastName)
        {
            int gender = Functions.GenerateRandomNumber(0, 1);
            DateTime start = new DateTime(1950, 1, 1);
            int range = (DateTime.Today - start).Days;
            DateTime birthdate = start.AddDays(Functions.GenerateRandomNumber(1, range));
            Person newPerson = new Person(gender == 0 ? GenerateMaleFirstName() : GenerateFemaleFirstName(), lastName, EnumHelper.Parse<Gender>(gender), birthdate, EnumHelper.Parse<EducationLevel>(Functions.GenerateRandomNumber(0, Enum.GetNames(typeof(EducationLevel)).Length)), new List<Job>());

            List<Job> jobs = new List<Job>();
            //if a user is old enough to have a job
            //job total hours should be less than 448 per month. People need 8 hours of sleep.
            if (birthdate.AddYears(16) <= DateTime.Today)
            {
            }
            return newPerson;
        }

        public static Job GenerateJob()
        {
        }

        public static string GenerateMaleFirstName() => MaleFirstNames[Functions.GenerateRandomNumber(0, MaleFirstNames.Count - 1)];

        public static string GenerateFemaleFirstName() => FemaleFirstNames[Functions.GenerateRandomNumber(0, FemaleFirstNames.Count - 1)];
    }
}