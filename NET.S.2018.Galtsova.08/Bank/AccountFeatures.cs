using System;

namespace Bank
{
    /// <summary>
    /// Represents characteristics of account types.
    /// </summary>
    public class AccountFeatures
    {
        #region Public constructors

        /// <summary>
        /// Initializes an instance of the <see cref="AccountFeatures"/> with the passed bank account type.
        /// </summary>
        /// <param name="type">A bank account type.</param>
        public AccountFeatures(Account type)
        {
            switch (type)
            {
                case Account.Base:
                    {
                        SetPricesForBase();
                        break;
                    }

                case Account.Gold:
                    {
                        SetPriceForGold();
                        break;
                    }

                case Account.Platinum:
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
        /// Refill price.
        /// </summary>
        public decimal RefillPrice { get; private set; }

        /// <summary>
        /// Withdrawal price.
        /// </summary>
        public decimal WithdrawalPrice { get; private set; }

        #endregion !Public properties.

        #region Private methods

        /// <summary>
        /// Sets prices to make operations with the <see cref="Account.Base"/> bank account.
        /// </summary>
        private void SetPricesForBase()
        {
            RefillPrice = 10;
            WithdrawalPrice = 8;
        }

        /// <summary>
        /// Sets prices to make operations with the <see cref="Account.Gold"/> bank account.
        /// </summary>
        private void SetPriceForGold()
        {
            RefillPrice = 8;
            WithdrawalPrice = 6;
        }

        /// <summary>
        /// Sets prices to make operations with the <see cref="Account.Platinum"/> bank account.
        /// </summary>
        private void SetPriceForPlatinum()
        {
            RefillPrice = 6;
            WithdrawalPrice = 4;
        }

        #endregion !Private methods.
    }
}
