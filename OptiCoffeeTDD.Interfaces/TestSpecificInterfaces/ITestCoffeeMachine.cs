namespace OptiCoffeeTDD.Interfaces.TestSpecificInterfaces
{
    public interface ITestCoffeeMachine : ICoffeeMachine
    {
        // lowercase names are usually private, but in this
        // case I'm trying to hide a private var on the parent
        // so I can get at it for testing.
        public ICoffeeMachineController controller { get; set; }
        
    }
}