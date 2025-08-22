using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApplication
{

    internal class CalculatorClass
    {
        public delegate T Formula<T>(T arg1, T arg2);

        private Formula<double> _calculateEvent;

        public event Formula<double> _CalculateEvent
        {

            add
            {

                Console.WriteLine("Added the Delegate");
                _calculateEvent += value;
            }

            remove
            {

                Console.WriteLine("Removed the Delegate");
                _calculateEvent -= value;
            }
        }


        public double GetSum(double a, double b)
        {
            return a + b;
        }

        public double GetDifference(double a, double b)
        {
            return a - b;
        }
        public double GetProduct(double a, double b)
        {
            return a * b;
        }
        public double GetQuotient(double a, double b)
        {
            return a / b;
        }



        public void InvokeCalculateEvent(double a, double b)
        {
            if (_calculateEvent != null)
            {
                _calculateEvent(a, b);
            }
        }

    }

}


