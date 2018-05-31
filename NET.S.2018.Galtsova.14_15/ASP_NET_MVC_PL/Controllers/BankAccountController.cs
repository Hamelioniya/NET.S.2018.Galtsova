using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ASP_NET_MVC_PL.Models;
using BLL.Interface.Exceptions;
using BLL.Interface.Interfaces;

namespace ASP_NET_MVC_PL.Controllers
{
    /// <summary>
    /// Represents a bank account controller.
    /// </summary>
    public class BankAccountController : Controller
    {
        IBankAccountService _bankAccountService;
        IIDGenerator _idGenerator;

        public BankAccountController(IBankAccountService bankAccountService, IIDGenerator idGenerator)
        {
            _bankAccountService = bankAccountService;
            _idGenerator = idGenerator;
        }

        /// <summary>
        /// Gets a view of the list of bank accounts.
        /// </summary>
        /// <returns>A view of the list of bank accounts.</returns>
        public ActionResult Index()
        {
            IEnumerable<BankAccountViewModel> bankAccounts = _bankAccountService.GetAllAccounts()
                .Select(account => new BankAccountViewModel()
                {
                    Id = account.ID,
                    UserName = account.UserName,
                    UserSurname = account.UserSurname,
                    Amount = account.Amount,
                    Bonus = account.Bonus,
                    Type = account.Type.ToString()
                })
                .ToList();

            return View(bankAccounts);
        }

        /// <summary>
        /// Gets a view to make operation with the bank account.
        /// </summary>
        /// <returns>A view of the making operation with the bank account.</returns>
        public ActionResult Operation()
        {
            return View();
        }

        /// <summary>
        /// Makes an operation with the bank account.
        /// </summary>
        /// <param name="operationData">A data to make the operation with the bank account.</param>
        /// <returns>A view of the list of bank account or error page.</returns>
        [HttpPost]
        public ActionResult Operation(OperationDataViewModel operationData)
        {
            try
            {
                CommandProvider commandProvider = new CommandProvider();

                commandProvider.GetCommand(operationData.Operation).Execute(operationData, _bankAccountService);

                return RedirectToAction("Index");
            }
            catch(BankServiceException exception)
            {
                ViewBag.ErrorMessage = exception.Message;
                return View("Error");
            }
            
        }

        /// <summary>
        /// Gets a view to create a new bank account.
        /// </summary>
        /// <returns>A view of the bank account creation.</returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates a new bank account.
        /// </summary>
        /// <param name="bankAccount">The bank account to create.</param>
        /// <returns>A view of the list of bank accounts.</returns>
        [HttpPost]
        public ActionResult Create(BankAccountViewModel bankAccount)
        {
            try
            {
                _bankAccountService.OpenBankAccount(bankAccount.UserName, bankAccount.UserSurname, bankAccount.Amount, _idGenerator, (AccountType)Enum.Parse(typeof(AccountType), bankAccount.Type));

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        /// <summary>
        /// Deletes a bank account.
        /// </summary>
        /// <param name="id">An id of the bank account to delete.</param>
        /// <returns>A view of the list of bank accounts.</returns>
        public ActionResult Delete(int id)
        {
            _bankAccountService.CloseBankAccount(id);
            return RedirectToAction("Index");
        }
    }
}
