using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Exceptions;
using BLL.Interface.Interfaces;
using BLL.Mappers;
using DAL.Interface.Exceptions;
using DAL.Interface.Interfaces;

namespace BLL.Services
{
    /// <summary>
    /// Represents a bank account service.
    /// </summary>
    public class BankAccountService : IBankAccountService
    {
        #region Private fields

        private IAccountStorage _bankAccountStorage;
        private IBonusCounter _bonusCouter;
        private List<BankAccount> _bankAccounts;

        #endregion !Private fields.

        #region Public constructors

        /// <summary>
        /// Initializes an instance of the <see cref="BankAccountService"/> with passed bank accounts storage and bonus counter.
        /// </summary>
        /// <param name="bankAccountStorage">The instance of the bank account storage interface.</param>
        /// <param name="bonusCounter">The instance of the bonus counter interface.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="bankAccountStorage"/> or/and <paramref name="bonusCounter"/> equal to null.
        /// </exception>
        public BankAccountService(IAccountStorage bankAccountStorage, IBonusCounter bonusCounter)
        {
            if (ReferenceEquals(bankAccountStorage, null))
            {
                throw new ArgumentNullException(nameof(bankAccountStorage));
            }

            if (ReferenceEquals(bonusCounter, null))
            {
                throw new ArgumentNullException(nameof(bonusCounter));
            }

            _bankAccountStorage = bankAccountStorage;
            _bonusCouter = bonusCounter;
            _bankAccounts = new List<BankAccount>();

            UpdateList();
        }

        /// <summary>
        /// Initializes an instance of the <see cref="BankAccountService"/> with passed collection of bank accounts,
        /// bank accounts storage and bonus counter.
        /// </summary>
        /// <param name="collection">The list of bank accounts.</param>
        /// <param name="bankAccountStorage">The instance of the bank account storage interface.</param>
        /// <param name="bonusCounter">The instance of the bonus counter interface.</param>
        public BankAccountService(IEnumerable<BankAccount> collection, IAccountStorage bankAccountStorage, IBonusCounter bonusCounter) : this(bankAccountStorage, bonusCounter)
        {
            BankAccounts = collection;
        }

        #endregion !Public constructors.

        #region Public properties

        /// <summary>
        /// List of bank accounts.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown when value or item in value equal to null.
        /// </exception>
        /// <exception cref="BankServiceException">
        /// Thrown when something wrong with adding the bank account to the storage.
        /// </exception>
        private IEnumerable<BankAccount> BankAccounts
        {
            set
            {
                if (ReferenceEquals(value, null))
                {
                    throw new ArgumentNullException(nameof(BankAccounts));
                }

                try
                {
                    foreach (var item in value)
                    {
                        _bankAccountStorage.AddAccount(item.ToAccount());
                        _bankAccounts.Add(item);
                    }
                }
                catch (AccountAlreadyExistsException ex)
                {
                    throw new BankServiceException("An error occured while adding to the storage.", ex);
                }
            }
        }

        #endregion !Public properties.

        #region IBankAccountService implementation

        /// <summary>
        /// Creates a bank account with passed user name, user surname, amount, type and id generator.
        /// and adds to the storage.
        /// </summary>
        /// <param name="userName">The user of bank account name.</param>
        /// <param name="userSurname">The user of bank account surname.</param>
        /// <param name="amount">The amount on the bank account.</param>
        /// <param name="generator">The generator of id.</param>
        /// <param name="type">The bank account type.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="userName"/>, <paramref name="userSurname"/>
        /// or/and <paramref name="generator"/> equal to null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the <paramref name="amount"/> less than 0.
        /// </exception>
        /// <exception cref="BankServiceException">
        /// Thrown when something wrong with adding the bank account to the storage.
        /// </exception>
        public void OpenBankAccount(string userName, string userSurname, decimal amount, IIDGenerator generator, AccountType type = AccountType.Base)
        {
            if (ReferenceEquals(userName, null))
            {
                throw new ArgumentNullException(nameof(userName));
            }

            if (ReferenceEquals(userSurname, null))
            {
                throw new ArgumentNullException(nameof(userSurname));
            }

            if (amount < 0)
            {
                throw new ArgumentException("The amount must be greater then or equal to 0.", nameof(amount));
            }

            if (ReferenceEquals(generator, null))
            {
                throw new ArgumentNullException(nameof(generator));
            }

            BankAccount newBankAccount = new BankAccount(generator.GetId(), userName, userSurname, amount, type);

            try
            {
                _bankAccountStorage.AddAccount(newBankAccount.ToAccount());
            }
            catch (AccountAlreadyExistsException ex)
            {
                throw new BankServiceException("An error occured while adding to the storage.", ex);
            }
        }

        /// <summary>
        /// Removes a bank account from the storage.
        /// </summary>
        /// <param name="id">The bank account id.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when the <paramref name="id"/> less than 0.
        /// </exception>
        /// <exception cref="BankServiceException">
        /// Thrown when the bank account with the <paramref name="id"/> not found or
        /// something wrong with removing from the storage.
        /// </exception>
        public void CloseBankAccount(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("The id must be greater than or equal to 0.", nameof(id));
            }

            UpdateList();

            BankAccount bankAccount = _bankAccounts.Find(x => x.ID == id);

            if (ReferenceEquals(bankAccount, null))
            {
                throw new BankServiceException("No such bank account.");
            }

            try
            {
                _bankAccountStorage.RemoveAccount(bankAccount.ToAccount());
            }
            catch (AccountNotFoundException ex)
            {
                throw new BankServiceException("An error occured while removing from the storage.", ex);
            }
        }

        /// <summary>
        /// Refills a bank account with the <paramref name="id"/> by the <paramref name="amount"/>.
        /// </summary>
        /// <param name="id">The bank account id.</param>
        /// <param name="amount">The amount to refill.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="id"/> or/and <paramref name="amount"/> less than 0.
        /// </exception>
        /// <exception cref="BankServiceException">
        /// Thrown when the bank account with the <paramref name="id"/> not found,
        /// something wrong with updating in the storage or insufficient founds to refill.
        /// </exception>
        public void Refill(int id, decimal amount)
        {
            if (id < 0)
            {
                throw new ArgumentException("The id must be greater than or equal to 0.", nameof(id));
            }

            if (amount < 0)
            {
                throw new ArgumentException("The amount must be greater than or equal to 0.", nameof(amount));
            }

            UpdateList();

            BankAccount bankAccount = _bankAccounts.Find(x => x.ID == id);

            if (ReferenceEquals(bankAccount, null))
            {
                throw new BankServiceException("No such bank account.");
            }

            AccountTypeFeatures features = new AccountTypeFeatures(bankAccount.Type);

            try
            {
                bankAccount.RefillAmount(amount - features.RefillPrice);
                bankAccount.SetBonusFromOperation(_bonusCouter.GetBonusFromRefill((int)bankAccount.Type, amount));

                _bankAccountStorage.UpdateAccount(bankAccount.ToAccount());
            }
            catch (InsufficientFundsException ex)
            {
                throw new BankServiceException("An error occured while refill amount.", ex);
            }
            catch (AccountNotFoundException ex)
            {
                throw new BankServiceException("An error occured while updating in the storage.", ex);
            }
        }

        /// <summary>
        /// Withdrawals a <paramref name="amount"/> from the bank account with the <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The bank account id.</param>
        /// <param name="amount">The amount to refill.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="id"/> or/and <paramref name="amount"/> less than 0.
        /// </exception>
        /// <exception cref="BankServiceException">
        /// Thrown when the bank account with the <paramref name="id"/> not found,
        /// something wrong with updating in the storage or insufficient founds to withdrawal.
        /// </exception>
        public void Withdrawal(int id, decimal amount)
        {
            if (id < 0)
            {
                throw new ArgumentException("The id must be greater than or equal to 0.", nameof(id));
            }

            if (amount < 0)
            {
                throw new ArgumentException("The amount must be greater than or equal to 0.", nameof(amount));
            }

            UpdateList();

            BankAccount bankAccount = _bankAccounts.Find(x => x.ID == id);

            if (ReferenceEquals(bankAccount, null))
            {
                throw new BankServiceException("No such bank account.");
            }

            AccountTypeFeatures features = new AccountTypeFeatures(bankAccount.Type);

            try
            {
                bankAccount.WithdrawalAmount(amount + features.WithdrawalPrice);
                bankAccount.SetBonusFromOperation(_bonusCouter.GetBonuxFromWithdrawal((int)bankAccount.Type, amount));

                _bankAccountStorage.UpdateAccount(bankAccount.ToAccount());
            }
            catch (InsufficientFundsException ex)
            {
                throw new BankServiceException("An error occured while withdrawal amount.", ex);
            }
            catch (AccountNotFoundException ex)
            {
                throw new BankServiceException("An error occured while updating in the storage.", ex);
            }
        }

        /// <summary>
        /// Gets a sequence of all bank accounts.
        /// </summary>
        /// <returns>The sequence of bank accounts.</returns>
        public IEnumerable<BankAccount> GetAllAccounts()
        {
            UpdateList();

            return _bankAccounts;
        }

        #endregion !IBankAccountService implementation.

        #region Private methods

        private void UpdateList()
        {
            _bankAccounts.Clear();

            _bankAccounts.AddRange(_bankAccountStorage.GetAllAccounts().Select(account => account.ToBankAccount()));
        }

        #endregion !Private methods.
    }
}
