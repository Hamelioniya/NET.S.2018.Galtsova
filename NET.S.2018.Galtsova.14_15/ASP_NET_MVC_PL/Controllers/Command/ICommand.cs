using ASP_NET_MVC_PL.Models;
using BLL.Interface.Interfaces;

namespace ASP_NET_MVC_PL.Controllers
{
    /// <summary>
    /// Provides an interface of the command.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Executes a command.
        /// </summary>
        /// <param name="operationData">A data for the command.</param>
        /// <param name="bankAccountService">A service for the command.</param>
        void Execute(OperationDataViewModel operationData, IBankAccountService bankAccountService);
    }
}
