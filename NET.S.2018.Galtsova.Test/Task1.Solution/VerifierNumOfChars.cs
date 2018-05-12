using System;
using System.Linq;

namespace Task1.Solution
{
    public class VerifierNumOfChars : IVerifier
    {
        public Tuple<bool, string> Verify(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password must not be empty or equal to null.", nameof(password));
            }

            // check if length more than 7 chars 
            if (password.Length <= 7)
            {
                return Tuple.Create(false, $"{password} length too short");
            }

            // check if length more than 10 chars for admins
            if (password.Length >= 15)
            {
                return Tuple.Create(false, $"{password} length too long");
            }

            return Tuple.Create(true, "Password is Ok. User was created");
        }
    }
}
