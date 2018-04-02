using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    /// <summary>
    /// Represents an interface for bank account list storage.
    /// </summary>
    public interface IBankAccountListStorage
    {
        /// <summary>
        /// Gets a list of bank accounts by the path <paramref name="filePath"/>.
        /// </summary>
        /// <param name="filePath">A file path.</param>
        /// <returns>A list of bank accounts.</returns>
        List<BankAccount> GetListOfBankAccounts(string filePath);

        /// <summary>
        /// Saves a list <paramref name="bankAccounts"/> by the path <paramref name="filePath"/>.
        /// </summary>
        /// <param name="filePath">A file path.</param>
        /// <param name="bankAccounts"> A list of bank accounts.</param>
        void SaveListOfBankAccounts(string filePath, List<BankAccount> bankAccounts);
    }
}
