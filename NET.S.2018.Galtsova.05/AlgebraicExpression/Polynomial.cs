using System;

namespace AlgebraicExpression
{
    /// <summary>
    /// Provides methods to work with polynomials.
    /// </summary>
    public sealed class Polynomial
    {
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
            if (ReferenceEquals(polynomial1, null) & ReferenceEquals(polynomial2, null))
            {
                return new Polynomial(new[] { 0d });
            }

            if (ReferenceEquals(polynomial1, null))
            {
                return polynomial2;
            }

            if (ReferenceEquals(polynomial2, null))
            {
                return polynomial1;
            }

            double[] resultCoefficients = null;
            int minMaxExponent = 0;

            if (polynomial1.MaxExponent > polynomial2.MaxExponent)
            {
                resultCoefficients = new double[polynomial1.MaxExponent + 1];
                Array.Copy(polynomial1._coefficients, resultCoefficients, polynomial1.MaxExponent + 1);
                minMaxExponent = polynomial2.MaxExponent + 1;
            }
            else
            {
                resultCoefficients = new double[polynomial2.MaxExponent + 1];
                Array.Copy(polynomial2._coefficients, resultCoefficients, polynomial2.MaxExponent + 1);
                minMaxExponent = polynomial1.MaxExponent + 1;
            }

            for (int i = 0; i < minMaxExponent; i++)
            {
                resultCoefficients[i] = polynomial1._coefficients[i] + polynomial2._coefficients[i];
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
            if (ReferenceEquals(polynomial1, null) & ReferenceEquals(polynomial2, null))
            {
                return new Polynomial(new[] { 0d });
            }

            if (ReferenceEquals(polynomial1, null))
            {
                return polynomial2;
            }

            if (ReferenceEquals(polynomial2, null))
            {
                return polynomial1;
            }

            double[] resultCoefficients = null;
            int minMaxExponent = 0;

            if (polynomial1.MaxExponent > polynomial2.MaxExponent)
            {
                resultCoefficients = new double[polynomial1.MaxExponent + 1];
                Array.Copy(polynomial1._coefficients, resultCoefficients, polynomial1.MaxExponent + 1);
                minMaxExponent = polynomial2.MaxExponent + 1;
            }
            else
            {
                resultCoefficients = new double[polynomial2.MaxExponent + 1];
                Array.Copy(polynomial2._coefficients, resultCoefficients, polynomial2.MaxExponent + 1);
                minMaxExponent = polynomial1.MaxExponent + 1;
            }

            for (int i = 0; i < minMaxExponent; i++)
            {
                resultCoefficients[i] = polynomial1._coefficients[i] - polynomial2._coefficients[i];
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
            if (ReferenceEquals(polynomial1, null) | ReferenceEquals(polynomial2, null))
            {
                return new Polynomial(new[] { 0d });
            }

            double[] resultCoefficients = new double[polynomial1.MaxExponent + polynomial2.MaxExponent + 1];

            for (int i = 0; i < polynomial1.MaxExponent + 1; i++)
            {
                for (int j = 0; j < polynomial2.MaxExponent + 1; j++)
                {
                    resultCoefficients[i + j] += polynomial1._coefficients[i] * polynomial2._coefficients[j];
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

            int digits = 5;
            for (int i = 0; i < polynomial1.MaxExponent + 1; i++)
            {
                if (Math.Round(polynomial1._coefficients[i], digits) != Math.Round(polynomial2._coefficients[i], digits))
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

            int digits = 5;
            for (int i = 0; i < polynomial1.MaxExponent + 1; i++)
            {
                if (Math.Round(polynomial1._coefficients[i], digits) != Math.Round(polynomial2._coefficients[i], digits))
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
