using System;
using System.Collections.Generic;

namespace Algorithm.Tests
{
    /// <summary>
    /// Provides method of compare two rows of array by max row element in
    /// ascending order.
    /// </summary>
    public class ComparatorByMaxElemAscending : IComparer<int[]>
    {
        /// <summary>
        /// This method provides comparator to compare <paramref name="firstRow"/>
        /// and <paramref name="secondRow"/> by maximum row element in ascending order.
        /// </summary>
        /// <param name="firstRow">A first row to compare.</param>
        /// <param name="secondRow">A second row to compare.</param>
        /// <returns>0 if maximum element of <paramref name="firstRow"/> less or equal 
        /// than <paramref name="secondRow"/>, otherwise 1.</returns>1
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

            if (firstMaxElement > secondMaxElement)
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
