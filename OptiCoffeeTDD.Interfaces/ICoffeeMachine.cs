using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OptiCoffeeTDD.EnumsAndConstants;

namespace OptiCoffeeTDD.Interfaces
{
    // Contract for the coffee machine's UI
    // Represents a basic machine with specific 
    // buttons for most operations
    // One can imagine many other varieties of implementation
    // that would work with the same controller.
    public interface ICoffeeMachine
    {
        void HandleUserInput();

        void DisplayOutput(string message);
    }
    public interface IOutputHandler
    {
        void WriteOutput(string output);
        void ClearOutput();
    }

    // Might ultimately be used for commands?
    public interface IInputHandler
    {
        void HandleInput();
    }

    public interface ICommand
    {
        public ICoffeeMachineCommandResponse Execute(ICoffeeOrder order);
    }

    public interface ICoffeeMachineCommandResponse
    {
        public string message { get; }
    }

    public interface ICoffeeMachineCommandProvider
    {
       ICommand GetCommand(Enums.CoffeeMachineOperations operation);
    }
}
