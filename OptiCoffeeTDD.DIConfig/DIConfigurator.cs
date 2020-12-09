using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using OptiCoffeeTDD.DomainModels;
using OptiCoffeeTDD.DomainModels.TestSpecificImplementations;
using OptiCoffeeTDD.EnumsAndConstants;
using OptiCoffeeTDD.Interfaces;
using OptiCoffeeTDD.Interfaces.CrossCutting;
using OptiCoffeeTDD.Interfaces.TestSpecificInterfaces;

namespace OptiCoffeeTDD.DIConfig
{
    public class DIConfigurator
    {
        public static ServiceProvider ConfigureDI()
        {
            return new ServiceCollection()
                .AddTransient<ICoffeeMachineController, CoffeeMachineController>()
                .AddTransient<ICoffeeOrder, CoffeeOrder>()
                .AddTransient<ICoffeeMachine, CoffeeMachine>()
                .AddTransient<ITestCoffeeMachine, TestCoffeeMachine>()
                .AddTransient<ICoffeeMachineLogger, CoffeeMachineConsoleLogger>()
                .AddTransient<ICoffee, Coffee>()
                .AddTransient<IOutputHandler, CoffeeMachineConsoleOutputHandler>()
                .AddTransient<ICoffeeMachineCommandProvider, CoffeeMachineCommandProvider>()
                .AddTransient<IEnumerable<ICoffee>, List<Coffee>>()
                .AddTransient<IDictionary<Enums.CoffeeMachineOperations, ICommand>, Dictionary<Enums.CoffeeMachineOperations, ICommand>>()
                .BuildServiceProvider();
        }
    }
}
