using System;

namespace Algorithm
{
    /// <summary>
    /// Provides bubble sort methods for jagged array.
    /// </summary>
    public class BubbleSort
    {
        #region Public methods of bubble sort by maximum row element

        /// <summary>
        /// This method sorts <paramref name="sourceArray"/> by bubble sort where
        /// elements compares by maximum row element in ascending order.
        /// </summary>
        /// <param name="sourceArray">A source array for sort.</param>
        public static void SortByMaxElementAscending(int[][] sourceArray)
        {
            if (sourceArray == null)
            {
                throw new ArgumentNullException(nameof(sourceArray));
            }

            int[][] array = new int[sourceArray.Length][];

            Array.Copy(sourceArray, array, sourceArray.Length);

            for (int i = 1; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i; j++)
                {
                    if (Comparator.CompareByMaxRowElementsAscending(array[j], array[j + 1]) > 0)
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
        /// elements compares by maximum row element in descending order.
        /// </summary>
        /// <param name="sourceArray">A source array for sort.</param>
        public static void SortByMaxElementDescending(int[][] sourceArray)
        {
            if (sourceArray == null)
            {
                throw new ArgumentNullException(nameof(sourceArray));
            }

            int[][] array = new int[sourceArray.Length][];

            Array.Copy(sourceArray, array, sourceArray.Length);

            for (int i = 1; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i; j++)
                {
                    if (Comparator.CompareByMaxRowElementsDescending(array[j], array[j + 1]) > 0)
                    {
                        var temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            Array.Copy(array, sourceArray, array.Length);
        }

        #endregion !Public methods of bubble sort by maximum row element

        #region Public methods of bubble sort by minimum row element

        /// <summary>
        /// This method sorts <paramref name="sourceArray"/> by bubble sort where
        /// elements compares by minimum row element in ascending order.
        /// </summary>
        /// <param name="sourceArray">A source array for sort.</param>
        public static void SortByMinElementAscending(int[][] sourceArray)
        {
            if (sourceArray == null)
            {
                throw new ArgumentNullException(nameof(sourceArray));
            }

            int[][] array = new int[sourceArray.Length][];

            Array.Copy(sourceArray, array, sourceArray.Length);

            for (int i = 1; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i; j++)
                {
                    if (Comparator.CompareByMinRowElementsAscending(array[j], array[j + 1]) > 0)
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
        /// elements compares by minimum row element in descending order.
        /// </summary>
        /// <param name="sourceArray">A source array for sort.</param>
        public static void SortByMinElementDescending(int[][] sourceArray)
        {
            if (sourceArray == null)
            {
                throw new ArgumentNullException(nameof(sourceArray));
            }

            int[][] array = new int[sourceArray.Length][];

            Array.Copy(sourceArray, array, sourceArray.Length);

            for (int i = 1; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i; j++)
                {
                    if (Comparator.CompareByMinRowElementsDescending(array[j], array[j + 1]) > 0)
                    {
                        var temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            Array.Copy(array, sourceArray, array.Length);
        }

        #endregion !Public methods of bubble sort by minimum row element

        #region Public methods of bubble sort by maximum row elements sum

        /// <summary>
        /// This method sorts <paramref name="sourceArray"/> by bubble sort where
        /// elements compares by maximum row elements sum in ascending order.
        /// </summary>
        /// <param name="sourceArray">A source array for sort.</param>
        public static void SortByMaxRowElementsSumAscending(int[][] sourceArray)
        {
            if (sourceArray == null)
            {
                throw new ArgumentNullException(nameof(sourceArray));
            }

            int[][] array = new int[sourceArray.Length][];

            Array.Copy(sourceArray, array, sourceArray.Length);

            for (int i = 1; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i; j++)
                {
                    if (Comparator.CompareByRowElementsSumAscending(array[j], array[j + 1]) > 0)
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
        /// elements compares by maximum row elements sum in descending order.
        /// </summary>
        /// <param name="sourceArray">A source array for sort.</param>
        public static void SortByMaxRowElementsSumDescending(int[][] sourceArray)
        {
            if (sourceArray == null)
            {
                throw new ArgumentNullException(nameof(sourceArray));
            }

            int[][] array = new int[sourceArray.Length][];

            Array.Copy(sourceArray, array, sourceArray.Length);

            for (int i = 1; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i; j++)
                {
                    if (Comparator.CompareByRowElementsSumDescending(array[j], array[j + 1]) > 0)
                    {
                        var temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            Array.Copy(array, sourceArray, array.Length);
        }

        #endregion !Public methods of bubble sort by maximum row elements sum
    }
}
