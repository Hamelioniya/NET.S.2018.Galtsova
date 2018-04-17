using System;
using System.Collections.Generic;
using DAL.Interface.DTO;
using DAL.Interface.Exceptions;
using DAL.Interface.Interfaces;

namespace DAL.Repositories
{
    /// <summary>
    /// Represents an account storage.
    /// </summary>
    public class AccountStorage : IAccountStorage
    {
        #region Private fields

        private List<Account> _accounts;

        #endregion !Private fields.

        #region Public constructors

        /// <summary>
        /// Initializes an instance of the <see cref="AccountStorage"/>.
        /// </summary>
        public AccountStorage()
        {
            _accounts = new List<Account>();
        }

        /// <summary>
        /// Initializes an instance of the <see cref="AccountStorage"/> with the passed collection.
        /// </summary>
        /// <param name="collection">The passed collection to add.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="collection"/> equal to null.
        /// </exception>
        public AccountStorage(IEnumerable<Account> collection)
        {
            if (ReferenceEquals(collection, null))
            {
                throw new ArgumentNullException(nameof(collection));
            }

            foreach (var item in collection)
            {
                _accounts.Add(item);
            }
        }

        #endregion !Public constructors.

        #region IAccountStorage implementation

        /// <summary>
        /// Adds a new account to the list of accounts.
        /// </summary>
        /// <param name="account">The new account to add.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="account"/> equal to null.
        /// </exception>
        /// <exception cref="AccountAlreadyExistsException">
        /// Thrown when the <paramref name="account"/> or the account with such id already exists in the list of accounts.
        /// </exception> 
        public void AddAccount(Account account)
        {
            if (ReferenceEquals(account, null))
            {
                throw new ArgumentNullException(nameof(account));
            }

            if (_accounts.Exists(x => x.Id == account.Id))
            {
                throw new AccountAlreadyExistsException("This account already exists.");
            }

            if (!ReferenceEquals(_accounts.Find(x => x.Id == account.Id), null))
            {
                throw new AccountAlreadyExistsException("Account with such ID already exists.");
            }

            _accounts.Add(account);
        }

        /// <summary>
        /// Removes an account from the list of accounts.
        /// </summary>
        /// <param name="account">The account to remove.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="account"/> equal to null.
        /// </exception>
        /// <exception cref="AccountNotFoundException">
        /// Thrown when the <paramref name="account"/> not found in the list of accounts.
        /// </exception>
        public void RemoveAccount(Account account)
        {
            if (ReferenceEquals(account, null))
            {
                throw new ArgumentNullException(nameof(account));
            }

            if (!_accounts.Exists(x => x.Id == account.Id))
            {
                throw new AccountNotFoundException("This account not found.");
            }

            _accounts.Remove(_accounts.Find(x => x.Id == account.Id));
        }

        /// <summary>
        /// Updates an account in the list of accounts.
        /// </summary>
        /// <param name="account">The account to remove.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="account"/> equal to null.
        /// </exception>
        /// <exception cref="AccountNotFoundException">
        /// Thrown when the account with the <paramref name="account"/> id not found in the list of accounts.
        /// </exception>
        public void UpdateAccount(Account account)
        {
            if (ReferenceEquals(account, null))
            {
                throw new ArgumentNullException(nameof(account));
            }

            if (ReferenceEquals(_accounts.Find(x => x.Id == account.Id), null))
            {
                throw new AccountNotFoundException("Account with such ID not found.");
            }

            _accounts.Remove(_accounts.Find(x => x.Id == account.Id));
            _accounts.Add(account);
        }

        /// <summary>
        /// Gets an account by the <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of the account.</param>
        /// <exception cref="AccountNotFoundException">
        /// Thrown when the account with the <paramref name="id"/> not found in the list of accounts.
        /// </exception>
        /// <returns>The account with the <paramref name="id"/> from the list of accounts.</returns>
        public Account GetAccount(int id)
        {
            if (ReferenceEquals(_accounts.Find(x => x.Id == id), null))
            {
                throw new AccountNotFoundException("Account with such ID not found.");
            }

            return _accounts.Find(x => x.Id == id);
        }

        /// <summary>
        /// Gets all accounts from the list of accounts.
        /// </summary>
        /// <returns>The list of all accounts.</returns>
        public IEnumerable<Account> GetAllAccounts()
        {
            return _accounts;
        }

        #endregion !IAccountStorage implementation.
    }
}
