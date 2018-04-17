using System;
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

            service.OpenBankAccount("Ivan", "Ivanov", 10, idGenerator);
            service.OpenBankAccount("Petr", "Petrov", 120, idGenerator, AccountType.Gold);
            service.OpenBankAccount("Anna", "Ivanova", 1, idGenerator);

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item);
            }

            service.Refill(1, 30);
            service.Withdrawal(2, 100);

            Console.WriteLine("--------------------------------");

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item);
            }

            service.CloseBankAccount(1);

            Console.WriteLine("--------------------------------");

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
