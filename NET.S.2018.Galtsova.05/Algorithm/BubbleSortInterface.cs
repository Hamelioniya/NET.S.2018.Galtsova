using System;
using System.Collections.Generic;

namespace Algorithm
{
    /// <summary>
    /// Provides bubble sort methods for jagged array.
    /// </summary>
    public class BubbleSortInterface
    {
        /// <summary>
        /// This method sorts <paramref name="sourceArray"/> by bubble sort where
        /// elements compares by <paramref name="comparator"/>.
        /// </summary>
        /// <param name="sourceArray">A source array for sort.</param>
        /// <param name="comparator">A method of elements comparison.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="sourceArray"/> or/and <paramref name="comparator"/> equal to null.
        /// </exception>
        public static void Sort(int[][] sourceArray, IComparer<int[]> comparator)
        {
            if (ReferenceEquals(sourceArray, null))
            {
                throw new ArgumentNullException(nameof(sourceArray));
            }

            if (ReferenceEquals(comparator, null))
            {
                throw new ArgumentNullException(nameof(comparator));
            }

            int[][] array = new int[sourceArray.Length][];

            Array.Copy(sourceArray, array, sourceArray.Length);

            for (int i = 1; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i; j++)
                {
                    if (comparator.Compare(array[j], array[j + 1]) > 0)
                    {
                        var temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            Array.Copy(array, sourceArray, array.Length);
        }

        /// <summary>
        /// This method sorts <paramref name="sourceArray"/> by bubble sort where
        /// elements compares by <paramref name="comparator"/>.
        /// </summary>
        /// <param name="sourceArray">A source array for sort.</param>
        /// <param name="comparator">A method of elements comparison.</param>
        public static void Sort(int[][] sourceArray, Comparison<int[]> comparator) => Sort(sourceArray, new DelegateAdapter(comparator));
    }
}
