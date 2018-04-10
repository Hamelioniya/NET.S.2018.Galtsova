using System;
using NUnit.Framework;

namespace Algorithm.Tests
{
    [TestFixture]
    public class FibonacciNumbersTests
    {
        [TestCase(2, ExpectedResult = new[] { 0, 1 })]
        [TestCase(6, ExpectedResult = new[] { 0, 1, 1, 2, 3, 5 })]
        public int[] GetFibonacciNumber_GetFibonacciNumbersWithEmptyConstructorTests(int count)
        { 
            FibonacciNumbers fibonacciNumbersGetter = new FibonacciNumbers();
            int[] result = new int[count];

            int i = 0;
            foreach (var fibonacciNumber in fibonacciNumbersGetter.GetFibonacciNumber(count))
            {
                result[i++] = fibonacciNumber;
            }

            return result;
        }

        [TestCase(2, 0, ExpectedResult = new[] { 0, 1 })]
        [TestCase(6, 0, ExpectedResult = new[] { 0, 1, 1, 2, 3, 5 })]
        [TestCase(2, 1, ExpectedResult = new[] { 1, 1 })]
        [TestCase(6, 1, ExpectedResult = new[] { 1, 1, 2, 3, 5, 8 })]
        public int[] GetFibonacciNumberTests(int count, int firstNumber)
        {
            FibonacciNumbers fibonacciNumbersGetter = new FibonacciNumbers(firstNumber);
            int[] result = new int[count];

            int i = 0;
            foreach (var fibonacciNumber in fibonacciNumbersGetter.GetFibonacciNumber(count))
            {
                result[i++] = fibonacciNumber;
            }

            return result;
        }

        [TestCase(0, 0)]
        [TestCase(1, 2)]
        public void GetFibonacciNumber_ArgumentOutOfRangeExceptionTests(int count, int firstNumber)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                FibonacciNumbers fibonacciNumbersGetter = new FibonacciNumbers(firstNumber);

                foreach (var fibonacciNumber in fibonacciNumbersGetter.GetFibonacciNumber(count))
                {
                }
            });
        }
    }
}
