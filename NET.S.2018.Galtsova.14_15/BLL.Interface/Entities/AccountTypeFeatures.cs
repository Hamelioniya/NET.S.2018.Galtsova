using System;
using BLL.Interface.Interfaces;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Represents characteristics of account types.
    /// </summary>
    public class AccountTypeFeatures
    {
        #region Public constructors

        /// <summary>
        /// Initializes an instance of the <see cref="AccountTypeFeatures"/> with the passed bank account type.
        /// </summary>
        /// <param name="type">The bank account type.</param>
        public AccountTypeFeatures(AccountType type)
        {
            switch (type)
            {
                case AccountType.Base:
                    {
                        SetPricesForBase();
                        break;
                    }

                case AccountType.Gold:
                    {
                        SetPriceForGold();
                        break;
                    }

                case AccountType.Platinum:
                    {
                        SetPriceForPlatinum();
                        break;
                    }

                default:
                    {
                        throw new ArgumentException("No such type of bank account.", nameof(type));
                    }
            }
        }

        #endregion !Public constructors.

        #region Public properties

        /// <summary>
        /// A refill price.
        /// </summary>
        public decimal RefillPrice { get; private set; }

        /// <summary>
        /// A withdrawal price.
        /// </summary>
        public decimal WithdrawalPrice { get; private set; }

        #endregion !Public properties.

        #region Private methods

        /// <summary>
        /// Sets prices to make operations with the <see cref="AccountType.Base"/> bank account.
        /// </summary>
        private void SetPricesForBase()
        {
            RefillPrice = 10;
            WithdrawalPrice = 8;
        }

        /// <summary>
        /// Sets prices to make operations with the <see cref="AccountType.Gold"/> bank account.
        /// </summary>
        private void SetPriceForGold()
        {
            RefillPrice = 8;
            WithdrawalPrice = 6;
        }

        /// <summary>
        /// Sets prices to make operations with the <see cref="AccountType.Platinum"/> bank account.
        /// </summary>
        private void SetPriceForPlatinum()
        {
            RefillPrice = 6;
            WithdrawalPrice = 4;
        }

        #endregion !Private methods.
    }
}
