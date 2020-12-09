using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using OptiCoffeeTDD.DIConfig;
using OptiCoffeeTDD.DomainModels;
using OptiCoffeeTDD.EnumsAndConstants;
using OptiCoffeeTDD.Interfaces;
using Xunit;
using static OptiCoffeeTDD.EnumsAndConstants.Enums;
using static OptiCoffeeTDD.EnumsAndConstants.Enums.CoffeeSize;

namespace OptiCoffeeTDD.Tests
{
    public class CoffeeOrderTestFixture
    {
        public IServiceProvider serviceProvider { get; }

        public CoffeeOrderTestFixture()
        {
            serviceProvider = DIConfigurator.ConfigureDI();
        }
    }

    public class CoffeeOrderTests : IClassFixture<CoffeeOrderTestFixture>
    {
        private ICoffeeOrder order;

        public CoffeeOrderTests(CoffeeOrderTestFixture fixture)
        {
            this.order = fixture.serviceProvider.GetRequiredService<ICoffeeOrder>();
        }

        [Fact]
        public void CurrentWorkingCoffeeInitializedAsNull() => Assert.True(order.CurrentWorkingCoffee is null);

        [Fact]
        public void CoffeeOrderCorrectlyRecordsAddedMoney()
        {
            Assert.True(true);
        }

        [Fact]
        public void CoffeeOrderCorrectlyAddsCoffeeSize()
        {
            // Arrange
            CoffeeSize newSize = LARGE;
            // Act
            order.SetCurrentWorkingCoffeeSize(newSize);
            // Assert
            Assert.True(order.CurrentWorkingCoffee.Size == newSize);
        }

        [Fact]
        public void CoffeeInProgressShowsCorrectNumberOfCreamsAfterChanges()
        {
            // Arrange
            int numCreams = 2;

            // Act
            order.SetCurrentWorkingCoffeeCreams(numCreams);

            // Assert
            Assert.True(order.CurrentWorkingCoffee.Creams == numCreams);

        }

        [Fact]
        public void CoffeeInProgressShowsCorrectNumberOfSugarsAfterSetting()
        {
            // Arrange
            int numSugars = 2;

            // Act
            order.SetCurrentWorkingCoffeeSugars(numSugars);

            // Assert
            Assert.True(order.CurrentWorkingCoffee.Sugars == numSugars);
        }

        [Fact]
        public void CoffeeMachineShowsCorrectNumberOfOrdersAfterAdditions()
        {
            // Arrange
            CoffeeSize size1 = LARGE;
            CoffeeSize size2 = SMALL;

            // Act
            order.SetCurrentWorkingCoffeeSize(size1);
            order.FinalizeWorkingCoffee();

            order.SetCurrentWorkingCoffeeSize(size2);
            order.FinalizeWorkingCoffee();

            // Assert
            Assert.True(order.FinalizedCoffees.Count() == 2);
        }

        [Fact]
        public void CoffeeMachineEmptiesOrderAfterTransactionCompleted()
        {
            decimal amount = 20.00M;

            // Arrange
            order.SetCurrentWorkingCoffeeSize(MEDIUM);
            order.FinalizeWorkingCoffee();
            order.AddMoney(amount);

            // Act
            order.CompleteTransaction();

            // Assert
            Assert.True(!order.FinalizedCoffees.ToList().Any());
        }
    }
}
