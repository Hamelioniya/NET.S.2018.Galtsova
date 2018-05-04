using System;
using System.Collections.Generic;

namespace Task4.Solution.FirstVariant
{
    public class Calculator
    {
        public double CalculateAverage(List<double> values, IAverageCalculator averageCalculator)
        {
            if (ReferenceEquals(values, null))
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (ReferenceEquals(averageCalculator, null))
            {
                throw new ArgumentNullException(nameof(averageCalculator));
            }

            return averageCalculator.Calculate(values);
        }
    }
}
