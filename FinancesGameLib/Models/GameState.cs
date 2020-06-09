using FinancesGameLib.Models.Enums;
using System;
using System.Collections.Generic;

namespace FinancesGameLib.Models
{
    public static class GameState
    {
        public static Player CurrentPlayer;

        public static void GeneratePlayer()
        {
            Player newPlayer = new Player(
                household: new List<Person>
                {
                    new Person("Quincy", "Quirk", new DateTime(1995, 1, 1), EducationLevel.HighSchool,
                    new List<Job> {
                        new Job("Teach Students Today!", "Tutor", EducationLevel.HighSchool, false, 10m, 0, 0, 0, 8, 40, 160, 5, 20, 0),
                        new Job("McDonald's","Cook", EducationLevel.None, false, 8m, 0, 0, 0, 8, 40, 160, 5, 20, 0)
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

        public static void GenerateJob()
        {
        }
    }
}