using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApplication
{

    internal class CalculatorClass
    {
        public delegate T Formula<T>(T arg1);

        public Formula<string> info;

        public double GetSum(double a, double b)
        {
            return a + b;
        }

        public double GetDifference(double a, double b)
        {
            return a - b;
        }
    }

}

