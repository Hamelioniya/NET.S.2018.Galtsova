namespace Bank
{
    /// <summary>
    /// Represents an interface for bank account list service.
    /// </summary>
    public interface IBankAccountListService
    {
        /// <summary>
        /// Adds a <paramref name="bankAccount"/> to the list of bank accounts.
        /// </summary>
        /// <param name="bankAccount">A bank account.</param>
        void AddBankAccount(BankAccount bankAccount);

        /// <summary>
        /// Removes a <paramref name="bankAccount"/> from the list of bank accounts.
        /// </summary>
        /// <param name="bankAccount">A bank account.</param>
        void RemoveBankAccount(BankAccount bankAccount);

        /// <summary>
        /// Refills a <paramref name="bankAccount"/> by <paramref name="amount"/>.
        /// </summary>
        /// <param name="bankAccount">A bank account.</param>
        /// <param name="amount">An amount.</param>
        void Refill(BankAccount bankAccount, decimal amount);

        /// <summary>
        /// Withdrawals a <paramref name="amount"/> from the <paramref name="bankAccount"/>.
        /// </summary>
        /// <param name="bankAccount">A bank account.</param>
        /// <param name="amount">An amount.</param>
        void Withdrawal(BankAccount bankAccount, decimal amount);
    }
}
