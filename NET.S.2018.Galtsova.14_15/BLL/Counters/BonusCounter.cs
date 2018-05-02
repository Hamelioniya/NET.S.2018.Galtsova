using BLL.Interface.Entities;
using BLL.Interface.Interfaces;

namespace BLL.Counters
{
    /// <summary>
    /// Represents a bonus counter.
    /// </summary>
    public class BonusCounter : IBonusCounter
    {
        #region Public methods

        /// <summary>
        /// Gets a bonus after refill the bank account with the <paramref name="type"/> by the <paramref name="amount"/>.
        /// </summary>
        /// <param name="type">The bank account type.</param>
        /// <param name="amount">The amount to refill.</param>
        /// <returns>The bonus from refill.</returns>
        public int GetBonusFromRefill(int type, decimal amount)
        {
            AccountTypeFeatures features = new AccountTypeFeatures((AccountType)type);

            return (int)(0.1m * amount / features.RefillPrice);
        }

        /// <summary>
        /// Gets a bonus after withdrawal an <paramref name="amount"/> from the bank account with the <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The bank account type.</param>
        /// <param name="amount">The amount to refill.</param>
        /// <returns>The bonus from withdrawal.</returns>
        public int GetBonuxFromWithdrawal(int type, decimal amount)
        {
            AccountTypeFeatures features = new AccountTypeFeatures((AccountType)type);

            return (int)(0.1m * amount / features.WithdrawalPrice);
        }

        #endregion !Public methods.
    }
}
