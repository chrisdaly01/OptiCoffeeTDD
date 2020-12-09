using System.Collections.Generic;
using System.Linq;
using OptiCoffeeTDD.EnumsAndConstants;

namespace OptiCoffeeTDD.Interfaces
{
    public interface ICoffeeOrder
    {
        public int Length { get; }
        public decimal MoneyAdded { get; }
        public void AddMoney(decimal amount); 
        public ICoffee CurrentWorkingCoffee { get; }
        public IEnumerable<ICoffee> FinalizedCoffees { get; }

        public string CompleteTransaction();

        public void FinalizeWorkingCoffee();

        public void SetCurrentWorkingCoffeeSize(Enums.CoffeeSize size);

        public void SetCurrentWorkingCoffeeSugars(int sugars);

        public void SetCurrentWorkingCoffeeCreams(int creams);
    }
}