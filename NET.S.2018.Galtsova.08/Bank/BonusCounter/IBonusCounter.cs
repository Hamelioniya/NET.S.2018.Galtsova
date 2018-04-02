namespace Bank
{
    /// <summary>
    /// Represents an interface for the bonus counter.
    /// </summary>
    public interface IBonusCounter
    {
        /// <summary>
        /// Gets a bonus after refill <paramref name="bankAccount"/> by the <paramref name="amount"/>.
        /// </summary>
        /// <param name="bankAccount">A bank account.</param>
        /// <param name="amount">An amount.</param>
        /// <returns>A bonus.</returns>
        int GetBonusFromRefill(BankAccount bankAccount, decimal amount);

        /// <summary>
        /// Gets a bonus after withdrawal an <paramref name="amount"/> from the <paramref name="bankAccount"/>.
        /// </summary>
        /// <param name="bankAccount">A bank account.</param>
        /// <param name="amount">An amount.</param>
        /// <returns>A bonus.</returns>
        int GetBonuxFromWithdrawal(BankAccount bankAccount, decimal amount);
    }
}
