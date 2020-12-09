using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCoffeeTDD.Interfaces.CrossCutting
{
    public interface ICoffeeMachineLogger
    {
        public void WriteError(string message);
        public void WriteInfo(string message);

    }
}
