using System;
using System.Collections.Generic;

namespace Algorithm
{
    /// <summary>
    /// Represents a delegate adapter.
    /// </summary>
    public class DelegateAdapter : IComparer<int[]>
    {
        #region Private fields

        private Comparison<int[]> _comparator;

        #endregion !Private fields.

        #region Public constructors

        /// <summary>
        /// Initializes an instance of the <see cref="DelegateAdapter"/> with the passed comparator.
        /// </summary>
        /// <param name="comparator">A comparator.</param>
        public DelegateAdapter(Comparison<int[]> comparator)
        {
            Comparator = comparator;
        }

        #endregion !Public constructors.

        #region Private properties

        /// <summary>
        /// Comparator.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown when value equal to null.
        /// </exception>
        private Comparison<int[]> Comparator
        {
            get
            {
                return _comparator;
            }

            set
            {
                if (ReferenceEquals(value, null))
                {
                    throw new ArgumentNullException(nameof(Comparator));
                }

                _comparator = value;
            }
        }

        #endregion !Private properties.

        #region Public methods

        /// <summary>
        /// This method compares two rows of array.
        /// </summary>
        /// <param name="firstArrat">A first row.</param>
        /// <param name="secondArray">A second row.</param>
        /// <returns>Greater than 0, if the first row is larger, 0 if equal, -1 if less.</returns>
        public int Compare(int[] firstArray, int[] secondArray) => _comparator(firstArray, secondArray);

        #endregion !Public methods.
    }
}
