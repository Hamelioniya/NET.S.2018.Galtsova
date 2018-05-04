using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task1.Solution.Tests
{
    [TestFixture]
    public class PasswordCheckerServiceTests
    {
        [TestCase("12qw5678", ExpectedResult = true)]
        public bool VerifyPassword_CheckCharactersSuccessTests(string password)
        {
            IRepository repository = new SqlRepository();
            PasswordCheckerService checker = new PasswordCheckerService(repository);

            return checker.VerifyPassword(password, new Func<string, Tuple<bool, string>>(Verifier.VerifyCharacters)).Item1;
        }

        [TestCase("12123456", ExpectedResult = true)]
        public bool VerifyPassword_CheckNumOfCharsSuccessTests(string password)
        {
            IRepository repository = new SqlRepository();
            PasswordCheckerService checker = new PasswordCheckerService(repository);

            return checker.VerifyPassword(password, new Func<string, Tuple<bool, string>>(Verifier.VerifyNumOfChars)).Item1;
        }

        [TestCase("12qw5678", ExpectedResult = true)]
        public bool VerifyPassword_CheckCharactersAndNumOfCharsSuccessTests(string password)
        {
            IRepository repository = new SqlRepository();
            PasswordCheckerService checker = new PasswordCheckerService(repository);

            Func<string, Tuple<bool, string>> verifiers = Verifier.VerifyCharacters;
            verifiers += Verifier.VerifyNumOfChars;

            return checker.VerifyPassword(password, verifiers).Item1;
        }

        [TestCase("1321132", ExpectedResult = false)]
        public bool VerifyPassword_CheckCharactersFailTests(string password)
        {
            IRepository repository = new SqlRepository();
            PasswordCheckerService checker = new PasswordCheckerService(repository);

            return checker.VerifyPassword(password, new Func<string, Tuple<bool, string>>(Verifier.VerifyCharacters)).Item1;
        }

        [TestCase("1", ExpectedResult = false)]
        public bool VerifyPassword_CheckNumOfCharsTests(string password)
        {
            IRepository repository = new SqlRepository();
            PasswordCheckerService checker = new PasswordCheckerService(repository);

            return checker.VerifyPassword(password, new Func<string, Tuple<bool, string>>(Verifier.VerifyNumOfChars)).Item1;
        }

        [TestCase("12115678", ExpectedResult = false)]
        public bool VerifyPassword_CheckCharactersAndNumOfCharsFailTests(string password)
        {
            IRepository repository = new SqlRepository();
            PasswordCheckerService checker = new PasswordCheckerService(repository);

            Func<string, Tuple<bool, string>> verifiers = Verifier.VerifyCharacters;
            verifiers += Verifier.VerifyNumOfChars;

            return checker.VerifyPassword(password, verifiers).Item1;
        }

    }
}
