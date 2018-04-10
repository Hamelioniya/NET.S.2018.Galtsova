using System;
using System.Collections.Generic;

namespace Algorithm
{
    /// <summary>
    /// Represents the binary search.
    /// </summary>
    /// <typeparam name="T">The search element and the array of elements type.</typeparam>
    public static class BinarySearch<T>
    {
        /// <summary>
        /// Looking for the <paramref name="element"/> in the <paramref name="arrayOfElements"/>.
        /// </summary>
        /// <param name="arrayOfElements">An array of elements in which the binary search is performed.</param>
        /// <param name="element">A search element.</param>
        /// <param name="comparator">A comparator which sets rules to compare.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="arrayOfElments"/> equal to null.
        /// </exception>
        /// <exception cref="ArithmeticException">
        /// Thrown when the <paramref name="arrayOfElements"/> is empty.
        /// </exception>
        /// <returns>Index of the <paramref name="element"/> in the <paramref name="arrayOfElements"/>, -1 if element not found.</returns>
        public static int Search(T[] arrayOfElements, T element, IComparer<T> comparator)
        {
            if (ReferenceEquals(arrayOfElements, null))
            {
                throw new ArgumentNullException(nameof(arrayOfElements));
            }

            if (arrayOfElements.Length == 0)
            {
                throw new ArgumentException("Array of elements must contains more than 0 elements.", nameof(arrayOfElements));
            }

            if ((comparator.Compare(element, arrayOfElements[0]) < 0) || (comparator.Compare(element, arrayOfElements[arrayOfElements.Length - 1]) > 0))
            {
                return -1;
            }

            int firstIndex = 0;
            int lastIndex = arrayOfElements.Length;

            while (firstIndex <= lastIndex)
            {
                int mid = (firstIndex + (lastIndex - firstIndex)) / 2;

                if (comparator.Compare(element, arrayOfElements[mid]) == 0)
                {
                    return mid;
                }

                if (comparator.Compare(element, arrayOfElements[mid]) < 0)
                {
                    firstIndex = mid + 1;
                }
                else
                {
                    lastIndex = mid - 1;
                }
            }

            return -1;
        }
    }
}
