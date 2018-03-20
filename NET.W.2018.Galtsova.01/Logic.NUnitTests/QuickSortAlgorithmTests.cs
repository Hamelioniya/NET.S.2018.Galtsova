using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logic.NUnitTests
{
    [TestFixture]
    public class QuickSortAlgorithmTests
    { 
        [TestCase(new[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new[] { 6, 5, 4, 3, 2, 1 })]
        [TestCase(new[] { 4, 3, 6, 1, 2, 5 })]
        [TestCase(new[] { 6, 6, 6, 6, 6, 6 })]
        [TestCase(new[] { 4, 2, 6, 5, 4, 1, 3, 2 })]
        public void QuickSortAlgorithm_QuickSortTests(int[] array)
        {
            QuickSortAlgorithm.Sort(array);

            Assert.IsTrue(IsSorted(array));
        }

        private bool IsSorted(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
