namespace Bank
{
    /// <summary>
    /// Represents a bonus counter.
    /// </summary>
    public class BonusCounter : IBonusCounter
    {
        #region Public methods

        /// <summary>
        /// Gets a bonus after refill <paramref name="bankAccount"/> by the <paramref name="amount"/>.
        /// </summary>
        /// <param name="bankAccount">A bank account.</param>
        /// <param name="amount">An amount.</param>
        /// <returns>A bonus.</returns>
        public int GetBonusFromRefill(BankAccount bankAccount, decimal amount)
        {
            AccountFeatures features = new AccountFeatures(bankAccount.Type);

            return (int)(0.1m * amount / features.RefillPrice);
        }

        /// <summary>
        /// Gets a bonus after withdrawal an <paramref name="amount"/> from the <paramref name="bankAccount"/>.
        /// </summary>
        /// <param name="bankAccount">A bank account.</param>
        /// <param name="amount">An amount.</param>
        /// <returns>A bonus.</returns>
        public int GetBonuxFromWithdrawal(BankAccount bankAccount, decimal amount)
        {
            AccountFeatures features = new AccountFeatures(bankAccount.Type);

            return (int)(0.1m * amount / features.WithdrawalPrice);
        }

        #endregion !Public methods.
    }
}
