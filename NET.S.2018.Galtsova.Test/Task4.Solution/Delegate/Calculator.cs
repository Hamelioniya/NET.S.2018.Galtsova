using System;
using System.Collections.Generic;

namespace Task4.Solution.Delegate
{
    public class Calculator
    {
        public double Calculate(List<double> values, Func<List<double>, double> averageCalculator)
        {
            if (ReferenceEquals(values, null))
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (ReferenceEquals(averageCalculator, null))
            {
                throw new ArgumentNullException(nameof(averageCalculator));
            }

            return averageCalculator(values);
        }
    }
}
