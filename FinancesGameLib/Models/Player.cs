using Extensions;
using FinancesGameLib.Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace FinancesGameLib.Models
{
    /// <summary>Represents the <see cref="Player"/> playing the game.</summary>
    public class Player : BaseINPC
    {
        private Person _currentPlayer;
        private decimal _money;
        private List<Bill> _bills = new List<Bill>();
        private List<Expense> _expenses = new List<Expense>();
        private List<Person> _family = new List<Person>();
        private List<Home> _homes = new List<Home>();
        private List<Vehicle> _vehicles = new List<Vehicle>();

        // Players can have multiple homes or just one home where they live. They either rent or own. Most players will pay rent/mortgage every month.
        // Players may have family members. These family members increase monthly expenses and bills.
        // If own, they have property taxes.
        // If players have mortgage, they have much higher maintenance costs.
        // They all have bills and monthly expenses.
        // Bills are things to be paid for every month like vehicle/home insurance, electricity, garbage, sewer, etc. They are relatively static.
        // Monthly expenses are things like clothing and food, diapers, light bulbs, etc.
        //TODO Maybe implement a Household class which sums all the income for the family.

        #region Modifying Properties

        /// <summary>The current <see cref="Person"/> the <see cref="Player"/> controls.</summary>
        public Person CurrentPlayer
        {
            get => _currentPlayer;
            set { _currentPlayer = value; NotifyPropertyChanged(nameof(CurrentPlayer)); }
        }

        /// <summary>The amount of money the <see cref="Player"/> has.</summary>
        public decimal Money
        {
            get => _money;
            set { _money = value; NotifyPropertyChanged(nameof(Money)); }
        }

        /// <summary>All the monthly <see cref="Bill"/>s the <see cref="Player"/> is required to pay.</summary>
        public List<Bill> Bills
        {
            get => _bills;
            set { _bills = value; NotifyPropertyChanged(nameof(Bills)); }
        }

        /// <summary>All the monthly <see cref="Expense"/>s the <see cref="Player"/> is required to pay.</summary>
        public List<Expense> Expenses
        {
            get => _expenses;
            set { _expenses = value; NotifyPropertyChanged(nameof(Expenses)); }
        }

        /// <summary>The <see cref="Player"/>'s family members.</summary>
        public List<Person> Family
        {
            get => _family;
            set { _family = value; NotifyPropertyChanged(nameof(Family)); }
        }

        /// <summary>All the <see cref="Homes"/> the <see cref="Player"/> has.</summary>
        public List<Home> Homes
        {
            get => _homes;
            set { _homes = value; NotifyPropertyChanged(nameof(Homes)); }
        }

        /// <summary>All the monthly <see cref="Vehicle"/>s the <see cref="Player"/> has.</summary>
        public List<Vehicle> Vehicles
        {
            get => _vehicles;
            set { _vehicles = value; NotifyPropertyChanged(nameof(Vehicles)); }
        }

        #endregion Modifying Properties

        #region Helper Properties

        /// <summary>The money required for all monthly bills.</summary>
        public decimal MonthlyBills => Bills.Sum(bill => bill.Cost);

        /// <summary>The money required for all monthly expenses, formatted.</summary>
        public string MonthlyBillsToString => MonthlyBills.ToString("C2");

        #endregion Helper Properties

        #region Bill Management

        /// <summary>Adds a <see cref="Bill"/> to the list of <see cref="Player"/>'s <see cref="Bill"/>s.</summary>
        /// <param name="newBill"><see cref="Bill"/> to be added</param>
        public void AddBill(Bill newBill)
        {
            Bills.Add(newBill);
            UpdateBills();
        }

        /// <summary>Replaces an old <see cref="Bill"/> in the list of <see cref="Player"/>'s <see cref="Bill"/>s with a new one.</summary>
        /// <param name="oldBill"><see cref="Bill"/> to be replaced</param>
        /// <param name="newBill"><see cref="Bill"/> to replace the old one</param>
        public void ModifyBill(Bill oldBill, Bill newBill)
        {
            Bills.Replace(oldBill, newBill);
            UpdateBills();
        }

        /// <summary>Removes a <see cref="Bill"/> from the list of <see cref="Player"/>'s <see cref="Bill"/>s.</summary>
        /// <param name="removeBill"><see cref="Bill"/> to be removed</param>
        public void RemoveBill(Bill removeBill)
        {
            Bills.Remove(removeBill);
            NotifyPropertyChanged(nameof(Bills));
        }

        /// <summary>Sorts and refreshes the list of <see cref="Bill"/>s.</summary>
        private void UpdateBills()
        {
            Bills = Bills.OrderBy(bill => bill.Name).ToList();
            NotifyPropertyChanged(nameof(Bills));
        }

        #endregion Bill Management

        #region Expense Management

        /// <summary>Adds a <see cref="Expense"/> to the list of <see cref="Player"/>'s <see cref="Expense"/>s.</summary>
        /// <param name="newExpense"><see cref="Expense"/> to be added</param>
        public void AddExpense(Expense newExpense)
        {
            Expenses.Add(newExpense);
            UpdateExpenses();
        }

        /// <summary>Replaces an old <see cref="Expense"/> in the list of <see cref="Player"/>'s <see cref="Expense"/>s with a new one.</summary>
        /// <param name="oldExpense"><see cref="Expense"/> to be replaced</param>
        /// <param name="newExpense"><see cref="Expense"/> to replace the old one</param>
        public void ModifyExpense(Expense oldExpense, Expense newExpense)
        {
            Expenses.Replace(oldExpense, newExpense);
            UpdateExpenses();
        }

        /// <summary>Removes a <see cref="Expense"/> from the list of <see cref="Player"/>'s <see cref="Expense"/>s.</summary>
        /// <param name="removeExpense"><see cref="Expense"/> to be removed</param>
        public void RemoveExpense(Expense removeExpense)
        {
            Expenses.Remove(removeExpense);
            NotifyPropertyChanged(nameof(Expenses));
        }

        /// <summary>Sorts and refreshes the list of <see cref="Expense"/>s.</summary>
        private void UpdateExpenses()
        {
            Expenses = Expenses.OrderBy(bill => bill.Name).ToList();
            NotifyPropertyChanged(nameof(Expenses));
        }

        #endregion Expense Management

        #region Family Management

        /// <summary>Adds a <see cref="Person"/> to the list of <see cref="Player"/>'s <see cref="Person"/>s.</summary>
        /// <param name="newPerson"><see cref="Person"/> to be added</param>
        public void AddPerson(Person newPerson)
        {
            Family.Add(newPerson);
            UpdateFamily();
        }

        /// <summary>Replaces an old <see cref="Person"/> in the list of <see cref="Player"/>'s <see cref="Person"/>s with a new one.</summary>
        /// <param name="oldPerson"><see cref="Person"/> to be replaced</param>
        /// <param name="newPerson"><see cref="Person"/> to replace the old one</param>
        public void ModifyPerson(Person oldPerson, Person newPerson)
        {
            Family.Replace(oldPerson, newPerson);
            UpdateFamily();
        }

        /// <summary>Removes a <see cref="Person"/> from the list of <see cref="Player"/>'s <see cref="Person"/>s.</summary>
        /// <param name="removePerson"><see cref="Person"/> to be removed</param>
        public void RemovePerson(Person removePerson)
        {
            Family.Remove(removePerson);
            UpdateFamily();
        }

        /// <summary>Sorts and refreshes the list of family.</summary>
        private void UpdateFamily()
        {
            //TODO Implement monthly expenses changing because of family members.
            NotifyPropertyChanged(nameof(Family));
        }

        #endregion Family Management

        #region Home Management

        /// <summary>Adds a <see cref="Home"/> to the list of <see cref="Player"/>'s <see cref="Home"/>s.</summary>
        /// <param name="newHome"><see cref="Home"/> to be added</param>
        public void AddHome(Home newHome)
        {
            Homes.Add(newHome);
            UpdateHomes();
        }

        /// <summary>Replaces an old <see cref="Home"/> in the list of <see cref="Player"/>'s <see cref="Home"/>s with a new one.</summary>
        /// <param name="oldHome"><see cref="Home"/> to be replaced</param>
        /// <param name="newHome"><see cref="Home"/> to replace the old one</param>
        public void ModifyHome(Home oldHome, Home newHome)
        {
            Homes.Replace(oldHome, newHome);
            UpdateHomes();
        }

        /// <summary>Removes a <see cref="Home"/> from the list of <see cref="Player"/>'s <see cref="Home"/>s.</summary>
        /// <param name="removeHome"><see cref="Home"/> to be removed</param>
        public void RemoveHome(Home removeHome)
        {
            Homes.Remove(removeHome);
            UpdateHomes();
        }

        /// <summary>Sorts and refreshes the list of <see cref="Home"/>s.</summary>
        private void UpdateHomes()
        {
            if (Homes.Count > 0)
            {
                Homes = Homes.OrderBy(home => home.Name).ToList();
                if (Bills.Any(bill => bill.Name == "Home Insurance"))
                    ModifyBill(Bills.Find(bill => bill.Name == "Home Insurance"), new Bill("Home Insurance", Homes.Sum(home => home.Insurance)));
                else
                    AddBill(new Bill("Home Insurance", Homes.Sum(home => home.Insurance)));
                if (Bills.Any(bill => bill.Name == "Home Maintenance"))
                    ModifyBill(Bills.Find(bill => bill.Name == "Home Maintenance"), new Bill("Home Maintenance", Homes.Sum(home => home.Maintenance)));
                else
                    AddBill(new Bill("Home Maintenance", Homes.Sum(home => home.Maintenance)));
            }
            else
            {
                if (Bills.Any(bill => bill.Name == "Home Insurance"))
                    RemoveBill(Bills.Find(bill => bill.Name == "Home Insurance"));
                if (Bills.Any(bill => bill.Name == "Home Maintenance"))
                    RemoveBill(Bills.Find(bill => bill.Name == "Home Maintenance"));
            }

            NotifyPropertyChanged(nameof(Homes));
        }

        #endregion Home Management

        #region Vehicle Management

        /// <summary>Adds a <see cref="Vehicle"/> to the list of <see cref="Player"/>'s <see cref="Vehicle"/>s.</summary>
        /// <param name="newVehicle"><see cref="Vehicle"/> to be added</param>
        public void AddVehicle(Vehicle newVehicle)
        {
            Vehicles.Add(newVehicle);
            UpdateVehicles();
        }

        /// <summary>Replaces an old <see cref="Vehicle"/> in the list of <see cref="Player"/>'s <see cref="Vehicle"/>s with a new one.</summary>
        /// <param name="oldVehicle"><see cref="Vehicle"/> to be replaced</param>
        /// <param name="newVehicle"><see cref="Vehicle"/> to replace the old one</param>
        public void ModifyVehicle(Vehicle oldVehicle, Vehicle newVehicle)
        {
            Vehicles.Replace(oldVehicle, newVehicle);
            UpdateVehicles();
        }

        /// <summary>Removes a <see cref="Vehicle"/> from the list of <see cref="Player"/>'s <see cref="Vehicle"/>s.</summary>
        /// <param name="removeVehicle"><see cref="Vehicle"/> to be removed</param>
        public void RemoveVehicle(Vehicle removeVehicle)
        {
            Vehicles.Remove(removeVehicle);
            UpdateVehicles();
        }

        /// <summary>Sorts and refreshes the list of <see cref="Vehicle"/>s.</summary>
        private void UpdateVehicles()
        {
            if (Vehicles.Count > 0)
            {
                Vehicles = Vehicles.OrderBy(vehicle => vehicle.Name).ToList();
                if (Bills.Any(bill => bill.Name == "Vehicle Insurance"))
                    ModifyBill(Bills.Find(bill => bill.Name == "Vehicle Insurance"), new Bill("Vehicle Insurance", Vehicles.Sum(vehicle => vehicle.Insurance)));
                else
                    AddBill(new Bill("Vehicle Insurance", Vehicles.Sum(vehicle => vehicle.Insurance)));
                if (Bills.Any(bill => bill.Name == "Vehicle Maintenance"))
                    ModifyBill(Bills.Find(bill => bill.Name == "Vehicle Maintenance"), new Bill("Vehicle Maintenance", Vehicles.Sum(vehicle => vehicle.Maintenance)));
                else
                    AddBill(new Bill("Vehicle Maintenance", Vehicles.Sum(vehicle => vehicle.Maintenance)));
            }
            else
            {
                if (Bills.Any(bill => bill.Name == "Vehicle Insurance"))
                    RemoveBill(Bills.Find(bill => bill.Name == "Vehicle Insurance"));
                if (Bills.Any(bill => bill.Name == "Vehicle Maintenance"))
                    RemoveBill(Bills.Find(bill => bill.Name == "Vehicle Maintenance"));
            }

            NotifyPropertyChanged(nameof(Vehicles));
        }

        #endregion Vehicle Management
    }
}