using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Exceptions;

namespace Bank
{
    /// <summary>
    /// Represents a bank account list service.
    /// </summary>
    public class BankAccountListService : IBankAccountListService
    {
        #region Private fields

        private const string StorageFilePath = "bankAccounts.txt";

        private List<BankAccount> _bankAccounts;
        private IBankAccountListStorage _bankAccountListStorage;
        private IBonusCounter _bonusCouter;

        #endregion !Private fields.

        #region Public constructors

        /// <summary>
        /// Initializes an instance of the <see cref="BankAccountListService"/> with passed bank account list storage and bonus counter.
        /// </summary>
        /// <param name="bankAccountStorage">An instance of a bank account service interface.</param>
        /// <param name="bonusCounter">An instance of a bonus counter interface.</param>
        public BankAccountListService(IBankAccountListStorage bankAccountStorage, IBonusCounter bonusCounter)
        {
            if (ReferenceEquals(bankAccountStorage, null))
            {
                throw new ArgumentNullException(nameof(bankAccountStorage));
            }

            _bankAccountListStorage = bankAccountStorage;
            _bonusCouter = bonusCounter;
            BankAccounts = new List<BankAccount>();
        }

        /// <summary>
        /// Initializes an instance of the <see cref="BankAccountListService"/> with passed list of book accounts,
        /// bank account list storage and bonus counter.
        /// </summary>
        /// <param name="bankAccounts">A list of bank accounts.</param>
        /// <param name="bankAccountStorage">An instance of a bank account service interface.</param>
        /// <param name="bonusCounter">An instance of a bonus counter interface.</param>
        public BankAccountListService(List<BankAccount> bankAccounts, IBankAccountListStorage bankAccountStorage, IBonusCounter bonusCounter) : this(bankAccountStorage, bonusCounter)
        {
            BankAccounts = bankAccounts;
        }

        #endregion !Public constructors.

        #region Public properties

        /// <summary>
        /// List of bank accounts
        /// </summary>
        private List<BankAccount> BankAccounts
        {
            get
            {
                return _bankAccounts;
            }

            set
            {
                if (ReferenceEquals(value, null))
                { 
                    throw new ArgumentNullException(nameof(BankAccounts));
                }

                _bankAccounts = value;
            }
        }

        #endregion !Public properties.

        #region IBankAccountListService implementation

        /// <summary>
        /// Adds a <paramref name="bankAccount"/> to the list of bank accounts.
        /// </summary>
        /// <param name="bankAccount">A bank account.</param>
        public void AddBankAccount(BankAccount bankAccount)
        {
            if (ReferenceEquals(bankAccount, null))
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }

            if (BankAccounts.Contains(bankAccount))
            {
                throw new BankAccountAlreadyExistsException("This bank account already exists.");
            }

            if (!ReferenceEquals(BankAccounts.Find(x => x.ID == bankAccount.ID), null))
            {
                throw new BankAccountAlreadyExistsException("Bank account with such ID already exists.");
            }

            BankAccounts.Add(bankAccount);

            _bankAccountListStorage.SaveListOfBankAccounts(StorageFilePath, BankAccounts);
        }

        /// <summary>
        /// Refills a <paramref name="bankAccount"/> by <paramref name="amount"/>.
        /// </summary>
        /// <param name="bankAccount">A bank account.</param>
        /// <param name="amount">An amount.</param>
        public void Refill(BankAccount bankAccount, decimal amount)
        {
            if (ReferenceEquals(bankAccount, null))
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }

            if (!BankAccounts.Contains(bankAccount))
            {
                throw new BankAccountNotFoundException("This bank account not found.");
            }

            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Amount must be greater than 0.", nameof(amount));
            }

            BankAccount account = BankAccounts.Find(x => x == bankAccount);
            AccountFeatures features = new AccountFeatures(account.Type);

            account.RefillAmount(amount + features.RefillPrice);
            account.SetBonusFromOperation(_bonusCouter.GetBonusFromRefill(account, amount));

            _bankAccountListStorage.SaveListOfBankAccounts(StorageFilePath, BankAccounts);
        }

        /// <summary>
        /// Removes a <paramref name="bankAccount"/> from the list of bank accounts.
        /// </summary>
        /// <param name="bankAccount">A bank account.</param>
        public void RemoveBankAccount(BankAccount bankAccount)
        {
            if (ReferenceEquals(bankAccount, null))
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }

            if (!BankAccounts.Contains(bankAccount))
            {
                throw new BankAccountNotFoundException("This bank account not found.");
            }

            BankAccounts.Remove(bankAccount);

            _bankAccountListStorage.SaveListOfBankAccounts(StorageFilePath, BankAccounts);
        }

        /// <summary>
        /// Withdrawals a <paramref name="amount"/> from the <paramref name="bankAccount"/>.
        /// </summary>
        /// <param name="bankAccount">A bank account.</param>
        /// <param name="amount">An amount.</param>
        public void Withdrawal(BankAccount bankAccount, decimal amount)
        {
            if (ReferenceEquals(bankAccount, null))
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }

            if (!BankAccounts.Contains(bankAccount))
            {
                throw new BankAccountNotFoundException("This bank account not found.");
            }

            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Amount must be greater than 0.", nameof(amount));
            }

            BankAccount account = BankAccounts.Find(x => x == bankAccount);
            AccountFeatures features = new AccountFeatures(account.Type);

            account.WithdrawalAmount(amount - features.WithdrawalPrice);
            account.SetBonusFromOperation(_bonusCouter.GetBonuxFromWithdrawal(account, amount));

            _bankAccountListStorage.SaveListOfBankAccounts(StorageFilePath, BankAccounts);
        }
    }

    #endregion !IBankAccountListService implementation.
}
