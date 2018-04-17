using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    /// <summary>
    /// Represents an interface for bank account list service.
    /// </summary>
    public interface IBankAccountService
    {
        /// <summary>
        /// Creates a new bank account.
        /// </summary>
        /// <param name="userName">The new bank account user name.</param>
        /// <param name="userSurname">The new bank account user surname.</param>
        /// <param name="amount">The amount on the new bank account.</param>
        /// <param name="generator">The generator of the id.</param>
        /// <param name="type">The new bank account type.</param>
        void OpenBankAccount(string userName, string userSurname, decimal amount, IIDGenerator generator, AccountType type = AccountType.Base);

        /// <summary>
        /// Closes a bank account.
        /// </summary>
        /// <param name="id">The id of the account.</param>
        void CloseBankAccount(int id);

        /// <summary>
        /// Refills a bank account with the <paramref name="accountId"/> by <paramref name="amount"/>.
        /// </summary>
        /// <param name="accountId">The bank account id.</param>
        /// <param name="amount">The amount to refill.</param>
        void Refill(int accountId, decimal amount);

        /// <summary>
        /// Withdrawals a <paramref name="amount"/> from the bank account with the <paramref name="accountId"/>.
        /// </summary>
        /// <param name="accountId">The bank account id.</param>
        /// <param name="amount">The amount to withdrawal.</param>
        void Withdrawal(int accountId, decimal amount);

        /// <summary>
        /// Gets a sequence of all bank accounts.
        /// </summary>
        /// <returns>The sequence of all bank accounts.</returns>
        IEnumerable<BankAccount> GetAllAccounts();
    }
}
