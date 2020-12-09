using OptiCoffeeTDD.Interfaces;

namespace OptiCoffeeTDD.DomainModels
{
    // Imagining this as a contract to describe the workings
    // of a physical machine, irrespective of interface.
    // It's the job of the test or app project to marshall the proper
    // input to the state machine.

    // Thus, there are methods for:

    // Adding a Coffee of a given size to the transaction as a current working coffee
    // Setting the cream and sugar for the current working coffee
    // Finalize a currently working coffee (add it to the transaction list)
    // Add Money (in .05 increments)
    // Request order be dispensed
    public class CoffeeMachineController : ICoffeeMachineController
    {
        public ICoffeeOrder Orders { get; set; }
        public ICoffeeMachineCommandProvider Commands { get; set; }
        public CoffeeMachineController(ICoffeeOrder orders, ICoffeeMachineCommandProvider commands)
        {
            Orders = orders;
            Commands = commands;
        }

        public ICoffeeMachineCommandResponse ExecuteCommand(ICommand command) => command.Execute(Orders);
    }


    public class CoffeeMachineCommandResponse : ICoffeeMachineCommandResponse
    {
        public string message { get; }

        public CoffeeMachineCommandResponse(string message = "") => this.message = message;

    }
}
