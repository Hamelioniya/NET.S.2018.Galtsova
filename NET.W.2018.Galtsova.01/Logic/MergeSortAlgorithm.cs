using System.Linq;

namespace Logic
{
    /// <summary>
    /// Provides methods of merge sort.
    /// </summary>
    public class MergeSortAlgorithm
    {
        #region Public method of merge sort

        /// <summary>
        /// This method sorts data array by merge sort.
        /// </summary>
        /// <param name="arrayForSort">Data array for sort.</param>
        public static void Sort(int[] arrayForSort)
        {
            InputVerification.VerifyInputCorrect(arrayForSort);

            int[] buffer = ArrayDivisionAndSort(arrayForSort);

            for (int i = 0; i < arrayForSort.Length; i++)
            {
                arrayForSort[i] = buffer[i];
            }
        }

        #endregion

        #region Private methods of merge sort

        private static int[] ArrayDivisionAndSort(int[] arrayForSort)
        {
            if (arrayForSort.Length <= 1)
            {
                return arrayForSort;
            }

            int centerOfArray = arrayForSort.Length / 2;

            int[] firstArray = ArrayDivisionAndSort(arrayForSort.Skip(0).Take(centerOfArray).ToArray());
            int[] secondArray = ArrayDivisionAndSort(arrayForSort.Skip(centerOfArray).Take(arrayForSort.Length).ToArray());

            return SortingAlgorithm(firstArray, secondArray);
        }

        private static int[] SortingAlgorithm(int[] firstArray, int[] secondArray)
        {
            int leftIndex = 0, rightIndex = 0, index = -1;
            int size = firstArray.Length + secondArray.Length;
            int[] buffer = new int[size];

            while (leftIndex < firstArray.Length || rightIndex < secondArray.Length)
            {
                index++;

                if (leftIndex == firstArray.Length)
                {
                    buffer[index] = secondArray[rightIndex];
                    rightIndex++;
                    continue;
                }

                if (rightIndex == secondArray.Length)
                {
                    buffer[index] = firstArray[leftIndex];
                    leftIndex++;
                    continue;
                }

                if (firstArray[leftIndex] < secondArray[rightIndex])
                {
                    buffer[index] = firstArray[leftIndex];
                    leftIndex++;
                }
                else
                {
                    buffer[index] = secondArray[rightIndex];
                    rightIndex++;
                }
            }

            return buffer;
        }

        #endregion
    }
}
