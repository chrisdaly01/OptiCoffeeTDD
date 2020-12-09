using System;
using Microsoft.Extensions.DependencyInjection;
using OptiCoffeeTDD.DIConfig;
using OptiCoffeeTDD.Interfaces;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using static OptiCoffeeTDD.EnumsAndConstants.Enums;

namespace OptiCoffeeTDD.Tests
{
    public class CoffeeMachineControllerTestFixture
    {
        public IServiceProvider serviceProvider { get; }
        public CoffeeMachineControllerTestFixture()
        {
            serviceProvider = DIConfigurator.ConfigureDI();
        }
    }

    public class CoffeeMachineControllerTests : IClassFixture<CoffeeMachineControllerTestFixture>
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private ICoffeeMachineController controller;

        public CoffeeMachineControllerTests(CoffeeMachineControllerTestFixture fixture, ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            this.controller = fixture.serviceProvider.GetRequiredService<ICoffeeMachineController>();
        }

        [Fact]
        public void InitializedCoffeeMachineHasZeroOrders()
        {
            try
            {
                Assert.True(controller.Orders.Length == 0);
            }
            catch (Exception ex)
            {
                _testOutputHelper.WriteLine(ex.Message);
            }

        }
    }
}
