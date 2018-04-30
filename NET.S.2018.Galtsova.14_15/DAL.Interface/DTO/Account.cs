using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// Represents an account.
    /// </summary>
    [Table("account")]
    public class Account
    {
        /// <summary>
        /// An account id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// An account user name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// An account user surname.
        /// </summary>
        public string UserSurname { get; set; }

        /// <summary>
        /// An total amount on the account.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// A bonus on the account.
        /// </summary>
        public int Bonus { get; set; }

        /// <summary>
        /// An account type.
        /// </summary>
        public int Type { get; set; }
    }
}
