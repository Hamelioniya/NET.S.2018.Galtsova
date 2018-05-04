using System.Collections.Generic;
using System.Linq;

namespace Task4.Solution.SecondVariant
{
    public class AverageMeanMethod : AverageMethod
    {
        public override double Calculate(List<double> values)
        {
            return values.Sum() / values.Count;
        }
    }
}
