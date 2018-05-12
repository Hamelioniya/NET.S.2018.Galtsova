using System;
using System.Collections.Generic;

namespace Test6.Solution
{
    public static class ElementEnumerator<T>
    {
        public static IEnumerable<T> GetNumbers(T firstElement, T secondElement, int count, Func<T, T, T> calculator)
        {
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException("Count of numbers must be greater than 0.", nameof(count));
            }

            T firstLastElement = firstElement;
            T secondLastElement = secondElement;

            for (int i = 0; i < count; i++)
            {
                yield return firstLastElement;

                T temp = secondLastElement;
                secondLastElement = calculator(firstLastElement, secondLastElement);
                firstLastElement = temp;
            }
        }

    }
}
