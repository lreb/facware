using System;
using NetCore.Contracts.Entity;
using NetCore.Contracts.Entity.Dashboards;

namespace NetCore.Contracts.UnitOfWork
{
    public interface IUnitOfWork
    {
        // IAccountRepository Account { get; }
        // IAccountEngine AccountEngine { get; }
        // ISystemConfigurationRepository SystemConfiguration { get; }
        // void BeginTransaction();

        // Dashborads
        IAreasRepository Area { get; }
        IAreasPropertiesRepository AreaProperty { get; }
        ICustomersRepository Customer { get; }
        IShiftsRepository Shift { get; }
        IUsersRepository User { get; }

        int Commit();
    }
}
