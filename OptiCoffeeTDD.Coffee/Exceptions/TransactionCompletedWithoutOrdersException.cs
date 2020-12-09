using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCoffeeTDD.DomainModels.Exceptions
{
    class TransactionCompletedWithoutOrdersException : Exception
    {
        public TransactionCompletedWithoutOrdersException(string message) : base(message) {}
    }
}
