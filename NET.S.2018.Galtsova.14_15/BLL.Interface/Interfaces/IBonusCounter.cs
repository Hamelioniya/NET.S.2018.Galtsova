namespace BLL.Interface.Interfaces
{
    /// <summary>
    /// Represents an interface for the bonus counter.
    /// </summary>
    public interface IBonusCounter
    {
        /// <summary>
        /// Gets a bonus after refill the account with the <paramref name="accountId"/> by the <paramref name="amount"/>.
        /// </summary>
        /// <param name="type">The bank account type.</param>
        /// <param name="amount">The amount to refill.</param>
        /// <returns>The bonus from refill.</returns>
        int GetBonusFromRefill(int type, decimal amount);

        /// <summary>
        /// Gets a bonus after withdrawal an <paramref name="amount"/> from the account with the <paramref name="accountId"/>.
        /// </summary>
        /// <param name="type">The bank account type.</param>
        /// <param name="amount">The amount to withdrawal.</param>
        /// <returns>The bonus from withdrawal.</returns>
        int GetBonuxFromWithdrawal(int type, decimal amount);
    }
}
