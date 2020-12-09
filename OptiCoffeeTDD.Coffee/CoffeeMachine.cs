using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using OptiCoffeeTDD.DomainModels.CommandProvider.Commands;
using OptiCoffeeTDD.Interfaces;
using OptiCoffeeTDD.Interfaces.CrossCutting;
using static OptiCoffeeTDD.EnumsAndConstants.Enums;

namespace OptiCoffeeTDD.DomainModels
{

    // Represents the part of the system with which
    // the user interacts.  Could be a website, command line
    // menu interface, etc.  This is a console based menu.
    public class CoffeeMachine : ICoffeeMachine
    {
        private ICoffeeMachineController controller;
        private ICoffeeMachineLogger logger;
        private IOutputHandler outputHandler;
        private ICoffeeMachineCommandProvider commands;

        public CoffeeMachine(ICoffeeMachineCommandProvider commands, ICoffeeMachineController controller, ICoffeeMachineLogger logger,
            IOutputHandler outputHandler)
        {
            this.controller = controller;
            this.logger = logger;
            this.outputHandler = outputHandler;
            this.commands = commands;
        }

        private string ShowOptionsMenuToCustomer()
        {
            // TODO:Should be using a data structure to organize
            // this with the enum and produce the list dynamically
            // just no time yet.
            DisplayOutput("[1] Select Small Coffee");
            DisplayOutput("[2] Select Medium Coffee");
            DisplayOutput("[3] Select Large Coffee");
            DisplayOutput("[4] Increment Sugar");
            DisplayOutput("[5] Decrement Sugar");
            DisplayOutput("[6] Increment Cream");
            DisplayOutput("[7] Decrement Cream");
            DisplayOutput("[8] Add currently working coffee to order");
            DisplayOutput("[9] Show Current Working Coffee");
            DisplayOutput("[10] Show Current Order and Total");
            DisplayOutput("[11] Add Payment");
            DisplayOutput("[12] Dispense Order and Change");
            DisplayOutput("Enter Your Selection: ");
            var selection = Console.ReadLine();
            outputHandler.ClearOutput();
            return selection;
        }

        public void HandleUserInput()
        {
            while (true)
            {
                var userSelection = ShowOptionsMenuToCustomer();
                ICommand command = ParseUserInput(userSelection);
                if (command != null)
                {
                    // TODO: use state here
                    if (command is AddMoneyCommand moneyCommand)
                    {
                        outputHandler.WriteOutput("Please enter an amount to add:");
                        string input = Console.ReadLine();
                        int.TryParse(input, out int result);
                        moneyCommand.SetAmount(result);
                        command = moneyCommand;
                    }
                    SendCommandToController(command);
                }
            }
        }

        public void SendCommandToController(ICommand command)
        {
            logger.WriteInfo($"Sending command {command} to controller");
            ICoffeeMachineCommandResponse response = controller.ExecuteCommand(command);
            if (!String.IsNullOrEmpty(response.message))
            {
                outputHandler.WriteOutput(response.message);
            }
        }

        public void DisplayOutput(string message)
        {
            outputHandler.WriteOutput(message);
        }

        private ICommand ParseUserInput(string input)
        {
            // TODO: Improve this for type safety
            int.TryParse(input, out int result);
            return commands.GetCommand((CoffeeMachineOperations)result);
        }
    }

    public class CoffeeMachineConsoleLogger : ICoffeeMachineLogger
    {
        private bool errorsOnly = false;

        public void WriteError(string message)
        {
            Console.WriteLine($"ERROR: {message}");
        }

        public void SetInfoFlag(bool value)
        {
            errorsOnly = value;
        }

        public void WriteInfo(string message)
        {
            if (!errorsOnly)
            {
                Console.WriteLine($"INFO: {message}");
            }
        }
    }

    public class CoffeeMachineConsoleOutputHandler : IOutputHandler
    {
        public void WriteOutput(string output)
        {
            Console.WriteLine(output);
        }

        public void ClearOutput()
        {
            Console.Clear();
        }
    }

}
