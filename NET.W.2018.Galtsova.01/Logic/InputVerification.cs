using System;

namespace Logic
{
    /// <summary>
    /// Provides a method of input data verification.
    /// </summary>
    public static class InputVerification
    {
        /// <summary>
        /// This method checks input data array.
        /// </summary>
        /// <param name="inputArray">Input data array.</param>
        public static void VerifyInputCorrect(int[] inputArray)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException(nameof(inputArray));
            }

            if (inputArray.Length < 1)
            {
                throw new ArgumentOutOfRangeException("Array length must be more than 0", nameof(inputArray));
            }
        }
    }
}
