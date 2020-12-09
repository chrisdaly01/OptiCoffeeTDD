using Microsoft.Extensions.DependencyInjection;
using OptiCoffeeTDD.DIConfig;
using OptiCoffeeTDD.Interfaces;
using Xunit;
using static OptiCoffeeTDD.EnumsAndConstants.Constants;
using static OptiCoffeeTDD.EnumsAndConstants.Enums;

namespace OptiCoffeeTDD.Tests
{

    public class CoffeeTests
    {
        private ICoffee coffee;
        public CoffeeTests()
        {
            var serviceProvider = DIConfigurator.ConfigureDI();
            coffee = serviceProvider.GetRequiredService<ICoffee>();
        }

        [Fact]
        public void CoffeeReportsCorrectPrice()
        {
            // Arrange
            coffee.Size = CoffeeSize.LARGE;
            coffee.Sugars = 1;
            coffee.Creams = 1;

            // Act
            decimal price = coffee.GetPrice();

            // Assert
            Assert.True(price == (LARGE_PRICE + SUGAR_PRICE + CREAM_PRICE));

        }
    }
}
