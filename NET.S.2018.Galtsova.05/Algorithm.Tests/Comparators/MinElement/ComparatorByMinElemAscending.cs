using System;
using System.Collections.Generic;

namespace Algorithm.Tests
{
    /// <summary>
    /// Provides method of compare two rows of array by min row element in
    /// ascending order.
    /// </summary>
    public class ComparatorByMinElemAscending : IComparer<int[]>
    {
        /// <summary>
        /// This method provides comparator to compare <paramref name="firstRow"/>
        /// and <paramref name="secondRow"/> by minimum row element in ascending order.
        /// </summary>
        /// <param name="firstRow">A first row to compare.</param>
        /// <param name="secondRow">A second row to compare.</param>
        /// <returns>0 if minimum element of <paramref name="firstRow"/> less or equal 
        /// than <paramref name="secondRow"/>, otherwise 1.</returns>
        public int Compare(int[] firstRow, int[] secondRow)
        {
            int firstMinElement = int.MaxValue, secondMinElement = int.MaxValue;

            for (int i = 0; i < firstRow.Length; i++)
            {
                firstMinElement = Math.Min(firstMinElement, firstRow[i]);
            }

            for (int i = 0; i < secondRow.Length; i++)
            {
                secondMinElement = Math.Min(secondMinElement, secondRow[i]);
            }

            if (firstMinElement > secondMinElement)
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
