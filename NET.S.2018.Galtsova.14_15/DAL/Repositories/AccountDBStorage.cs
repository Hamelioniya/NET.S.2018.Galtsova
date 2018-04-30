using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Exceptions;
using DAL.Interface.Interfaces;

namespace DAL.Repositories
{
    /// <summary>
    /// Represents an account storage.
    /// </summary>
    public class AccountDBStorage : IAccountStorage
    {
        private AccountContext db = new AccountContext();

        #region IAccountStorage implementation

        /// <summary>
        /// Adds a new account to the table of accounts.
        /// </summary>
        /// <param name="account">The new account to add.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="account"/> equal to null.
        /// </exception>
        /// <exception cref="AccountAlreadyExistsException">
        /// Thrown when the <paramref name="account"/> or the account with such id already exists in the table of accounts.
        /// </exception> 
        public void AddAccount(Account account)
        {
            if (ReferenceEquals(account, null))
            {
                throw new ArgumentNullException(nameof(account));
            }

            if (!ReferenceEquals(db.Accounts.FirstOrDefault(x => x.UserName == account.UserName && x.UserSurname == account.UserSurname), null))
            {
                throw new AccountAlreadyExistsException("This account already exists.");
            }

            if (!ReferenceEquals(db.Accounts.Find(account.Id), null))
            {
                throw new AccountAlreadyExistsException("Account with such ID already exists.");
            }

            db.Accounts.Add(account);
            db.SaveChanges();
        }

        /// <summary>
        /// Gets an account by the <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of the account.</param>
        /// <exception cref="AccountNotFoundException">
        /// Thrown when the account with the <paramref name="id"/> not found in the table of accounts.
        /// </exception>
        /// <returns>The account with the <paramref name="id"/> from the table of accounts.</returns>
        public Account GetAccount(int id)
        {
            Account account = db.Accounts.Find(id);

            if (ReferenceEquals(account, null))
            {
                throw new AccountNotFoundException("Account with such ID not found.");
            }

            return account;
        }

        /// <summary>
        /// Gets all accounts from the table of accounts.
        /// </summary>
        /// <returns>The list of all accounts.</returns>
        public IEnumerable<Account> GetAllAccounts()
        {
            return db.Accounts.ToList();
        }

        /// <summary>
        /// Removes an account from the table of accounts.
        /// </summary>
        /// <param name="account">The account to remove.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="account"/> equal to null.
        /// </exception>
        /// <exception cref="AccountNotFoundException">
        /// Thrown when the <paramref name="account"/> not found in the table of accounts.
        /// </exception>
        public void RemoveAccount(Account account)
        {
            if (ReferenceEquals(account, null))
            {
                throw new ArgumentNullException(nameof(account));
            }

            Account accountForDelete = db.Accounts.Find(account.Id);

            if (ReferenceEquals(accountForDelete, null))
            {
                throw new AccountNotFoundException("This account not found.");
            }

            db.Accounts.Remove(accountForDelete);
            db.SaveChanges();
        }

        /// <summary>
        /// Updates an account in the table of accounts.
        /// </summary>
        /// <param name="account">The account to remove.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="account"/> equal to null.
        /// </exception>
        /// <exception cref="AccountNotFoundException">
        /// Thrown when the account with the <paramref name="account"/> id not found in the table of accounts.
        /// </exception>
        public void UpdateAccount(Account account)
        {
            if (ReferenceEquals(account, null))
            {
                throw new ArgumentNullException(nameof(account));
            }

            Account accountForUpdate = db.Accounts.Find(account.Id);

            if (ReferenceEquals(accountForUpdate, null))
            {
                throw new AccountNotFoundException("Account with such ID not found.");
            }

            accountForUpdate.Amount = account.Amount;
            accountForUpdate.Bonus = account.Bonus;
            accountForUpdate.Type = account.Type;
            db.SaveChanges();
        }

        #endregion !IAccountStorage implementation.
    }
}
