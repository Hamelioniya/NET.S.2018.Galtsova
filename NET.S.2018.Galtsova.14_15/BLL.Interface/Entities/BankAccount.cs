using System;
using System.Globalization;
using BLL.Interface.Exceptions;
using BLL.Interface.Interfaces;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Represents a bank account.
    /// </summary>
    public class BankAccount
    {
        #region Private fields

        private int _id;
        private string _userName;
        private string _userSurname;
        private decimal _amount;

        #endregion !Private fields.

        #region Public constructors

        /// <summary>
        /// Initializes an instance of the <see cref="BankAccount"/> with the passed bank account id.
        /// </summary>
        /// <param name="id">The bank account id.</param>
        public BankAccount(int id)
        {
            ID = id;
            Type = 0;
            UserName = string.Empty;
            UserSurname = string.Empty;
        }

        /// <summary>
        /// Initializes an instance of the <see cref="BankAccount"/> with passed bank account id, user name and user surname.
        /// </summary>
        /// <param name="id">The bank account id.</param>
        /// <param name="userName">The user name.</param>
        /// <param name="userSurname">The user surname.</param>
        public BankAccount(int id, string userName, string userSurname) : this(id)
        {
            UserName = userName;
            UserSurname = userSurname;
        }

        /// <summary>
        /// Initializes an instance of the <see cref="BankAccount"/> with passed bank account id, user name, user surname and amount.
        /// </summary>
        /// <param name="id">The bank account id.</param>
        /// <param name="userName">The user name.</param>
        /// <param name="userSurname">The user surname.</param>
        /// <param name="amount">The amount on the bank account.</param>
        public BankAccount(int id, string userName, string userSurname, decimal amount) : this(id, userName, userSurname)
        {
            Amount = amount;
        }

        /// <summary>
        /// Initializes an instance of the <see cref="BankAccount"/> with passed bank account type, user name, user surname and amount.
        /// </summary>
        /// <param name="id">The bank account id.</param>
        /// <param name="userName">The user name.</param>
        /// <param name="userSurname">The user surname.</param>
        /// <param name="amount">The amount on the bank account.</param>
        /// <param name="type">The amount on the bank account.</param>
        public BankAccount(int id, string userName, string userSurname, decimal amount, AccountType type) 
            : this(id, userName, userSurname, amount)
        {
            Type = type;
        }

        #endregion !Public constructors.

        #region Public properties

        /// <summary>
        /// An id of bank account.
        /// </summary>
        public int ID
        {
            get
            {
                return _id;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The id must be greater than or equal to 0.", nameof(ID));
                }

                _id = value;
            }
        }

        /// <summary>
        /// An user of the bank account name.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown when value equal to null.
        /// </exception>
        public string UserName
        {
            get
            {
                return _userName;
            }

            private set
            {
                if (ReferenceEquals(value, null))
                {
                    throw new ArgumentNullException(nameof(UserName));
                }

                _userName = value;
            }
        }

        /// <summary>
        /// An user of the bank account surname.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown when value equal to null.
        /// </exception>
        public string UserSurname
        {
            get
            {
                return _userSurname;
            }

            private set
            {
                if (ReferenceEquals(value, null))
                {
                    throw new ArgumentNullException(nameof(UserSurname));
                }

                _userSurname = value;
            }
        }

        /// <summary>
        /// A total amount on the bank account.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown when value less than 0.
        /// </exception>
        public decimal Amount
        {
            get
            {
                return _amount;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Amount must be greater than or equal to 0.", nameof(Amount));
                }

                _amount = value;
            }
        }

        /// <summary>
        /// A bonus on the bank account.
        /// </summary>
        public int Bonus { get; private set; }

        /// <summary>
        /// A type of the bank account.
        /// </summary>
        public AccountType Type { get; set; }

        #endregion !Public properties.

        #region Equals public methods

        /// <summary>
        /// Checks an equality of the <paramref name="firstBankAccount"/> and the <paramref name="secondBankAccount"/>.
        /// </summary>
        /// <param name="firstBankAccount">The first bank account.</param>
        /// <param name="secondBankAccount">The second bank account.</param>
        /// <returns>true if bank accounts are equal.</returns>
        public static bool operator ==(BankAccount firstBankAccount, BankAccount secondBankAccount)
        {
            return firstBankAccount.Equals(secondBankAccount);
        }

        /// <summary>
        /// Checks an inequality of the <paramref name="firstBankAccount"/> and the <paramref name="secondBankAccount"/>.
        /// </summary>
        /// <param name="firstBankAccount">The first bank account.</param>
        /// <param name="secondBankAccount">The second bank account.</param>
        /// <returns>true if bank accounts are not equal.</returns>
        public static bool operator !=(BankAccount firstBankAccount, BankAccount secondBankAccount)
        {
            return !firstBankAccount.Equals(secondBankAccount);
        }

        /// <summary>
        /// Checks an equality of the current bank account and the <paramref name="other"/> bank account.
        /// </summary>
        /// <param name="other">The other bank account.</param>
        /// <returns>true if bank accounts are equal.</returns>
        public bool Equals(BankAccount other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            return (this.ID == other.ID) &&
                   (this.UserName == other.UserName) &&
                   (this.UserSurname == other.UserSurname) &&
                   (this.Amount == other.Amount) &&
                   (this.Type == other.Type) &&
                   (this.Bonus == other.Bonus);
        }

        /// <summary>
        /// Checks an equality of the current bank account and the <paramref name="other"/> bank account.
        /// </summary>
        /// <param name="other">The other bank account.</param>
        /// <returns>true if bank accounts are equal.</returns>
        public override bool Equals(object other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (this.GetType() != other.GetType())
            {
                return false;
            }

            return this.Equals((BankAccount)other);
        }

        #endregion !Equals public methods.

        #region Public methods

        /// <summary>
        /// Refills a current bank account by the <paramref name="amount"/>.
        /// </summary>
        /// <param name="amount">The amount to refill.</param>
        /// <exception cref="InsufficientFundsException">
        /// Thrown when insufficient founds to refill by the <paramref name="amount"/> in the bank account.
        /// </exception>
        public void RefillAmount(decimal amount)
        {
            if (Amount + amount < 0)
            {
                throw new InsufficientFundsException("Insufficient funds.");
            }

            Amount = Amount + amount;
        }

        /// <summary>
        /// Withdrawals a <paramref name="amount"/> from the current bank account.
        /// </summary>
        /// <param name="amount">The amount to withdrawal.</param>
        /// <exception cref="InsufficientFundsException">
        /// Thrown when insufficient founds to withdrawal the <paramref name="amount"/> in the bank account.
        /// </exception>
        public void WithdrawalAmount(decimal amount)
        {
            if (Amount < amount)
            {
                throw new InsufficientFundsException("Insufficient funds.");
            }

            Amount = Amount - amount;
        }

        /// <summary>
        /// Sets a bonus after some operation.
        /// </summary>
        /// <param name="bonus">The bonus to set.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the <paramref name="bonus"/> less than 0.
        /// </exception>
        public void SetBonusFromOperation(int bonus)
        {
            if (bonus < 0)
            {
                throw new ArgumentOutOfRangeException("Bonus must be greater than or equal to 0.", nameof(bonus));
            }

            Bonus = Bonus + bonus;
        }

        #endregion !Public methods.

        #region GetHashCode public method

        /// <summary>
        /// Gets a hash code for the <see cref="BankAccount"/> object.
        /// </summary>
        /// <returns>The hash code for the <see cref="BankAccount"/> object.</returns>
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        #endregion !GetHashCode public method.

        #region ToString public method

        /// <summary>
        /// Gets a string representation of the <see cref="Book"/> object.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown when a current <see cref="Book"/> object equal to null.
        /// </exception>
        /// <returns>The string representation of the <see cref="Book"/> object.</returns>
        public override string ToString()
        {
            if (ReferenceEquals(this, null))
            {
                throw new ArgumentNullException();
            }

            return "ID: " + ID.ToString() + "\nUser name: " + UserName + "\nUser surname: " + UserSurname + "\nAmount: " + Amount.ToString("C", CultureInfo.CurrentCulture) +
                "\nBonus: " + Bonus.ToString() + "\nType: " + Type.ToString();
        }

        #endregion !ToString public method.
    }
}
