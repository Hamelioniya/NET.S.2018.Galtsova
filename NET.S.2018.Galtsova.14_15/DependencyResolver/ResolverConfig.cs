using BLL.Interface.Interfaces;
using BLL.Services;
using BLL.Generators;
using BLL.Counters;
using DAL.Interface.Interfaces;
using Ninject;
using DAL.EF.Repositories;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IAccountStorage>().To<AccountDBStorage>();
            kernel.Bind<IBankAccountService>().To<BankAccountService>();
            kernel.Bind<IBonusCounter>().To<BonusCounter>();
            kernel.Bind<IIDGenerator>().To<IDGenerator>();
        }
    }
}
