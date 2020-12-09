using System;

namespace OptiCoffeeTDD.DomainModels
{
    public class CondimentQuantityException : Exception
    {
        public CondimentQuantityException(string message) : base(message) { }
    }
}