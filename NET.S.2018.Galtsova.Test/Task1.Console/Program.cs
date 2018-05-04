using System;
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
            Func<string, Tuple<bool, string>> verifiers = Verifier.VerifyCharacters;
            verifiers += Verifier.VerifyNumOfChars;

            System.Console.WriteLine(checker.VerifyPassword(password, verifiers));

            System.Console.ReadKey();
        }
    }
}
