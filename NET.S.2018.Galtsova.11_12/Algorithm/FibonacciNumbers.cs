using System;
using System.Collections.Generic;

namespace Algorithm
{
    /// <summary>
    /// Provides methods to get fibonacci numbers.
    /// </summary>
    public class FibonacciNumbers
    {
        #region Private const fields

        private const int SecondNumber = 1;
        private readonly int FirstNumber;

        #endregion !Private const fields.

        #region Public constructors

        /// <summary>
        /// Initializes an instance of the <see cref="FibonacciNumbers"/>.
        /// </summary>
        public FibonacciNumbers() : this(0)
        {
        }

        /// <summary>
        /// Initializes an instance of the <see cref="FibonacciNumbers"/> with the passed first number of the sequence.
        /// </summary>
        /// <param name="firstNumber">A first number of the sequence.</param>
        public FibonacciNumbers(int firstNumber)
        {
            if ((firstNumber != 0) && (firstNumber != 1))
            {
                throw new ArgumentOutOfRangeException("First number of the sequence must be equal to 0 or 1.", nameof(firstNumber));
            }

            FirstNumber = firstNumber;
        }

        #endregion !Public constructors.

        #region Public methods

        /// <summary>
        /// Calculates <paramref name="count"/> numbers of the fibonacci sequence.
        /// </summary>
        /// <param name="count">A count of fibonacci numbers.</param>
        /// <returns>The current number of the sequence.</returns>
        public IEnumerable<int> GetFibonacciNumber(int count)
        {
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException("Count of fibonacci numbers must be greater than 0.", nameof(count));
            }

            int firstLastNumber = FirstNumber;
            int secondLastNumber = SecondNumber;

            for (int i = 0; i < count; i++)
            {
                yield return firstLastNumber;

                int temp = secondLastNumber;
                secondLastNumber = firstLastNumber + secondLastNumber;
                firstLastNumber = temp;
            }
        }

        #endregion !Public methods.
    }
}
