using System;

namespace Algorithm
{
    /// <summary>
    /// Provides bubble sort methods for jagged array.
    /// </summary>
    public class BubbleSort
    {
        #region Public bubble sort methods

        /// <summary>
        /// This method sorts <paramref name="sourceArray"/> by bubble sort where
        /// elements compares by <paramref name="comparator"/>.
        /// </summary>
        /// <param name="sourceArray">A source array for sort.</param>
        /// <param name="comparator">A method of elements comparison.</param>
        public static void Sort(int[][] sourceArray, Comparison<int[]> comparator)
        {
            if (sourceArray == null)
            {
                throw new ArgumentNullException(nameof(sourceArray));
            }

            if (comparator == null)
            {
                throw new ArgumentNullException(nameof(comparator));
            }

            for (int i = 1; i < sourceArray.Length; i++)
            {
                for (int j = 0; j < sourceArray.Length - i; j++)
                {
                    if (comparator(sourceArray[j], sourceArray[j + 1]) > 0)
                    {
                        var temp = sourceArray[j];
                        sourceArray[j] = sourceArray[j + 1];
                        sourceArray[j + 1] = temp;
                    }
                }
            }
        }

        #endregion

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
                if (firstRow[i] < firstMinElement)
                {
                    firstMinElement = firstRow[i];
                }
            }

            for (int i = 0; i < secondRow.Length; i++)
            {
                if (secondRow[i] < secondMinElement)
                {
                    secondMinElement = secondRow[i];
                }
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
                if (firstRow[i] < firstMinElement)
                {
                    firstMinElement = firstRow[i];
                }
            }

            for (int i = 0; i < secondRow.Length; i++)
            {
                if (secondRow[i] < secondMinElement)
                {
                    secondMinElement = secondRow[i];
                }
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
                if (firstRow[i] > firstMaxElement)
                {
                    firstMaxElement = firstRow[i];
                }
            }

            for (int i = 0; i < secondRow.Length; i++)
            {
                if (secondRow[i] > secondMaxElement)
                {
                    secondMaxElement = secondRow[i];
                }
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
                if (firstRow[i] > firstMaxElement)
                {
                    firstMaxElement = firstRow[i];
                }
            }

            for (int i = 0; i < secondRow.Length; i++)
            {
                if (secondRow[i] > secondMaxElement)
                {
                    secondMaxElement = secondRow[i];
                }
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
            for (int i = 0; i < firstRow.Length; i++)
            {
                firstSum += firstRow[i];
            }

            for (int i = 0; i < secondRow.Length; i++)
            {
                secondSum += secondRow[i];
            }

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
            for (int i = 0; i < firstRow.Length; i++)
            {
                firstSum += firstRow[i];
            }

            for (int i = 0; i < secondRow.Length; i++)
            {
                secondSum += secondRow[i];
            }

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
