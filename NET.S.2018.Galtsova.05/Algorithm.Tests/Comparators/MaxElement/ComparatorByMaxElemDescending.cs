using System;
using System.Collections.Generic;

namespace Algorithm.Tests
{
    /// <summary>
    /// Provides method of compare two rows of array by max row element in
    /// descending order.
    /// </summary>
    public class ComparatorByMaxElemDescending : IComparer<int[]>
    {
        /// <summary>
        /// This method provides comparator to compare <paramref name="firstRow"/>
        /// and <paramref name="secondRow"/> by maximum row element in descending order.
        /// </summary>
        /// <param name="firstRow">A first row to compare.</param>
        /// <param name="secondRow">A second row to compare.</param>
        /// <returns>0 if maximum element of <paramref name="secondRow"/> less or equal 
        /// than <paramref name="firstRow"/>, otherwise 1.</returns>
        public int Compare(int[] firstRow, int[] secondRow)
        {
            int firstMaxElement = 0, secondMaxElement = 0;

            for (int i = 0; i < firstRow.Length; i++)
            {
                firstMaxElement = Math.Max(firstMaxElement, firstRow[i]);
            }

            for (int i = 0; i < secondRow.Length; i++)
            {
                secondMaxElement = Math.Max(secondMaxElement, secondRow[i]);
            }

            if (firstMaxElement < secondMaxElement)
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
