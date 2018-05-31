using ASP_NET_MVC_PL.Models;
using BLL.Interface.Exceptions;
using BLL.Interface.Interfaces;

namespace ASP_NET_MVC_PL.Controllers.Command.Implementation
{
    /// <summary>
    /// Provides a command to refill the amount from the bank account.
    /// </summary>
    public class RefillCommand : ICommand
    {
        /// <summary>
        /// Refills the amount from the bank account by using <paramref name="bankAccountService"/>.
        /// </summary>
        /// <param name="operationData">A data of the operation with the bank account.</param>
        /// <param name="bankAccountService">A service to make the refill.</param>
        public void Execute(OperationDataViewModel operationData, IBankAccountService bankAccountService)
        {
            try
            {
                bankAccountService.Refill(operationData.AccountIdTo, operationData.Amount);
            }
            catch(BankServiceException exception)
            {
                throw exception;
            }
        }
    }
}