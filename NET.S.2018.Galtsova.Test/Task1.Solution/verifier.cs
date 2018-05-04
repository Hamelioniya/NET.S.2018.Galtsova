using System;
using System.Linq;

namespace Task1.Solution
{
    public static class Verifier
    {
        public static Tuple<bool, string> VerifyNumOfChars(string password)
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

        public static Tuple<bool, string> VerifyCharacters(string password)
        {
            // check if password conatins at least one alphabetical character 
            if (!password.Any(char.IsLetter))
            {
                return Tuple.Create(false, $"{password} hasn't alphanumerical chars");
            }

            // check if password conatins at least one digit character 
            if (!password.Any(char.IsNumber))
            {
                return Tuple.Create(false, $"{password} hasn't digits");
            }

            return Tuple.Create(true, "Password is Ok. User was created");
        }
    }
}
