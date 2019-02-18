using System;
using NetCore.Contracts.Repository;
using NetCore.Data.Access.Models;

namespace NetCore.Contracts.Entity
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
    }
}
