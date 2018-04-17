using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    /// <summary>
    /// Represents an adapter for accounts.
    /// </summary>
    public static class AccountMapper
    {
        /// <summary>
        /// Represents an object of the <see cref="BankAccount"/> as an object of the <see cref="Account"/>.
        /// </summary>
        /// <returns>The object of the <see cref="Account"/>.</returns>
        public static Account ToAccount(this BankAccount account)
        {
            if (ReferenceEquals(account, null))
            {
                return null;
            }

            Account newAccount = new Account()
            {
                Id = account.ID,
                UserName = account.UserName,
                UserSurname = account.UserSurname,
                Amount = account.Amount,
                Bonus = account.Bonus,
                Type = (int)account.Type
            };

            return newAccount;
        }

        /// <summary>
        /// Represents an object of the <see cref="Account"/> as an object of the <see cref="BankAccount"/>.
        /// </summary>
        /// <returns>The object of the <see cref="BankAccount"/>.</returns>
        public static BankAccount ToBankAccount(this Account account)
        {
            BankAccount bankAccount = new BankAccount(account.Id, account.UserName, account.UserSurname, account.Amount, (AccountType)account.Type);
            bankAccount.SetBonusFromOperation(account.Bonus);

            return bankAccount;
        }
    }
}
