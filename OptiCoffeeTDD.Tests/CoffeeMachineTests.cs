using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OptiCoffeeTDD.DIConfig;
using OptiCoffeeTDD.Interfaces;
using OptiCoffeeTDD.Interfaces.TestSpecificInterfaces;
using Xunit;
using static OptiCoffeeTDD.EnumsAndConstants.Enums;

namespace OptiCoffeeTDD.Tests
{
    public class CoffeeMachineTestFixture
    {
        public IServiceProvider serviceProvider { get; }
        public ITestCoffeeMachine coffeeMachine { get; }

        public CoffeeMachineTestFixture()
        {
            serviceProvider = DIConfigurator.ConfigureDI();
            coffeeMachine = serviceProvider.GetRequiredService<ITestCoffeeMachine>();
        }
    }


     
    public class CoffeeMachineTests : IClassFixture<CoffeeMachineTestFixture>
    {
        private ITestCoffeeMachine coffeeMachine;

        public CoffeeMachineTests(CoffeeMachineTestFixture fixture)
        {
            this.coffeeMachine = fixture.coffeeMachine;
        }
  

    }
}

