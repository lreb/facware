using System;
using NetCore.Business.Logic.RepositoryBase;
using NetCore.Contracts.Entity;
using NetCore.Data.Access;
using NetCore.Data.Access.Models;

namespace NetCore.Business.Logic.Repositories
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(DataAccessContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
