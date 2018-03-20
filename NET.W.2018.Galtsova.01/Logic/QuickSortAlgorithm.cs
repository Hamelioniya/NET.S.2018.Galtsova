using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Provides methods of quick sort.
    /// </summary>
    public class QuickSortAlgorithm
    {
        #region Public method of quick sort

        /// <summary>
        /// This method sorts data array by merge sort.
        /// </summary>
        /// <param name="arrayForSort">Data array for sort.</param>
        public static void Sort(int[] arrayForSort)
        {
            InputVerification.VerifyInputCorrect(arrayForSort);

            SortingAlgorithm(arrayForSort, 0, arrayForSort.Length - 1);
        }

        #endregion

        #region Private method of quick sort
        private static void SortingAlgorithm(int[] arrayForSort, int firstIndex, int lastIndex)
        {
            if (firstIndex >= lastIndex)
            {
                return;
            }

            int pivotIndex = firstIndex + ((lastIndex - firstIndex) / 2);
            int pivot = arrayForSort[pivotIndex];

            int i = firstIndex, j = lastIndex;

            while (i < j)
            {
                while ((i < pivotIndex) && (arrayForSort[i] <= pivot))
                {
                    i++;
                }

                while ((j > pivotIndex) && (pivot <= arrayForSort[j]))
                {
                    j--;
                }

                if (i < j)
                {
                    int temp = arrayForSort[i];
                    arrayForSort[i] = arrayForSort[j];
                    arrayForSort[j] = temp;

                    if (i == pivotIndex)
                    {
                        pivotIndex = j;
                    }
                    else
                    {
                        if (j == pivotIndex)
                        {
                            pivotIndex = i;
                        }
                    }
                }
            }

            SortingAlgorithm(arrayForSort, firstIndex, pivotIndex);
            SortingAlgorithm(arrayForSort, pivotIndex + 1, lastIndex);
        }

        #endregion
    }
}
