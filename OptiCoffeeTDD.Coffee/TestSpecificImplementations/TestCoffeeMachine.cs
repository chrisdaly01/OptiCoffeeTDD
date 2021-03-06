﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptiCoffeeTDD.Interfaces;
using OptiCoffeeTDD.Interfaces.CrossCutting;
using OptiCoffeeTDD.Interfaces.TestSpecificInterfaces;

namespace OptiCoffeeTDD.DomainModels.TestSpecificImplementations
{
    public class TestCoffeeMachine : CoffeeMachine, ITestCoffeeMachine
    {
        public ICoffeeMachineController controller { get; set; }

        public TestCoffeeMachine(ICoffeeMachineCommandProvider commands,
            ICoffeeMachineController controller,
            ICoffeeMachineLogger logger,
            IOutputHandler outputHandler) : base(commands,
            controller,
            logger,
            outputHandler) =>
            this.controller = controller;
    }
}
