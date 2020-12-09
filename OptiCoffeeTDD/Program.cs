using System;
using Microsoft.Extensions.DependencyInjection;
using OptiCoffeeTDD.DomainModels;
using OptiCoffeeTDD.Interfaces;

namespace OptiCoffeeTDD.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Opti Coffee Shop!");
            var serviceProvider = DIConfig.DIConfigurator.ConfigureDI();
            ICoffeeMachine machine = serviceProvider.GetRequiredService<ICoffeeMachine>();
            machine.HandleUserInput();
        }
    }
}
