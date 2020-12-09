using System;
using System.Collections.Generic;
using System.Text;

namespace OptiCoffeeTDD.Coffee
{
    public class CoffeeMachine
    {
        public ICoffeeMachineState State { get; set; }

        public CoffeeMachine(ICoffeeMachineState state)
        {
            State = state;
        }
    }

    public interface ICoffeeOrder
    {
        public int Length { get; set; }
    }
    public class CoffeeOrder
    {
        public int Length { get; set; } = 0;
    }

    public interface ICoffeeMachineState
    {

    }

    public class CoffeeMachineState : ICoffeeMachineState
    {

    }
}
