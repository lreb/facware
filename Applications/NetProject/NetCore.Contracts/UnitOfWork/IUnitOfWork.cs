using System;
using NetCore.Contracts.Entity;

namespace NetCore.Contracts.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAccountRepository Account { get; }
        // IAccountEngine AccountEngine { get; }
        ISystemConfigurationRepository SystemConfiguration { get; }
        // void BeginTransaction();
        int Commit();
    }
}
