using System;
using System.Collections.Generic;

namespace Task4.Solution.SecondVariant
{
    public class Calculator
    {
        public double Calculate(List<double> values, AverageMethod method)
        {
            if (ReferenceEquals(values, null))
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (ReferenceEquals(method, null))
            {
                throw new ArgumentNullException(nameof(method));
            }

            return method.Calculate(values);
        }
    }
}
