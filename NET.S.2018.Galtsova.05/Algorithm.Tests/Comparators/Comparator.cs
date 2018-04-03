using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    /// <summary>
    /// Provides methods to compare two arrays.
    /// </summary>
    public static class Comparator
    {
        #region Public methods of compare by minimum row element

        /// <summary>
        /// This method provides comparator to compare <paramref name="firstRow"/>
        /// and <paramref name="secondRow"/> by minimum row element in ascending order.
        /// </summary>
        /// <param name="firstRow">A first row to compare.</param>
        /// <param name="secondRow">A second row to compare.</param>
        /// <returns>0 if minimum element of <paramref name="firstRow"/> less or equal 
        /// than <paramref name="secondRow"/>, otherwise 1.</returns>
        public static int CompareByMinRowElementsAscending(int[] firstRow, int[] secondRow)
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

        /// <summary>
        /// This method provides comparator to compare <paramref name="firstRow"/>
        /// and <paramref name="secondRow"/> by minimum row element in descending order.
        /// </summary>
        /// <param name="firstRow">A first row to compare.</param>
        /// <param name="secondRow">A second row to compare.</param>
        /// <returns>0 if minimum element of <paramref name="secondRow"/> less or equal 
        /// than <paramref name="firstRow"/>, otherwise 1.</returns>
        public static int CompareByMinRowElementsDescending(int[] firstRow, int[] secondRow)
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

            if (firstMinElement < secondMinElement)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        #endregion !Public methods of compare by minimum row element

        #region Public methods of compare by maximum row element

        /// <summary>
        /// This method provides comparator to compare <paramref name="firstRow"/>
        /// and <paramref name="secondRow"/> by maximum row element in ascending order.
        /// </summary>
        /// <param name="firstRow">A first row to compare.</param>
        /// <param name="secondRow">A second row to compare.</param>
        /// <returns>0 if maximum element of <paramref name="firstRow"/> less or equal 
        /// than <paramref name="secondRow"/>, otherwise 1.</returns>
        public static int CompareByMaxRowElementsAscending(int[] firstRow, int[] secondRow)
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

        /// <summary>
        /// This method provides comparator to compare <paramref name="firstRow"/>
        /// and <paramref name="secondRow"/> by maximum row element in descending order.
        /// </summary>
        /// <param name="firstRow">A first row to compare.</param>
        /// <param name="secondRow">A second row to compare.</param>
        /// <returns>0 if maximum element of <paramref name="secondRow"/> less or equal 
        /// than <paramref name="firstRow"/>, otherwise 1.</returns>
        public static int CompareByMaxRowElementsDescending(int[] firstRow, int[] secondRow)
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

        #endregion !Public methods of compare by maximum row element

        #region Public methods of compare by maximum row elements sum

        /// <summary>
        /// This method provides comparator to compare <paramref name="firstRow"/>
        /// and <paramref name="secondRow"/> by maximum row elements sum in ascending order.
        /// </summary>
        /// <param name="firstRow">A first row to compare.</param>
        /// <param name="secondRow">A second row to compare.</param>
        /// <returns>0 if maximum elements sum of <paramref name="firstRow"/> less or equal 
        /// than <paramref name="secondRow"/>, otherwise 1.</returns>
        public static int CompareByRowElementsSumAscending(int[] firstRow, int[] secondRow)
        {
            int firstSum = 0, secondSum = 0;

            firstSum = firstRow.Sum();
            secondSum = secondRow.Sum();

            if (firstSum > secondSum)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// This method provides comparator to compare <paramref name="firstRow"/>
        /// and <paramref name="secondRow"/> by maximum row elements sum in descending order.
        /// </summary>
        /// <param name="firstRow">A first row to compare.</param>
        /// <param name="secondRow">A second row to compare.</param>
        /// <returns>0 if maximum elements sum of <paramref name="secondRow"/> less or equal 
        /// than <paramref name="firstRow"/>, otherwise 1.</returns>
        public static int CompareByRowElementsSumDescending(int[] firstRow, int[] secondRow)
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

        #endregion !Public methods of compare by maximum row element sum
    }
}
