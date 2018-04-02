using System;
using System.Collections.Generic;
using System.IO;

namespace Bank
{
    /// <summary>
    /// Represents a bank account list storage.
    /// </summary>
    public class BankAccountListStorage : IBankAccountListStorage
    {
        #region Private fields

        private const string StorageFilePath = "bankAccounts.txt";

        #endregion !Private fields.

        #region Public methods

        /// <summary>
        /// Gets a list of banks accounts.
        /// </summary>
        /// <returns>A list of bank accounts.</returns>
        public List<BankAccount> GetListOfBankAccounts() => GetListOfBankAccounts(StorageFilePath);

        /// <summary>
        /// Saves a list <paramref name="bankAccounts"/>.
        /// </summary>
        /// <param name="bankAccounts">A list of bank accounts.</param>
        public void SaveListOfBankAccounts(List<BankAccount> bankAccounts) => SaveListOfBankAccounts(StorageFilePath, bankAccounts);

        #endregion !Public methods.

        #region IBankAccountListStorage methods implementation

        /// <summary>
        /// Gets a list of bank accounts by the path <paramref name="filePath"/>.
        /// </summary>
        /// <param name="filePath">A file path.</param>
        /// <returns>A list of bank accounts.</returns>
        public List<BankAccount> GetListOfBankAccounts(string filePath)
        {
            if (filePath == string.Empty)
            {
                throw new ArgumentException("Incorrect file path.", nameof(filePath));
            }

            if (ReferenceEquals(filePath, null))
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            return ReadBinaryFile(filePath);
        }

        /// <summary>
        /// Saves a list <paramref name="bankAccounts"/> by the path <paramref name="filePath"/>.
        /// </summary>
        /// <param name="filePath">A file path.</param>
        /// <param name="bankAccounts">A list of bank accounts.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="filePath"/> equal to empty string.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="filePath"/> or/and <paramref name="bankAccounts"/> equal to null.
        /// </exception>
        public void SaveListOfBankAccounts(string filePath, List<BankAccount> bankAccounts)
        {
            if (filePath == string.Empty)
            {
                throw new ArgumentException("Incorrect file path.", nameof(filePath));
            }

            if (ReferenceEquals(filePath, null))
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            if (ReferenceEquals(bankAccounts, null))
            {
                throw new ArgumentNullException(nameof(bankAccounts));
            }

            WriteBinaryFile(filePath, bankAccounts);
        }

        #endregion !IBankAccountListStorage methods implementation.

        #region Private methods

        /// <summary>
        /// Reads a list of bank accounts from binary file by the path <paramref name="filePath"/>.
        /// </summary>
        /// <param name="filePath">A binary file path.</param>
        /// <returns>A list of bank accounts.</returns>
        private static List<BankAccount> ReadBinaryFile(string filePath)
        {
            List<BankAccount> resultList = new List<BankAccount>();

            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    BankAccount bankAccount = new BankAccount(reader.ReadInt32(), reader.ReadString(), reader.ReadString(), reader.ReadDecimal());
                    bankAccount.SetBonusFromOperation(reader.ReadInt32());    
                    bankAccount.Type = (Account)reader.ReadInt32();

                    resultList.Add(bankAccount);
                }
            }

            return resultList;
        }

        /// <summary>
        /// Writes a list <paramref name="bankAccounts"/> to the binary file by the path <paramref name="filePath"/>.
        /// </summary>
        /// <param name="filePath">A binary file path.</param>
        /// <param name="bankAccounts">A list of bank accounts.</param>
        private static void WriteBinaryFile(string filePath, List<BankAccount> bankAccounts)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                foreach (BankAccount bankAccount in bankAccounts)
                {
                    writer.Write(bankAccount.ID);
                    writer.Write(bankAccount.UserName);
                    writer.Write(bankAccount.UserSurname);
                    writer.Write(bankAccount.Amount);
                    writer.Write(bankAccount.Bonus);
                    writer.Write((int)bankAccount.Type);
                }
            }
        }

        #endregion !Private methods.
    }
}
