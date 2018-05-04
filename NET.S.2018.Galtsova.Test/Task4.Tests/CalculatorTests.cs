using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Task4.Solution.FirstVariant;
using Task4.Solution.SecondVariant;

namespace Task4.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesFirstSuccess))]
        public double CalculateFirstVariant_SuccessTests(List<double> values, IAverageCalculator averageCalculator)
        {
            Solution.FirstVariant.Calculator calculator = new Solution.FirstVariant.Calculator();
            return calculator.CalculateAverage(values, averageCalculator);
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesFirstFail))]
        public void CalculateFirstVariant_FailTests(List<double> values, IAverageCalculator averageCalculator)
        {
            Solution.FirstVariant.Calculator calculator = new Solution.FirstVariant.Calculator();
            Assert.Throws<ArgumentNullException>(() => calculator.CalculateAverage(values, averageCalculator));
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesSecondSuccess))]
        public double CalculateSecondVariant_SuccessTests(List<double> values, AverageMethod averageMethod)
        {
            Solution.SecondVariant.Calculator calculator = new Solution.SecondVariant.Calculator();
            return calculator.Calculate(values, averageMethod);
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesSecondFail))]
        public void CalculateSecontVariant_FailTests(List<double> values, AverageMethod averageCalculator)
        {
            Solution.SecondVariant.Calculator calculator = new Solution.SecondVariant.Calculator();
            Assert.Throws<ArgumentNullException>(() => calculator.Calculate(values, averageCalculator));
        }

        private class TestCasesClass
        {
            public static IEnumerable TestCasesFirstSuccess
            {
                get
                {
                    yield return new TestCaseData(new List<double>() { 1, 2, 3 }, new AverageMeanMethodCalculator()).Returns(2);

                    yield return new TestCaseData(new List<double>() { 1, 2, 3 }, new AverageMedianMethodCalculator()).Returns(2);
                }
            }

            public static IEnumerable TestCasesFirstFail
            {
                get
                {
                    yield return new TestCaseData(null, new AverageMedianMethodCalculator());

                    yield return new TestCaseData(new List<double>() { 1, 2, 3 }, null);
                }
            }

            public static IEnumerable TestCasesSecondSuccess
            {
                get
                {
                    yield return new TestCaseData(new List<double>() { 1, 2, 3 }, new AverageMeanMethod()).Returns(2);

                    yield return new TestCaseData(new List<double>() { 1, 2, 3 }, new AverageMedianMethod()).Returns(2);
                }
            }

            public static IEnumerable TestCasesSecondFail
            {
                get
                {
                    yield return new TestCaseData(null, new AverageMeanMethod());

                    yield return new TestCaseData(new List<double>() { 1, 2, 3 }, null);
                }
            }
        }
    }
}
