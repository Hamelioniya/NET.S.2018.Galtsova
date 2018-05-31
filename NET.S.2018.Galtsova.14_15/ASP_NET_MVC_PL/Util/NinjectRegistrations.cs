using BLL.Counters;
using BLL.Generators;
using BLL.Interface.Interfaces;
using BLL.Services;
using DAL.EF.Repositories;
using DAL.Interface.Interfaces;
using Ninject.Modules;

namespace ASP_NET_MVC_PL.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IAccountStorage>().To<AccountDBStorage>();
            Bind<IBankAccountService>().To<BankAccountService>();
            Bind<IBonusCounter>().To<BonusCounter>();
            Bind<IIDGenerator>().To<IDGenerator>();
        }
    }
}