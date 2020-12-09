namespace OptiCoffeeTDD.Interfaces
{
    public interface ICoffeeMachineController
    {
        ICoffeeOrder Orders { get; set; }
        ICoffeeMachineCommandResponse ExecuteCommand(ICommand command);
    }
}