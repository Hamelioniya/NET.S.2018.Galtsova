using System;
using System.Diagnostics;

namespace Algorithm
{
    /// <summary>
    /// Provides methods to computing the GCD and to calculate time of work of this methods.
    /// </summary>
    public static class GCDAlgorithm
    {
        #region Private fields

        private delegate int _algorithmDelrgate(params int[] numbers);

        #endregion !Private fields.

        #region Public methods of Euclidean algorithm

        /// <summary>
        /// This is method for computing the GCD by the Euclidean algorithm.
        /// </summary>
        /// <param name="numbers">Array of numbers.</param>
        /// <returns>Calculated GCD.</returns>
        public static int GetEuclidGCD(params int[] numbers)
        {
            InputVerify(numbers);

            int result = Math.Abs(numbers[0]);
            for (int i = 1; i < numbers.Length; i++)
            {
                numbers[i] = Math.Abs(numbers[i]);

                while (result != 0 & numbers[i] != 0)
                {
                    if (result > numbers[i])
                    {
                        result %= numbers[i];
                    }
                    else
                    {
                        numbers[i] %= result;
                    }
                }

                result += numbers[i];
            }

            return result;
        }

        /// <summary>
        /// This method calculates the time of <see cref="Algorithm.GCDAlgorithm.GetEuclidGCD(int[])">GetEuclideanGCD</see> work.
        /// </summary>
        /// <param name="numbers">Array of numbers.</param>
        /// <returns>Calculated time of algorithm work.</returns>
        public static string GetTimeOfEuclideanGCDFind(params int[] numbers) => GetTimeOfAlgorithmWork(GetEuclidGCD, numbers);

        #endregion !Public methods of Euclidean algorithm.

        #region Public methods of Shtein algorithm

        /// <summary>
        /// This is method for computing the GCD by the Stein algorithm.
        /// </summary>
        /// <param name="numbers">Array of numbers.</param>
        /// <returns>Calculated GCD.</returns>
        public static int GetSteinGCD(params int[] numbers)
        {
            InputVerify(numbers);

            int result = Math.Abs(numbers[0]);

            for (int i = 1; i < numbers.Length; i++)
            {
                result = CalculateGCD(result, Math.Abs(numbers[i]));
            }

            return result;
        }

        /// <summary>
        /// This method calculates the time of <see cref="Algorithm.GCDAlgorithm.GetSteinGCD(int[])">GetSteinGCD</see> work.
        /// </summary>
        /// <param name="numbers">Array of numbers.</param>
        /// <returns>Calculated time of algorithm work.</returns>
        public static string GetTimeOfSteinGCDFind(params int[] numbers) => GetTimeOfAlgorithmWork(GetSteinGCD, numbers);

        #endregion !Public methods of Shtein algorithm.

        #region Private methods of Shtein algorithm

        /// <summary>
        /// This method computing the GCD by the Stein algorithm.
        /// </summary>
        /// <param name="number1">First number.</param>
        /// <param name="number2">Second number.</param>
        /// <returns>Calculated GCD.</returns>
        private static int CalculateGCD(int number1, int number2)
        {
            if (number1 == number2)
            {
                return number1;
            }

            if (number1 == 0)
            {
                number1 = number2;
            }

            if (number2 == 0)
            {
                return number1;
            }

            if ((~number1 & 1) != 0)
            {
                if ((number2 & 1) != 0)
                {
                    return GetSteinGCD(number1 >> 1, number2);
                }
                else
                {
                    return GetSteinGCD(number1 >> 1, number2 >> 1) << 1;
                }
            }

            if ((~number2 & 1) != 0)
            {
                return GetSteinGCD(number1, number2 >> 1);
            }

            if (number1 > number2)
            {
                return GetSteinGCD((number1 - number2) >> 1, number2);
            }

            return GetSteinGCD((number2 - number1) >> 1, number1);
        }

        #endregion !Private methods of Shtein algorithm.

        #region Private methods

        /// <summary>
        /// This method checks input data array.
        /// </summary>
        /// <param name="numbers">Input data array.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="numbers"/> equals null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when length of <paramref name="numbers"/> less than 2.
        /// </exception>
        private static void InputVerify(int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            if (numbers.Length <= 1)
            {
                throw new ArgumentException("Number of parameters must be more than 1", nameof(numbers));
            }
        }

        /// <summary>
        /// This method calculates the time of methods work.
        /// </summary>
        /// <param name="numbers">Array of numbers.</param>
        /// <param name="algorithm">Delegated method.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="algorithm"/> equal to null.
        /// </exception>
        /// <returns>Calculated time of algorithm work.</returns>
        private static string GetTimeOfAlgorithmWork(_algorithmDelrgate algorithm, params int[] numbers)
        {
            if (ReferenceEquals(algorithm, null))
            {
                throw new ArgumentNullException(nameof(algorithm));
            }

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();

            algorithm(numbers);

            stopWatch.Stop();

            long milliSec = stopWatch.ElapsedMilliseconds;

            string elapsedTime = string.Format("{0} numbers length: {1} milliseconds", numbers.Length, milliSec);

            return elapsedTime;
        }

        #endregion !Private methods.
    }
}