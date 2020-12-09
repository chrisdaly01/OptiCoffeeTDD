using System.Collections.Generic;
using System.Linq;
using System.Text;
using OptiCoffeeTDD.EnumsAndConstants;
using OptiCoffeeTDD.Interfaces;
using OptiCoffeeTDD.Interfaces.CrossCutting;
using static OptiCoffeeTDD.EnumsAndConstants.Constants;

namespace OptiCoffeeTDD.DomainModels
{
    public class CoffeeOrder : ICoffeeOrder
    {
        private ICoffeeMachineLogger logger;

        public int Length => FinalizedCoffees.Count();
        public ICoffee CurrentWorkingCoffee { get; private set; } = null;
        public IEnumerable<ICoffee> FinalizedCoffees { get; private set; } = new List<ICoffee>();
        public decimal MoneyAdded { get; private set; }

        public CoffeeOrder(IEnumerable<ICoffee> finalizedCoffees, ICoffeeMachineLogger consoleLogger)
        {
            FinalizedCoffees = finalizedCoffees;
        }

        // Transaction-based methods
        public string CompleteTransaction()
        {
            StringBuilder sb = new StringBuilder();
            // Not sure why but couldn't get FinalizedCoffees.ToList().Clear() to work
            // Do want to get rid of this initialization here
            FinalizedCoffees = new List<ICoffee>();
            return $"Thank you for your patronage.  Your change is: {MoneyAdded - GetTotalPrice()}";
        }

        public void AddMoney(decimal amount)
        {
            if (((amount * 100 % 5) != 0) && (amount + MoneyAdded > 20))
            {
                throw new InvalidMoneyException($"Money must be added in .05 cent increments and may not exceed $20.00");
            }

            MoneyAdded += amount;
        }

        // Current Working Coffee management methods
        public void FinalizeWorkingCoffee()
        {
            if (CurrentWorkingCoffee == null)
            {
                // Not really the end of the world.  Just going to log an error.
                logger.WriteError("Tried to add null working coffee to order.");
                return;
            }

            FinalizedCoffees = FinalizedCoffees.Append(CurrentWorkingCoffee);
            CurrentWorkingCoffee = null;
        }

        public void SetCurrentWorkingCoffeeSize(Enums.CoffeeSize size)
        {
            SetCurrentWorkingCoffeeIfNull();
            CurrentWorkingCoffee.Size = size;
        }

        public void SetCurrentWorkingCoffeeSugars(int sugars)
        {
            if (sugars > MAX_SUGARS || sugars < 0)
            {
                throw new CondimentQuantityException($"Sugar selection must be between 0 and {MAX_SUGARS}");
            }

            SetCurrentWorkingCoffeeIfNull();
            CurrentWorkingCoffee.Sugars = sugars;
        }

        public void SetCurrentWorkingCoffeeCreams(int creams)
        {
            if (creams > MAX_SUGARS || creams < 0)
            {
                throw new CondimentQuantityException($"Cream selection must be between 0 and {MAX_CREAMS}");
            }

            SetCurrentWorkingCoffeeIfNull();
            CurrentWorkingCoffee.Creams = creams;
        }

        // utility
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            FinalizedCoffees?.ToList().ForEach(c => sb.AppendLine(c.ToString()));
            sb.AppendLine();
            sb.AppendLine($"The total cost of your order is ${GetTotalPrice()}");
            return sb.ToString();
        }

        // Private
        private void SetCurrentWorkingCoffeeIfNull()
        {
            CurrentWorkingCoffee ??= new Coffee();
        }

        private decimal GetTotalPrice()
        {
            return FinalizedCoffees.Select(c => c.GetPrice()).Sum();
        }

    }
}