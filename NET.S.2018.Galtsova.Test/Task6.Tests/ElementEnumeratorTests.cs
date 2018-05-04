using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Test6.Solution;

namespace Task6.Tests
{
    [TestFixture]
    public class ElementEnumeratorTests
    {
        [TestCase(2, 0, ExpectedResult = new[] { 0, 1 })]
        [TestCase(6, 0, ExpectedResult = new[] { 0, 1, 1, 2, 3, 5 })]
        [TestCase(2, 1, ExpectedResult = new[] { 1, 1 })]
        [TestCase(6, 1, ExpectedResult = new[] { 1, 1, 2, 3, 5, 8 })]
        public int[] ElementEnumerator_FibonacciTests(int count, int firstNumber)
        {
            ElementEnumerator<int> enumerator = new ElementEnumerator<int>(firstNumber, 1);

            int[] result = new int[count];

            int i = 0;
            foreach (var fibonacciNumber in enumerator.GetNumbers(count, FormulaFibonacci.CalculateElement))
            {
                result[i++] = fibonacciNumber;
            }

            return result;
        }

        [TestCase(2, 1, 2, ExpectedResult = new[] { 1, 2 })]
        [TestCase(4, 1, 2, ExpectedResult = new[] { 1, 2, 4, 8 })]
        public int[] ElementEnumerator_SecondFormulaTests(int count, int firstNumber, int secondNumber)
        {
            ElementEnumerator<int> enumerator = new ElementEnumerator<int>(firstNumber, secondNumber);

            int[] result = new int[count];

            int i = 0;
            foreach (var element in enumerator.GetNumbers(count, FormulaSecond.CalculateElement))
            {
                result[i++] = element;
            }

            return result;
        }

        [TestCase(2, 1, 2, ExpectedResult = new[] { 1d, 2d })]
        [TestCase(3, 1, 2, ExpectedResult = new[] { 1d, 2d, 2.5})]
        public double[] ElementEnumerator_ThirdFormulaTests(int count, int firstNumber, int secondNumber)
        {
            ElementEnumerator<double> enumerator = new ElementEnumerator<double>(firstNumber, secondNumber);

            double[] result = new double[count];

            int i = 0;
            foreach (var element in enumerator.GetNumbers(count, FormulaThird.CalculateElement))
            {
                result[i++] = element;
            }

            return result;
        }

    }
}
