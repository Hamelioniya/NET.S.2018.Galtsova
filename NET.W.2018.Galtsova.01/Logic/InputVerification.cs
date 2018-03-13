using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class InputVerification
    {
        public static void VerifyInputCorrect(int[] inputArray)
        {
            if (inputArray == null)
                throw new ArgumentNullException("Array must be not null");

            if (inputArray.Length < 1)
                throw new ArgumentOutOfRangeException("Array length must be more than 0");
        }
    }
}
