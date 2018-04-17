using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using DAL.Interface.Interfaces;
using BLL.Interface.Interfaces;
using BLL.Repositories;
using DAL.Interface.DTO;
using System.Collections;

namespace BLL.Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        [TestCase("Ivan", "Ivanov", 10, AccountType.Base)]
        [TestCase("Petr", "Petrov", 100, AccountType.Gold)]
        [TestCase("Anna", "Ivanova", 10000, AccountType.Platinum)]
        public void OpenAccount_AddNewBankAccountTests(string userName, string userSurname, decimal amount, AccountType type)
        {
            Mock<IAccountStorage> mockStorage = new Mock<IAccountStorage>();
            Mock<IBonusCounter> mockCounter = new Mock<IBonusCounter>();
            Mock<IIDGenerator> mockGenerator = new Mock<IIDGenerator>();

            BankAccountService bankAccount = new BankAccountService(mockStorage.Object, mockCounter.Object);
            bankAccount.OpenBankAccount(userName, userSurname, amount, mockGenerator.Object, type);

            mockGenerator.Verify(generator => generator.GetId(), Times.Once);
            mockStorage.Verify(storage => storage.AddAccount(
                It.Is<Account>(account =>
                account.UserName == userName &&
                account.UserSurname == userSurname &&
                account.Amount == amount &&
                account.Type == (int)type)),
                Times.Once);
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCaseRemove))]
        public void CloseAccount_RemoveBankAccountTests(List<Account> collection, int id)
        {
            Mock<IAccountStorage> mockStorage = new Mock<IAccountStorage>();
            Mock<IBonusCounter> mockCounter = new Mock<IBonusCounter>();
            Mock<IIDGenerator> mockGenerator = new Mock<IIDGenerator>();

            mockStorage.Setup(storage => storage.GetAllAccounts()).Returns(collection);

            BankAccountService service = new BankAccountService(mockStorage.Object, mockCounter.Object);
            service.CloseBankAccount(id);

            mockStorage.Verify(storage => storage.RemoveAccount(
                It.Is<Account>(account =>
                account.UserName == collection.Find(x => x.Id == id).UserName &&
                account.UserSurname == collection.Find(x => x.Id == id).UserSurname &&
                account.Amount == collection.Find(x => x.Id == id).Amount &&
                account.Type == collection.Find(x => x.Id == id).Type)),
                Times.Once);
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCaseRefillWithdrawal))]
        public void Refill_RefillAmountFromBankAccountTests(List<Account> collection, int id, decimal amount)
        {
            Mock<IAccountStorage> mockStorage = new Mock<IAccountStorage>();
            Mock<IBonusCounter> mockCounter = new Mock<IBonusCounter>();
            Mock<IIDGenerator> mockGenerator = new Mock<IIDGenerator>();

            mockStorage.Setup(storage => storage.GetAllAccounts()).Returns(collection);

            BankAccountService service = new BankAccountService(mockStorage.Object, mockCounter.Object);
            service.Refill(id, amount);

            mockCounter.Verify(counter => counter.GetBonusFromRefill(
                It.Is<int>(type => type.Equals(collection.Find(x => x.Id == id).Type)), It.Is<decimal>(refillAmount => refillAmount.Equals(amount))),
                Times.Once);
            mockStorage.Verify(storage => storage.UpdateAccount(
                It.Is<Account>(account =>
                account.UserName == collection.Find(x => x.Id == id).UserName &&
                account.UserSurname == collection.Find(x => x.Id == id).UserSurname &&
                account.Type == collection.Find(x => x.Id == id).Type)),
                Times.Once);
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCaseRefillWithdrawal))]
        public void Withdrawal_WithdrawalAmountToBankAccountTests(List<Account> collection, int id, decimal amount)
        {
            Mock<IAccountStorage> mockStorage = new Mock<IAccountStorage>();
            Mock<IBonusCounter> mockCounter = new Mock<IBonusCounter>();
            Mock<IIDGenerator> mockGenerator = new Mock<IIDGenerator>();

            mockStorage.Setup(storage => storage.GetAllAccounts()).Returns(collection);

            BankAccountService service = new BankAccountService(mockStorage.Object, mockCounter.Object);
            service.Withdrawal(id, amount);

            mockCounter.Verify(counter => counter.GetBonuxFromWithdrawal(
                It.Is<int>(type => type.Equals(collection.Find(x => x.Id == id).Type)), It.Is<decimal>(refillAmount => refillAmount.Equals(amount))),
                Times.Once);
            mockStorage.Verify(storage => storage.UpdateAccount(
                It.Is<Account>(account =>
                account.UserName == collection.Find(x => x.Id == id).UserName &&
                account.UserSurname == collection.Find(x => x.Id == id).UserSurname &&
                account.Type == collection.Find(x => x.Id == id).Type)),
                Times.Once);
        }

        [Test]
        public void GetAllAccounts_GetAllBankAccountsTests()
        {
            Mock<IAccountStorage> mockStorage = new Mock<IAccountStorage>();
            Mock<IBonusCounter> mockCounter = new Mock<IBonusCounter>();
            Mock<IIDGenerator> mockGenerator = new Mock<IIDGenerator>();

            BankAccountService service = new BankAccountService(mockStorage.Object, mockCounter.Object);
            service.GetAllAccounts();

            mockStorage.Verify(storage => storage.GetAllAccounts(), Times.Exactly(2));
        }

        private class TestCasesClass
        {
            public static IEnumerable TestCaseRemove
            {
                get
                {
                    yield return new TestCaseData(new List<Account>() {
                        new Account()
                        {
                            Id = 0,
                            UserName = "Ivan",
                            UserSurname = "Ivanov",
                            Amount = 10,
                            Type = (int)AccountType.Base
                        },
                        new Account()
                        {
                            Id = 1,
                            UserName = "Petya",
                            UserSurname = "Petrov",
                            Amount = 100,
                            Type = (int)AccountType.Gold
                        },
                        new Account()
                        {
                            Id = 2,
                            UserName = "Anna",
                            UserSurname = "Ivanova",
                            Amount = 1000,
                            Type = (int)AccountType.Platinum
                        }
                    }, 
                    1);
                }
            }

            public static IEnumerable TestCaseRefillWithdrawal
            {
                get
                {
                    yield return new TestCaseData(new List<Account>() {
                        new Account()
                        {
                            Id = 0,
                            UserName = "Ivan",
                            UserSurname = "Ivanov",
                            Amount = 10,
                            Type = (int)AccountType.Base
                        },
                        new Account()
                        {
                            Id = 1,
                            UserName = "Petya",
                            UserSurname = "Petrov",
                            Amount = 100,
                            Type = (int)AccountType.Gold
                        },
                        new Account()
                        {
                            Id = 2,
                            UserName = "Anna",
                            UserSurname = "Ivanova",
                            Amount = 1000,
                            Type = (int)AccountType.Platinum
                        }
                    },
                    1, 20M);
                }
            }
        }
    }
}
