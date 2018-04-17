using BLL.Interface.Interfaces;
using BLL.Repositories;
using DAL.Interface.Interfaces;
using DAL.Repositories;
using Ninject;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IAccountStorage>().To<AccountStorage>();
            kernel.Bind<IBankAccountService>().To<BankAccountService>();
            kernel.Bind<IBonusCounter>().To<BonusCounter>();
            kernel.Bind<IIDGenerator>().To<IDGenerator>();
        }
    }
}
