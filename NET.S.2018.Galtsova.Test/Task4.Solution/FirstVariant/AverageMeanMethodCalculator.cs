using System.Collections.Generic;
using System.Linq;

namespace Task4.Solution.FirstVariant
{
    public class AverageMeanMethodCalculator : IAverageCalculator
    {
        public double Calculate(List<double> values)
        {
            return values.Sum() / values.Count;
        }
    }
}
