using System;

namespace AlgebraicExpression
{
    /// <summary>
    /// Provides methods to work with polynomials.
    /// </summary>
    public sealed class Polynomial
    {
        private const double DefaultAccuracy = 0.001D;

        #region Private fields

        private double[] _coefficients;

        #endregion

        #region Public constructors

        public Polynomial(double[] coefficients)
        {
            if (ReferenceEquals(coefficients, null))
            {
                throw new ArgumentNullException(nameof(coefficients));
            }

            if (coefficients.Length < 1)
            {
                throw new ArgumentException("Number of coefficients must be greater than 0.", nameof(coefficients));
            }

            _coefficients = coefficients;
            MaxExponent = _coefficients.Length - 1;
        }

        #endregion

        #region Public properties

        public int MaxExponent { get; private set; }

        #endregion

        #region Operator +

        /// <summary>
        /// This method adds corresponding coefficients of <paramref name="polynomial1"/>
        /// and <paramref name="polynomial2"/>.
        /// </summary>
        /// <param name="polynomial1">A first polynomial.</param>
        /// <param name="polynomial2">A second polynomial.</param>
        /// <returns>Result of addition corresponding coefficients of <paramref name="polynomial1"/>
        /// and <paramref name="polynomial2"/>.</returns>
        public static Polynomial operator +(Polynomial polynomial1, Polynomial polynomial2)
        {
            if (ReferenceEquals(polynomial1, null))
            {
                throw new ArgumentNullException(nameof(polynomial1));
            }

            if (ReferenceEquals(polynomial2, null))
            {
                throw new ArgumentNullException(nameof(polynomial2));
            }

            double[] resultCoefficients = null;
            double[] coeffPolynomial1 = new double[polynomial1.MaxExponent + 1];
            double[] coeffPolynomial2 = new double[polynomial2.MaxExponent + 1];
            int minMaxExponent = 0;

            Array.Copy(polynomial1._coefficients, coeffPolynomial1, polynomial1.MaxExponent + 1);
            Array.Copy(polynomial2._coefficients, coeffPolynomial2, polynomial2.MaxExponent + 1);

            if (coeffPolynomial1.Length > coeffPolynomial2.Length)
            {
                resultCoefficients = new double[coeffPolynomial1.Length];
                Array.Copy(coeffPolynomial1, resultCoefficients, coeffPolynomial1.Length);
                minMaxExponent = coeffPolynomial2.Length;
            }
            else
            {
                resultCoefficients = new double[coeffPolynomial2.Length];
                Array.Copy(coeffPolynomial2, resultCoefficients, coeffPolynomial2.Length);
                minMaxExponent = coeffPolynomial1.Length;
            }

            for (int i = 0; i < minMaxExponent; i++)
            {
                resultCoefficients[i] = coeffPolynomial1[i] + coeffPolynomial2[i];
            }

            return new Polynomial(resultCoefficients);
        }

        #endregion !Operator +

        #region Operator -

        /// <summary>
        /// This method subtracts corresponding coefficients of <paramref name="polynomial1"/>
        /// and <paramref name="polynomial2"/>.
        /// </summary>
        /// <param name="polynomial1">A first polynomial.</param>
        /// <param name="polynomial2">A second polynomial.</param>
        /// <returns>Result of subtraction corresponding coefficients of <paramref name="polynomial1"/>
        /// and <paramref name="polynomial2"/>.</returns>
        public static Polynomial operator -(Polynomial polynomial1, Polynomial polynomial2)
        {
            if (ReferenceEquals(polynomial1, null))
            {
                throw new ArgumentNullException(nameof(polynomial1));
            }

            if (ReferenceEquals(polynomial2, null))
            {
                throw new ArgumentNullException(nameof(polynomial2));
            }

            double[] resultCoefficients = null;
            double[] coeffPolynomial1 = new double[polynomial1.MaxExponent + 1];
            double[] coeffPolynomial2 = new double[polynomial2.MaxExponent + 1];
            int minMaxExponent = 0;

            Array.Copy(polynomial1._coefficients, coeffPolynomial1, polynomial1.MaxExponent + 1);
            Array.Copy(polynomial2._coefficients, coeffPolynomial2, polynomial2.MaxExponent + 1);

            if (coeffPolynomial1.Length > coeffPolynomial2.Length)
            {
                resultCoefficients = new double[coeffPolynomial1.Length];
                Array.Copy(coeffPolynomial1, resultCoefficients, coeffPolynomial1.Length);
                minMaxExponent = coeffPolynomial2.Length;
            }
            else
            {
                resultCoefficients = new double[coeffPolynomial2.Length];
                Array.Copy(coeffPolynomial2, resultCoefficients, coeffPolynomial2.Length);
                minMaxExponent = coeffPolynomial1.Length;
            }

            for (int i = 0; i < minMaxExponent; i++)
            {
                resultCoefficients[i] = coeffPolynomial1[i] - coeffPolynomial2[i];
            }

            return new Polynomial(resultCoefficients);
        }

        #endregion !Operator -

        #region Operator *
        /// <summary>
        /// This method multiplies corresponding coefficients of <paramref name="polynomial1"/>
        /// to <paramref name="polynomial2"/>.
        /// </summary>
        /// <param name="polynomial1">A first polynomial.</param>
        /// <param name="polynomial2">A second polynomial.</param>
        /// <returns>The result of multiplying corresponding coefficients of <paramref name="polynomial1"/>
        /// to <paramref name="polynomial2"/>.</returns>
        public static Polynomial operator *(Polynomial polynomial1, Polynomial polynomial2)
        {
            if (ReferenceEquals(polynomial1, null))
            {
                throw new ArgumentNullException(nameof(polynomial1));
            }

            if (ReferenceEquals(polynomial2, null))
            {
                throw new ArgumentNullException(nameof(polynomial2));
            }

            double[] coeffPolynomial1 = new double[polynomial1.MaxExponent + 1];
            double[] coeffPolynomial2 = new double[polynomial2.MaxExponent + 1];

            Array.Copy(polynomial1._coefficients, coeffPolynomial1, polynomial1.MaxExponent + 1);
            Array.Copy(polynomial2._coefficients, coeffPolynomial2, polynomial2.MaxExponent + 1);

            double[] resultCoefficients = new double[coeffPolynomial1.Length + coeffPolynomial2.Length - 1];

            for (int i = 0; i < coeffPolynomial1.Length; i++)
            {
                for (int j = 0; j < coeffPolynomial2.Length; j++)
                {
                    resultCoefficients[i + j] += coeffPolynomial1[i] * coeffPolynomial2[j];
                }
            }

            return new Polynomial(resultCoefficients);
        }

        #endregion !Operator *

        #region Operator ==

        /// <summary>
        /// This method checks equality of <paramref name="polynomial1"/> and <paramref name="polynomial2"/>.
        /// </summary>
        /// <param name="polynomial1">A first polynomial.</param>
        /// <param name="polynomial2">A second polynomial.</param>
        /// <returns>true if polynomials are equal.</returns>
        public static bool operator ==(Polynomial polynomial1, Polynomial polynomial2)
        {
            if (ReferenceEquals(polynomial1, null) && ReferenceEquals(polynomial2, null))
            {
                return true;
            }

            if (ReferenceEquals(polynomial1, null) || ReferenceEquals(polynomial2, null))
            {
                return false;
            }

            if (polynomial1.MaxExponent != polynomial2.MaxExponent)
            {
                return false;
            }

            double[] coeffPolynomial1 = new double[polynomial1.MaxExponent + 1];
            double[] coeffPolynomial2 = new double[polynomial2.MaxExponent + 1];

            Array.Copy(polynomial1._coefficients, coeffPolynomial1, polynomial1.MaxExponent + 1);
            Array.Copy(polynomial2._coefficients, coeffPolynomial2, polynomial2.MaxExponent + 1);

            for (int i = 0; i < coeffPolynomial1.Length; i++)
            {
                if (Math.Abs(coeffPolynomial1[i] - coeffPolynomial2[i]) > DefaultAccuracy)
                {
                    return false;
                }
            }

            return true;
        }

        #endregion !Operator ==

        #region Operator !=

        /// <summary>
        /// This method checks inequality of <paramref name="polynomial1"/> and <paramref name="polynomial2"/>.
        /// </summary>
        /// <param name="polynomial1"></param>
        /// <param name="polynomial2"></param>
        /// <returns>true if polynomial not equal.</returns>
        public static bool operator !=(Polynomial polynomial1, Polynomial polynomial2)
        {
            if (ReferenceEquals(polynomial1, null) && ReferenceEquals(polynomial2, null))
            {
                return false;
            }

            if (ReferenceEquals(polynomial1, null) || ReferenceEquals(polynomial2, null))
            {
                return true;
            }

            if (polynomial1.MaxExponent != polynomial2.MaxExponent)
            {
                return true;
            }

            double[] coeffPolynomial1 = new double[polynomial1.MaxExponent + 1];
            double[] coeffPolynomial2 = new double[polynomial2.MaxExponent + 1];

            Array.Copy(polynomial1._coefficients, coeffPolynomial1, polynomial1.MaxExponent + 1);
            Array.Copy(polynomial2._coefficients, coeffPolynomial2, polynomial2.MaxExponent + 1);

            for (int i = 0; i < polynomial1.MaxExponent + 1; i++)
            {
                if (Math.Abs(coeffPolynomial1[i] - coeffPolynomial2[i]) > DefaultAccuracy)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion !Operator !=

        #region Public methods

        /// <summary>
        /// This method checks equality of <paramref name="polynomial1"/> and <paramref name="polynomial2"/>.
        /// </summary>
        /// <param name="obj">A polynomial to check equality.</param>
        /// <returns>true if polynomials are equal.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, null) && ReferenceEquals(obj, null))
            {
                return true;
            }

            if (ReferenceEquals(this, null) || ReferenceEquals(obj, null))
            {
                return false;
            }

            return base.Equals(obj);
        }

        /// <summary>
        /// This method returns a hash code for the <see cref="Polynomial"/> object.
        /// </summary>
        /// <returns>The hash code for the <see cref="Polynomial"/> object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// This method returns a string representation of the <see cref="Polynomial"/> object.
        /// </summary>
        /// <returns>The string representation of the <see cref="Polynomial"/> object.</returns>
        public override string ToString()
        {
            string strPolynomial = this._coefficients[0].ToString();

            for (int i = 1; i < this.MaxExponent + 1; i++)
            {
                if (this._coefficients[i] >= 0)
                {
                    strPolynomial += " + ";
                }
                else
                {
                    strPolynomial += " - ";
                }

                strPolynomial += Math.Abs(this._coefficients[i]).ToString() + " * " + "x^" + i.ToString();
            }

            return strPolynomial;
        }

        #endregion !Public methods
    }
}
