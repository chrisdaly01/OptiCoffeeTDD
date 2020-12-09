using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptiCoffeeTDD.DIConfig;
using OptiCoffeeTDD.Interfaces;
using Xunit;

namespace OptiCoffeeTDD.Tests
{
    public class CoffeeCommandsTestFixture
    {
        public IServiceProvider serviceProvider { get; }

        public CoffeeCommandsTestFixture()
        {
            serviceProvider = DIConfigurator.ConfigureDI();
        }
    }
    public class CoffeeCommandsTests : IClassFixture<CoffeeCommandsTestFixture>
    {
        private ICoffeeMachineCommandProvider commands;
        public CoffeeCommandsTests(CoffeeCommandsTestFixture fixture, ICoffeeMachineCommandProvider commands)
        {
            this.commands = commands;
        }

        [Fact]
        public void IncrementSugarCommandIncreasesSugarByOne()
        {
            // Arrange
           Assert.True(commands != null); 
        }
    }
}
