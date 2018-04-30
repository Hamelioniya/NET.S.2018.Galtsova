using System.Configuration;
using System.Data.Entity;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// Represents of the account db context.
    /// </summary>
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class AccountContext : DbContext
    {
        /// <summary>
        /// Initializes an instance of the <see cref="AccountContext"/>.
        /// </summary>
        public AccountContext() : base(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)
        {
        }

        public DbSet<Account> Accounts { get; set; }
    }
}
