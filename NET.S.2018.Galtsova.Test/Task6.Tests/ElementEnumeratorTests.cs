using NUnit.Framework;
using Test6.Solution;

namespace Task6.Tests
{
    [TestFixture]
    public class ElementEnumeratorTests
    {
        [TestCase(2, 0, 1, ExpectedResult = new[] { 0, 1 })]
        [TestCase(6, 0, 1, ExpectedResult = new[] { 0, 1, 1, 2, 3, 5 })]
        [TestCase(2, 1, 1, ExpectedResult = new[] { 1, 1 })]
        [TestCase(6, 1, 1, ExpectedResult = new[] { 1, 1, 2, 3, 5, 8 })]
        public int[] ElementEnumerator_FibonacciTests(int count, int firstElement, int secondElement)
        {
            int[] result = new int[count];

            int i = 0;
            foreach (var fibonacciNumber in ElementEnumerator<int>.GetNumbers(firstElement, secondElement, count, FormulaFibonacci.CalculateElement))
            {
                result[i++] = fibonacciNumber;
            }

            return result;
        }

        [TestCase(2, 1, 2, ExpectedResult = new[] { 1, 2 })]
        [TestCase(4, 1, 2, ExpectedResult = new[] { 1, 2, 4, 8 })]
        public int[] ElementEnumerator_SecondFormulaTests(int count, int firstElement, int secondElement)
        {
            int[] result = new int[count];

            int i = 0;
            foreach (var element in ElementEnumerator<int>.GetNumbers(firstElement, secondElement, count, FormulaSecond.CalculateElement))
            {
                result[i++] = element;
            }

            return result;
        }

        [TestCase(2, 1, 2, ExpectedResult = new[] { 1d, 2d })]
        [TestCase(3, 1, 2, ExpectedResult = new[] { 1d, 2d, 2.5})]
        public double[] ElementEnumerator_ThirdFormulaTests(int count, int firstElement, int secondElement)
        {
            double[] result = new double[count];

            int i = 0;
            foreach (var element in ElementEnumerator<double>.GetNumbers(firstElement, secondElement, count, FormulaThird.CalculateElement))
            {
                result[i++] = element;
            }

            return result;
        }

    }
}
