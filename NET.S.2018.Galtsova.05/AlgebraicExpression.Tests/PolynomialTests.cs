using System;
using NUnit.Framework;

namespace AlgebraicExpression.Tests
{
    [TestFixture]
    public class PolynomialTests
    {
        #region Operator + tests

        [TestCase(new[] { 0d, 1d, 2d, 3d }, new[] { 1d, 1d }, new[] { 1d, 2d, 2d, 3d })]
        [TestCase(new[] { 0d, 1d, -2d, 3d }, new[] { 10d, 1.223d, 5d, 8d, 0d }, new[] { 10d, 2.223d, 3d, 11d, 0d })]
        public void PolynomialOperatorAdd_AddPolynomialToPolynomialTests(double[] coefficientsPolynomial1, double[] coefficientsPolynomial2, double[] coefficientsResultPolynomial)
        {
            Polynomial polynomial1 = new Polynomial(coefficientsPolynomial1);
            Polynomial polynomial2 = new Polynomial(coefficientsPolynomial2);
            Polynomial result = new Polynomial(coefficientsResultPolynomial);

            Assert.IsTrue(result == polynomial1 + polynomial2);
        }

        [TestCase(new[] { 0d, 1d, 2d, 3d }, new[] { 0d, 1d, 2d, 3d })]
        public void PolynomialOperatorAdd_AddPolynomialToNullTests(double[] coefficientsPolynomial1, double[] coefficientsResultPolynomial)
        {
            Polynomial polynomial1 = new Polynomial(coefficientsPolynomial1);
            Polynomial polynomial2 = null;

            Assert.Throws<ArgumentNullException>(() => { Polynomial result = polynomial1 + polynomial2; });
        }

        [TestCase(new[] { 0d, 1d, 2d, 3d }, new[] { 0d, 1d, 2d, 3d })]
        public void PolynomialOperatorAdd_AddNullToPolynomialTests(double[] coefficientsPolynomial2, double[] coefficientsResultPolynomial)
        {
            Polynomial polynomial1 = null;
            Polynomial polynomial2 = new Polynomial(coefficientsPolynomial2);

            Assert.Throws<ArgumentNullException>(() => { Polynomial result = polynomial1 + polynomial2; });
        }

        [TestCase(new[] { 0d })]
        public void PolynomialOperatorAdd_AddNullToNullTests(double[] coefficientsResultPolynomial)
        {
            Polynomial polynomial1 = null;
            Polynomial polynomial2 = null;

            Assert.Throws<ArgumentNullException>(() => { Polynomial result = polynomial1 + polynomial2; });
        }

        #endregion !operator + tests

        #region Operator - tests

        [TestCase(new[] { 0d, 1d, 2d, 3d }, new[] { 1d, 1d }, new[] { -1d, 0d, 2d, 3d })]
        [TestCase(new[] { 0d, 1d, -2d, -3d }, new[] { 10d, 1.223d, 5d, -8d, 0d }, new[] { -10d, -0.223d, -7d, 5d, 0d })]
        public void PolynomialOperatorSubtract_SubtractPolynomialFromPolynomialTests(double[] coefficientsPolynomial1, double[] coefficientsPolynomial2, double[] coefficientsResultPolynomial)
        {
            Polynomial polynomial1 = new Polynomial(coefficientsPolynomial1);
            Polynomial polynomial2 = new Polynomial(coefficientsPolynomial2);
            Polynomial result = new Polynomial(coefficientsResultPolynomial);

            Assert.IsTrue(result == polynomial1 - polynomial2);
        }

        [TestCase(new[] { 0d, 1d, 2d, 3d }, new[] { 0d, 1d, 2d, 3d })]
        public void PolynomialOperatorSubtract_SubtractPolynomialFromNullTests(double[] coefficientsPolynomial1, double[] coefficientsResultPolynomial)
        {
            Polynomial polynomial1 = new Polynomial(coefficientsPolynomial1);
            Polynomial polynomial2 = null;

            Assert.Throws<ArgumentNullException>(() => { Polynomial result = polynomial1 - polynomial2; });
        }

        [TestCase(new[] { 0d, 1d, 2d, 3d }, new[] { 0d, 1d, 2d, 3d })]
        public void PolynomialOperatorSubtract_SubtractNullToPolynomialTests(double[] coefficientsPolynomial2, double[] coefficientsResultPolynomial)
        {
            Polynomial polynomial1 = null;
            Polynomial polynomial2 = new Polynomial(coefficientsPolynomial2);

            Assert.Throws<ArgumentNullException>(() => { Polynomial result = polynomial1 - polynomial2; });
        }

        [TestCase(new[] { 0d })]
        public void PolynomialOperatorSubtract_SubtractNullToNullTests(double[] coefficientsResultPolynomial)
        {
            Polynomial polynomial1 = null;
            Polynomial polynomial2 = null;

            Assert.Throws<ArgumentNullException>(() => { Polynomial result = polynomial1 - polynomial2; });
        }

        #endregion !operator - tests

        #region Operator * tests

        [TestCase(new[] { 0d, 1d, 2d, 3d }, new[] { 1d, 1d }, new[] { 0d, 1d, 3d, 5d, 3d })]
        [TestCase(new[] { 0d, 1d, -2d, -3d }, new[] { 10d, 1.223d, 5d, -8d, 0d }, new[] { 0d, 10d, -18.777d, -27.446d, -21.669d, 1d, 24d, -0d })]
        public void PolynomialOperatorMultiply_MultiplyPolynomialToPolynomialTests(double[] coefficientsPolynomial1, double[] coefficientsPolynomial2, double[] coefficientsResultPolynomial)
        {
            Polynomial polynomial1 = new Polynomial(coefficientsPolynomial1);
            Polynomial polynomial2 = new Polynomial(coefficientsPolynomial2);
            Polynomial result = new Polynomial(coefficientsResultPolynomial);

            Assert.IsTrue(result == polynomial1 * polynomial2);
        }

        [TestCase(new[] { 0d, 1d, 2d, 3d }, new[] { 0d })]
        public void PolynomialOperarorMultiply_MultiplyPolynomialFromNullTests(double[] coefficientsPolynomial1, double[] coefficientsResultPolynomial)
        {
            Polynomial polynomial1 = new Polynomial(coefficientsPolynomial1);
            Polynomial polynomial2 = null;

            Assert.Throws<ArgumentNullException>(() => { Polynomial result = polynomial1 * polynomial2; });
        }

        [TestCase(new[] { 0d, 1d, 2d, 3d }, new[] { 0d })]
        public void PolynomialOperatorMultiply_MultiplyNullToPolynomialTests(double[] coefficientsPolynomial2, double[] coefficientsResultPolynomial)
        {
            Polynomial polynomial1 = null;
            Polynomial polynomial2 = new Polynomial(coefficientsPolynomial2);

            Assert.Throws<ArgumentNullException>(() => { Polynomial result = polynomial1 * polynomial2; });
        }

        [TestCase(new[] { 0d })]
        public void PolinomiaOperatorlMultiply_MultiplyNullToNullTests(double[] coefficientsResultPolynomial)
        {
            Polynomial polynomial1 = null;
            Polynomial polynomial2 = null;

            Assert.Throws<ArgumentNullException>(() => { Polynomial result = polynomial1 * polynomial2; });
        }

        #endregion !operator * tests

        #region Operator == tests

        [TestCase(new[] { 0d, 1d, 2d, 3d }, new[] { 1d, 1d }, ExpectedResult = false)]
        [TestCase(new[] { 0d, 1d, 2d, 3d }, new[] { 1d, 1d, 1d, 1d }, ExpectedResult = false)]
        public bool PolynomialOperatorEqual_EqualPolynomialToPolynomial_ReturnFalseTests(double[] coefficientsPolynomial1, double[] coefficientsPolynomial2)
        {
            Polynomial polynomial1 = new Polynomial(coefficientsPolynomial1);
            Polynomial polynomial2 = new Polynomial(coefficientsPolynomial2);

            return polynomial1 == polynomial2;
        }

        [TestCase(new[] { 0d, 1d, 2d, 3d }, new[] { 0d, 1d, 2d, 3d }, ExpectedResult = true)]
        public bool PolynomialOperatorEqual_EqualPolynomialToPolynomial_ReturnTrueTests(double[] coefficientsPolynomial1, double[] coefficientsPolynomial2)
        {
            Polynomial polynomial1 = new Polynomial(coefficientsPolynomial1);
            Polynomial polynomial2 = new Polynomial(coefficientsPolynomial2);

            return polynomial1 == polynomial2;
        }

        [TestCase(new[] { 0d, 1d, 2d, 3d }, ExpectedResult = false)]
        public bool PolynomialOperatorEqual_EqualPolynomialFromNullTests(double[] coefficientsPolynomial1)
        {
            Polynomial polynomial1 = new Polynomial(coefficientsPolynomial1);
            Polynomial polynomial2 = null;

            return polynomial1 == polynomial2;
        }

        [TestCase(new[] { 0d, 1d, 2d, 3d }, ExpectedResult = false)]
        public bool PolynomialOperatorEqual_EqualNullToPolynomialTests(double[] coefficientsPolynomial2)
        {
            Polynomial polynomial1 = null;
            Polynomial polynomial2 = new Polynomial(coefficientsPolynomial2);

            return polynomial1 == polynomial2;
        }

        [TestCase(ExpectedResult = true)]
        public bool PolynomialOperatorEqual_EqualNullToNullTests()
        {
            Polynomial polynomial1 = null;
            Polynomial polynomial2 = null;

            return polynomial1 == polynomial2;
        }

        #endregion !operator == tests

        #region Operator != tests

        [TestCase(new[] { 0d, 1d, 2d, 3d }, new[] { 1d, 1d }, ExpectedResult = true)]
        [TestCase(new[] { 0d, 1d, 2d, 3d }, new[] { 1d, 1d, 1d, 1d }, ExpectedResult = true)]
        public bool PolynomialOperatorNotEqual_NotEqualPolynomialToPolynomial_ReturnTrueTests(double[] coefficientsPolynomial1, double[] coefficientsPolynomial2)
        {
            Polynomial polynomial1 = new Polynomial(coefficientsPolynomial1);
            Polynomial polynomial2 = new Polynomial(coefficientsPolynomial2);

            return polynomial1 != polynomial2;
        }

        [TestCase(new[] { 0d, 1d, 2d, 3d }, new[] { 0d, 1d, 2d, 3d }, ExpectedResult = false)]
        public bool PolynomialOperatorNotEqual_NotEqualPolynomialToPolynomial_ReturnFalseTests(double[] coefficientsPolynomial1, double[] coefficientsPolynomial2)
        {
            Polynomial polynomial1 = new Polynomial(coefficientsPolynomial1);
            Polynomial polynomial2 = new Polynomial(coefficientsPolynomial2);

            return polynomial1 != polynomial2;
        }

        [TestCase(new[] { 0d, 1d, 2d, 3d }, ExpectedResult = true)]
        public bool PolynomialOperatorNotEqual_NotEqualPolynomialFromNullTests(double[] coefficientsPolynomial1)
        {
            Polynomial polynomial1 = new Polynomial(coefficientsPolynomial1);
            Polynomial polynomial2 = null;

            return polynomial1 != polynomial2;
        }

        [TestCase(new[] { 0d, 1d, 2d, 3d }, ExpectedResult = true)]
        public bool PolynomialOperatorNotEqual_NotEqualNullToPolynomialTests(double[] coefficientsPolynomial2)
        {
            Polynomial polynomial1 = null;
            Polynomial polynomial2 = new Polynomial(coefficientsPolynomial2);

            return polynomial1 != polynomial2;
        }

        [TestCase(ExpectedResult = false)]
        public bool PolynomialOperatorNotEqual_NotEqualNullToNullTests()
        {
            Polynomial polynomial1 = null;
            Polynomial polynomial2 = null;

            return polynomial1 != polynomial2;
        }

        #endregion !operator != tests

        #region Constructor tests

        [TestCase(new double[0])]
        public void PolynomialConstructor_ArgumentExceptionTests(double[] coefficients)
        {
            Assert.Throws<ArgumentException>(() => new Polynomial(coefficients));
        }

        [TestCase(null)]
        public void PolynomialConstructor_ArgumentNullExceptionTests(double[] coefficients)
        {
            Assert.Throws<ArgumentNullException>(() => new Polynomial(null));
        }

        #endregion

        #region ToString tests

        [TestCase(new[] { 0d, 1d, 2d, 3d }, ExpectedResult = "0 + 1 * x^1 + 2 * x^2 + 3 * x^3")]
        [TestCase(new[] { 0d, 0d, 0d, 0d }, ExpectedResult = "0 + 0 * x^1 + 0 * x^2 + 0 * x^3")]
        [TestCase(new[] { 1.23d, 0d, -2d, 3d }, ExpectedResult = "1,23 + 0 * x^1 - 2 * x^2 + 3 * x^3")]
        public string PolynomialToString_ConvertPolynomialToStringTests(double[] coefficients)
        {
            Polynomial polynomial = new Polynomial(coefficients);

            return polynomial.ToString();
        }

        #endregion !ToString tests
    }
}
