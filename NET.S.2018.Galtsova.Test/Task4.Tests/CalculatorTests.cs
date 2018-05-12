using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Task4.Solution;

namespace Task4.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesInterfaceSuccess))]
        public double CalculateInterface_SuccessTests(List<double> values, IAverageCalculator averageCalculator)
        {
            Solution.Interface.Calculator calculator = new Solution.Interface.Calculator();
            return calculator.CalculateAverage(values, averageCalculator);
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesInterfaceFail))]
        public void CalculateInterface_FailTests(List<double> values, IAverageCalculator averageCalculator)
        {
            Solution.Interface.Calculator calculator = new Solution.Interface.Calculator();
            Assert.Throws<ArgumentNullException>(() => calculator.CalculateAverage(values, averageCalculator));
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesDelegateSuccess))]
        public double CalculateDelegate_SuccessTests(List<double> values, IAverageCalculator averageCalculator)
        {
            Solution.Delegate.Calculator calculator = new Solution.Delegate.Calculator();
            return calculator.Calculate(values, averageCalculator.Calculate);
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesDelegateFail))]
        public void CalculateDelegate_FailTests(List<double> values, Func<List<double>, double> averageCalculator)
        {
            Solution.Delegate.Calculator calculator = new Solution.Delegate.Calculator();
            Assert.Throws<ArgumentNullException>(() => calculator.Calculate(values, averageCalculator));
        }

        private class TestCasesClass
        {
            public static IEnumerable TestCasesInterfaceSuccess
            {
                get
                {
                    yield return new TestCaseData(new List<double>() { 1, 2, 3 }, new AverageMeanMethodCalculator()).Returns(2);

                    yield return new TestCaseData(new List<double>() { 1, 2, 3 }, new AverageMedianMethodCalculator()).Returns(2);
                }
            }

            public static IEnumerable TestCasesInterfaceFail
            {
                get
                {
                    yield return new TestCaseData(null, new AverageMedianMethodCalculator());

                    yield return new TestCaseData(new List<double>() { 1, 2, 3 }, null);
                }
            }

            public static IEnumerable TestCasesDelegateSuccess
            {
                get
                {
                    yield return new TestCaseData(new List<double>() { 1, 2, 3 }, new AverageMeanMethodCalculator()).Returns(2);

                    yield return new TestCaseData(new List<double>() { 1, 2, 3 }, new AverageMedianMethodCalculator()).Returns(2);
                }
            }

            public static IEnumerable TestCasesDelegateFail
            {
                get
                {
                    yield return new TestCaseData(null, null);

                    yield return new TestCaseData(new List<double>() { 1, 2, 3 }, null);
                }
            }
        }
    }
}
