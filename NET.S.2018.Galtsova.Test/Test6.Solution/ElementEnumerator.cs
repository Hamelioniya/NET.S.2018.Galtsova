using System;
using System.Collections.Generic;

namespace Test6.Solution
{
    public class ElementEnumerator<T>
    {
        private T _firstNumber;
        private T _secondNumber;

        public ElementEnumerator(T firstNumber, T secondNumber)
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
        }

        private T FirstNumber
        {
            set
            {
                if ((dynamic)value < 0)
                {
                    throw new ArgumentOutOfRangeException("First number must be greter than 0.", nameof(FirstNumber));
                }

                _firstNumber = value;
            }
        }

        private T SecondNumber
        {
            set
            {
                if ((dynamic)value <= 0)
                {
                    throw new ArgumentOutOfRangeException("First number must be greter than 0.", nameof(SecondNumber));
                }

                _secondNumber = value;
            }
        }


        public IEnumerable<T> GetNumbers(int count, Func<T, T, T> calculator)
        {
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException("Count of numbers must be greater than 0.", nameof(count));
            }

            T firstLastNumber = _firstNumber;
            T secondLastNumber = _secondNumber;

            for (int i = 0; i < count; i++)
            {
                yield return firstLastNumber;

                T temp = secondLastNumber;
                secondLastNumber = calculator(firstLastNumber, secondLastNumber);
                firstLastNumber = temp;
            }
        }

    }
}
