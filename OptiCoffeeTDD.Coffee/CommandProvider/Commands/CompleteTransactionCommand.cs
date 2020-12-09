using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptiCoffeeTDD.EnumsAndConstants;
using OptiCoffeeTDD.Interfaces;

namespace OptiCoffeeTDD.DomainModels.CommandProvider.Commands
{
    public class CompleteTransactionCommand : ICommand
    {
        public ICoffeeMachineCommandResponse Execute(ICoffeeOrder order)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(order.CompleteTransaction());
            sb.Append("\r\n\r\nYour order appears below:\r\n\r\n");
            sb.Append(order.ToString());
            return new CoffeeMachineCommandResponse(sb.ToString());
        }
    }

    // Transaction Commands
    public class AddMoneyCommand : ICommand
    {
        private decimal amount;

        public AddMoneyCommand(decimal amount = 0)
        {
            this.amount = amount;
        }

        public ICoffeeMachineCommandResponse Execute(ICoffeeOrder order)
        {
            order.AddMoney(amount);
            return new CoffeeMachineCommandResponse($"${amount} dollars added. New total is ${order.MoneyAdded}");
        }

        public void SetAmount(decimal amount)
        {
            this.amount = amount;
        }

    }
    public class ShowOrderCommand : ICommand
    {
        public ICoffeeMachineCommandResponse Execute(ICoffeeOrder order)
        {
            return new CoffeeMachineCommandResponse(order.ToString());
        }
    }


    // Current Working Coffee Commands
    public class AcceptCurrentWorkingCoffeeCommand : ICommand
    {
        public ICoffeeMachineCommandResponse Execute(ICoffeeOrder order)
        {
            order.FinalizeWorkingCoffee();
            return new CoffeeMachineCommandResponse("Current working coffee added to order");
        }
    }
    public class DecrementCreamCommand : ICommand
    {
        public ICoffeeMachineCommandResponse Execute(ICoffeeOrder order)
        {
            order.SetCurrentWorkingCoffeeCreams(order.CurrentWorkingCoffee.Creams - 1);
            return new CoffeeMachineCommandResponse($"Creams reduced by 1 to {order.CurrentWorkingCoffee.Creams}.");
        }
    }
    public class DecrementSugarCommand : ICommand
    {
        public ICoffeeMachineCommandResponse Execute(ICoffeeOrder order)
        {
            order.SetCurrentWorkingCoffeeSugars(order.CurrentWorkingCoffee.Sugars - 1);
            return new CoffeeMachineCommandResponse($"Sugars reduced by 1 to {order.CurrentWorkingCoffee.Sugars}.");
        }
    }


    public class IncrementCreamCommand : ICommand
    {
        public ICoffeeMachineCommandResponse Execute(ICoffeeOrder order)
        {
            int creams = order.CurrentWorkingCoffee?.Creams ?? 0;

            order.SetCurrentWorkingCoffeeCreams(++creams);
            return new CoffeeMachineCommandResponse($"Creams increased by 1 to {order.CurrentWorkingCoffee.Creams}.");
        }
    }
    public class IncrementSugarCommand : ICommand
    {
        public ICoffeeMachineCommandResponse Execute(ICoffeeOrder order)
        {
            int sugars = order.CurrentWorkingCoffee?.Sugars ?? 1;

            order.SetCurrentWorkingCoffeeSugars(sugars);
            return new CoffeeMachineCommandResponse($"Sugars increased by 1 to {order.CurrentWorkingCoffee.Sugars}.");
        }
    }

    public class SelectSmallCommand : ICommand
    {
        public ICoffeeMachineCommandResponse Execute(ICoffeeOrder order)
        {
            order.SetCurrentWorkingCoffeeSize(Enums.CoffeeSize.SMALL);
            return new CoffeeMachineCommandResponse("Small coffee selected.");
        }
    }
    public class SelectMediumCommand : ICommand
    {
        public ICoffeeMachineCommandResponse Execute(ICoffeeOrder order)
        {
            order.SetCurrentWorkingCoffeeSize(Enums.CoffeeSize.MEDIUM);
            return new CoffeeMachineCommandResponse("Medium coffee selected.");
        }
    }

    public class SelectLargeCommand : ICommand
    {
        public ICoffeeMachineCommandResponse Execute(ICoffeeOrder order)
        {
            order.SetCurrentWorkingCoffeeSize(Enums.CoffeeSize.LARGE);
            return new CoffeeMachineCommandResponse("Large coffee selected");
        }
    }


    public class SetSizeCommand : ICommand
    {
        public Enums.CoffeeSize Size { get; private set; }

        public void SetSize(Enums.CoffeeSize size) => this.Size = size;

        public ICoffeeMachineCommandResponse Execute(ICoffeeOrder order)
        {
            order.SetCurrentWorkingCoffeeSize(Size);
            //TODO: Add description for friendly enum strings
            return new CoffeeMachineCommandResponse($"Coffee size set to ${Size}");
        }
    }

    public class SetCreamCommand : ICommand
    {
        public int Creams { get; private set; }

        public void SetCreams(int creams) => this.Creams = Creams;

        public ICoffeeMachineCommandResponse Execute(ICoffeeOrder order)
        {
            order.SetCurrentWorkingCoffeeCreams(Creams);
            return new CoffeeMachineCommandResponse($"Coffee creams set to ${Creams}");
        }
    }

    public class SetSugarCommand : ICommand
    {
        public int Sugars { get; private set; }

        public void SetSugar(int sugars) => this.Sugars = sugars;

        public ICoffeeMachineCommandResponse Execute(ICoffeeOrder order)
        {
            order.SetCurrentWorkingCoffeeCreams(Sugars);
            return new CoffeeMachineCommandResponse($"Coffee sugars set to ${Sugars}");
        }
    }

    public class ShowCurrentWorkingCoffeeCommand : ICommand
    {
        public ICoffeeMachineCommandResponse Execute(ICoffeeOrder order)
        {
            return new CoffeeMachineCommandResponse(order.CurrentWorkingCoffee.ToString());
        }
    }


}

