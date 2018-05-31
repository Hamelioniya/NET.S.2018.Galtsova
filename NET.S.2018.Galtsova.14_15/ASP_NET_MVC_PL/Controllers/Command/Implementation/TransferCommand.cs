using ASP_NET_MVC_PL.Models;
using BLL.Interface.Exceptions;
using BLL.Interface.Interfaces;

namespace ASP_NET_MVC_PL.Controllers.Command.Implementation
{
    /// <summary>
    /// Provides a command to transfer the amount from the one bank account to another.
    /// </summary>
    public class TransferCommand : ICommand
    {
        /// <summary>
        /// Transfers the amount from the one bank account to another by using <paramref name="bankAccountService"/>.
        /// </summary>
        /// <param name="operationData">A data of the operation with the bank accounts.</param>
        /// <param name="bankAccountService">A service to make the transfer.</param>
        public void Execute(OperationDataViewModel operationData, IBankAccountService bankAccountService)
        {
            try
            {
                bankAccountService.Withdrawal(operationData.AccountIdFrom, operationData.Amount);
                bankAccountService.Refill(operationData.AccountIdTo, operationData.Amount);
            }
            catch(BankServiceException exception)
            {
                throw exception;
            }

        }
    }
}