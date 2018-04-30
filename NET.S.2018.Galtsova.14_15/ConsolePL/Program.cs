using System;
using System.Collections.Generic;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DependencyResolver;
using Ninject;

namespace ConsolePL
{
    public class Program
    {
        private static readonly IKernel Resolver;

        static Program()
        {
            Resolver = new StandardKernel();
            Resolver.ConfigurateResolver();
        }

        public static void Main(string[] args)
        {
            IBankAccountService service = Resolver.Get<IBankAccountService>();
            IIDGenerator idGenerator = Resolver.Get<IIDGenerator>();

            service.OpenBankAccount("Ivan", "Ivanov", 12, idGenerator);
            service.OpenBankAccount("Petr", "Petrov", 120, idGenerator, AccountType.Gold);
            service.OpenBankAccount("Anna", "Ivanova", 1, idGenerator);

            List<BankAccount> accounts = (List<BankAccount>)service.GetAllAccounts();

            foreach (var item in accounts)
            {
                Console.WriteLine(item);
            }

            service.Refill(accounts.Find(account => account.UserName == "Ivan" && account.UserSurname == "Ivanov").ID, 1);
            service.Withdrawal(accounts.Find(account => account.UserName == "Petr" && account.UserSurname == "Petrov").ID, 100);

            Console.WriteLine("--------------------------------");

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item);
            }

            service.CloseBankAccount(accounts.Find(account => account.UserName == "Ivan" && account.UserSurname == "Ivanov").ID);

            Console.WriteLine("--------------------------------");

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item);
            }

            service.CloseBankAccount(accounts.Find(account => account.UserName == "Petr" && account.UserSurname == "Petrov").ID);
            service.CloseBankAccount(accounts.Find(account => account.UserName == "Anna" && account.UserSurname == "Ivanova").ID);

            Console.ReadKey();
        }
    }
}
