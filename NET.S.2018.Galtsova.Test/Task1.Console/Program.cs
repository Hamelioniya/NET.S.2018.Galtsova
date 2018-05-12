using System;
using System.Collections.Generic;
using Task1.Solution;

namespace Task1.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository reposirory = new SqlRepository();
            PasswordCheckerService checker = new PasswordCheckerService(reposirory);

            string password = System.Console.ReadLine();    
            List<IVerifier> verifiers = new List<IVerifier>() { new VerifierNumOfChars(), new VerifyCharacters() };

            System.Console.WriteLine(checker.VerifyPassword(password, verifiers));

            System.Console.ReadKey();
        }
    }
}
