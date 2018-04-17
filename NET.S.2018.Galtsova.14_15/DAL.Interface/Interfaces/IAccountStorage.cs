using System.Collections.Generic;
using DAL.Interface.DTO;

namespace DAL.Interface.Interfaces
{
    /// <summary>
    /// Represents an interface for account storage.
    /// </summary>
    public interface IAccountStorage
    {
        /// <summary>
        /// Adds a new account to the storage.
        /// </summary>
        /// <param name="account">The new account to add.</param>
        void AddAccount(Account account);

        /// <summary>
        /// Removes an account from the storage.
        /// </summary>
        /// <param name="account">The account to remove.</param>
        void RemoveAccount(Account account);

        /// <summary>
        /// Updates an account in the storage.
        /// </summary>
        /// <param name="account">The account for update with new data.</param>
        void UpdateAccount(Account account);

        /// <summary>
        /// Gets an account from the storage by the <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of account to get.</param>
        /// <returns>The account with the passed <paramref name="id"/>.</returns>
        Account GetAccount(int id);

        /// <summary>
        /// Gets a sequence of all accounts from the storage.
        /// </summary>
        /// <returns>The sequence of all accounts.</returns>
        IEnumerable<Account> GetAllAccounts();
    }
}
