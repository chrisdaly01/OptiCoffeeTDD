using System;
using System.Collections.Generic;
using System.Linq;
using OptiCoffeeTDD.DomainModels.CommandProvider.Commands;
using OptiCoffeeTDD.EnumsAndConstants;
using OptiCoffeeTDD.Interfaces;
using static OptiCoffeeTDD.EnumsAndConstants.Enums.CoffeeMachineOperations;

namespace OptiCoffeeTDD.DomainModels
{
    public class CoffeeMachineCommandProvider : ICoffeeMachineCommandProvider
    {
        private IDictionary<Enums.CoffeeMachineOperations, ICommand> commands;

        public CoffeeMachineCommandProvider()
        {
            // Adding this type to DI was causing a circular reference for me
            // But don't have time to chase that down just now
            commands = new Dictionary<Enums.CoffeeMachineOperations, ICommand>();
            InitializeCommands();
        }

        public ICommand GetCommand(Enums.CoffeeMachineOperations operation)
        { 
            commands.TryGetValue(operation, out ICommand parsedCommand);
            return parsedCommand;
        }

        private void InitializeCommands()
        {
            // Ambivalent about newing these commands up here.
            // On the one hand I feel like I should be using DI
            // and on the other hand they're so closely linked
            // they'll never be in a separate repo
            ICommand acceptCommand = new AcceptCurrentWorkingCoffeeCommand();
            ICommand addMoneyCommand = new AddMoneyCommand();
            ICommand showOrderCommand = new ShowOrderCommand();
            ICommand setSizeCommand = new SetSizeCommand();
            ICommand setCreamCommand = new SetCreamCommand();
            ICommand setSugarCommand = new SetSugarCommand();
            ICommand incrementCreamCommand = new IncrementCreamCommand();
            ICommand incrementSugarCommand = new IncrementSugarCommand();
            ICommand decrementCreamCommand = new DecrementCreamCommand();
            ICommand decrementSugarCommand = new DecrementSugarCommand();
            ICommand selectSmallCommand = new SelectSmallCommand();
            ICommand selectMediumCommand = new SelectMediumCommand();
            ICommand selectLargeCommand = new SelectLargeCommand();
            ICommand showCurrentWorkingCoffee = new ShowCurrentWorkingCoffeeCommand();
            ICommand completeTransactionCommand = new CompleteTransactionCommand();

            commands.Add(ADD_PAYMENT, addMoneyCommand);
            commands.Add(ACCEPT_CURRENT_WORKING_COFFEE, acceptCommand);
            commands.Add(SHOW_CURRENT_ORDER_AND_TOTAL, showOrderCommand);
            commands.Add(SET_SIZE, setSizeCommand);
            commands.Add(SET_CREAM, setCreamCommand);
            commands.Add(SET_SUGAR, setSugarCommand);
            commands.Add(SELECT_SMALL_COFFEE, selectSmallCommand);
            commands.Add(SELECT_MEDIUM_COFFEE, selectMediumCommand);
            commands.Add(SELECT_LARGE_COFFEE, selectLargeCommand);
            commands.Add(INCREMENT_CREAM, incrementCreamCommand);
            commands.Add(INCREMENT_SUGAR, incrementSugarCommand);
            commands.Add(DECREMENT_CREAM, decrementCreamCommand);
            commands.Add(DECREMENT_SUGAR, decrementSugarCommand);
            commands.Add(SHOW_CURRENT_WORKING_COFFEE, showCurrentWorkingCoffee);
            commands.Add(DISPENSE_ORDER_AND_CHANGE, completeTransactionCommand);
        }
    }
}