using System;

namespace OptiCoffeeTDD.DomainModels
{
    public class InvalidMoneyException : Exception
    {
        public InvalidMoneyException(string message) : base(message) { }
    }
}