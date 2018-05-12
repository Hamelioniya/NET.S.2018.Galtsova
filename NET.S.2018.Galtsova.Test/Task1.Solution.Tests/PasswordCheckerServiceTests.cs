using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Task1.Solution.Tests
{
    [TestFixture]
    public class PasswordCheckerServiceTests
    {
        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesSuccess))]
        public bool VerifyPassword_SuccessTests(string password, List<IVerifier> verifiers)
        {
            IRepository repository = new SqlRepository();
            PasswordCheckerService checker = new PasswordCheckerService(repository);

            return checker.VerifyPassword(password, verifiers).Item1;
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesFail))]
        public bool VerifyPassword_FailTests(string password, List<IVerifier> verifiers)
        {
            IRepository repository = new SqlRepository();
            PasswordCheckerService checker = new PasswordCheckerService(repository);

            return checker.VerifyPassword(password, verifiers).Item1;
        }

        private class TestCasesClass
        {
            public static IEnumerable TestCasesSuccess
            {
                get
                {
                    yield return new TestCaseData("12345678", new List<IVerifier>() { new VerifierNumOfChars()}).Returns(true);

                    yield return new TestCaseData("123qw", new List<IVerifier>() { new VerifyCharacters() }).Returns(true);

                    yield return new TestCaseData("123qw1234", new List<IVerifier>() { new VerifierNumOfChars(), new VerifyCharacters() }).Returns(true);
                }
            }

            public static IEnumerable TestCasesFail
            {
                get
                {
                    yield return new TestCaseData("123", new List<IVerifier>() { new VerifierNumOfChars() }).Returns(false);

                    yield return new TestCaseData("12313213", new List<IVerifier>() { new VerifyCharacters() }).Returns(false);

                    yield return new TestCaseData("123213123", new List<IVerifier>() { new VerifierNumOfChars(), new VerifyCharacters() }).Returns(false);
                }
            }
        }

    }
}
