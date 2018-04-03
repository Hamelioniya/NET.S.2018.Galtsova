using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Tests
{
    /// <summary>
    /// Provides method of compare two rows of array by max sum of row elements in
    /// descending order.
    /// </summary>
    public class ComparatorByMaxSumDescending : IComparer<int[]>
    {
        /// <summary>
        /// This method provides comparator to compare <paramref name="firstRow"/>
        /// and <paramref name="secondRow"/> by maximum row elements sum in descending order.
        /// </summary>
        /// <param name="firstRow">A first row to compare.</param>
        /// <param name="secondRow">A second row to compare.</param>
        /// <returns>0 if maximum elements sum of <paramref name="secondRow"/> less or equal 
        /// than <paramref name="firstRow"/>, otherwise 1.</returns>
        public int Compare(int[] firstRow, int[] secondRow)
        {
            int firstSum = 0, secondSum = 0;

            firstSum = firstRow.Sum();
            secondSum = secondRow.Sum();

            if (firstSum < secondSum)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
