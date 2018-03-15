using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public static class NumberAlgorithm
    {
        #region InsertNumber algorithm 

        /// <summary>
        /// This method insert bits to <paramref name="numberSource"/>
        /// from <paramref name="numberIn"/> from <paramref name="firstIndex"/>
        /// bit position to <paramref name="lastIndex"/> bit position
        /// </summary>
        /// <param name="numberSource">Number to insert</param>
        /// <param name="numberIn">Number from insert</param>
        /// <param name="firstIndex">The first bit position of insert sequence</param>
        /// <param name="lastIndex">The last bit position of insert sequence</param>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="firstIndex"/> greater than <paramref name="lastIndex"/>
        /// and <paramref name="firstIndex"/> less than 0
        /// </exception>
        /// <returns>Number with inserted bits</returns>
        public static int InsertNumber(int numberSource, int numberIn, int firstIndex, int lastIndex)
        {
            if(firstIndex > lastIndex)
            {
                throw new ArgumentException("First bit position must be less than last index", nameof(firstIndex));
            }

            if(firstIndex < 0)
            {
                throw new ArgumentException("Bits position must be greater than 0", nameof(firstIndex));
            }

            int mask = ((int)Math.Pow(2, lastIndex - firstIndex + 1) - 1) << firstIndex;

            numberIn <<= firstIndex;
            numberIn &= mask;
            numberSource &= ~mask;

            return (numberSource | numberIn);
        }

        #endregion

        #region FindNextBiggerNumber algorithm 

        /// <summary>
        /// This method find the next bigger number for <paramref name="number"/>
        /// consisting of its numbers
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="number"/> less than or equal to 0
        /// </exception>
        /// <param name="number">Number for find next bigger</param>
        /// <returns>Next bigger number for <paramref name="number"/></returns>
        public static int FindNextBiggerNumber(int number)
        {
            if(number <= 0)
            {
                throw new ArgumentException("Number must be greater than 0", nameof(number));
            }

            int[] numbers = number.ToString().Select(n => (int)char.GetNumericValue(n)).ToArray();

            for(int i = numbers.Length - 1; i > 0; i--)
            {
                if (numbers[i] > numbers[i - 1])
                {
                    int temp = numbers[i];
                    numbers[i] = numbers[i - 1];
                    numbers[i - 1] = temp;

                    for (int j = i; j < numbers.Length - 1; j++)
                    {
                        for (int k = j + 1; k < numbers.Length; k++)
                        {
                            if (numbers[j] >= numbers[k])
                            {
                                temp = numbers[j];
                                numbers[j] = numbers[k];
                                numbers[k] = temp;
                            }
                        }
                    }

                    string numbersStr = "";

                    for(int j = 0; j < numbers.Length; j++)
                    {
                        numbersStr += numbers[j].ToString();
                    }

                    return Int32.Parse(numbersStr);
                }
            }

            return -1;
        }

        public static string TimeMesurement(int number)
        {
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            FindNextBiggerNumber(number);
            stopWatch.Stop();

            long milliSec = stopWatch.ElapsedMilliseconds;


            string elapsedTime = String.Format("{0} number: {1} milliseconds", number, milliSec);
            return elapsedTime;
        }

        #endregion

        #region FilterDigit algorithm
        
        /// <summary>
        /// This method find all numbers from <paramref name="numberList"/> that
        /// contains <paramref name="seachNumber"/>
        /// </summary>
        /// <param name="numbersList">List of numbers</param>
        /// <param name="searchNumber">Number for search</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="numbersList"/> refer to null
        /// </exception>
        /// <returns>List of found numbers</returns>
        public static List<int> FilterDigit(List<int> numbersList, int searchNumber)
        {
            if(numbersList == null)
            {
                throw new ArgumentNullException("List of numbers must be not null", nameof(numbersList));
            }

            List<int> resultList = new List<int>();

            foreach(int number in numbersList)
            {
                if(number.ToString().Contains(searchNumber.ToString()))
                {
                    resultList.Add(number);
                }
            }

            return resultList;
        }

        #endregion

        #region FindNthRoot algorithm

        /// <summary>
        /// This method find nth root <paramref name="rootPower"/> of <paramref name="number"/> 
        /// with <paramref name="eps"/> precision
        /// </summary>
        /// <param name="number">Number for which find nth root</param>
        /// <param name="rootPower">Power of root</param>
        /// <param name="eps">Desired precision of result</param>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="rootPowr"/> or <paramref name="eps"/>
        /// less than or equal to 0
        /// </exception>
        /// <returns>Nth root of the number</returns>
        public static double FindNthRoot(double number, int rootPower, double eps)
        {
            if (rootPower <= 0)
            {
                throw new ArgumentException("Root power must be greater than 0", nameof(rootPower));
            }

            if (eps <= 0)
            {
                throw new ArgumentException("Accuracy must be greater than 0", nameof(eps));
            }

            var x0 = number / rootPower;
            var x1 = (1.0 / rootPower) * ((rootPower - 1) * x0 + number / Math.Pow(x0, rootPower - 1));

            while (Math.Abs(x1 - x0) > eps)
            {
                x0 = x1;
                x1 = (1.0 / rootPower) * ((rootPower - 1) * x0 + number / Math.Pow(x0, rootPower - 1));
            }

            return x1;
        }

        #endregion

    }
}
