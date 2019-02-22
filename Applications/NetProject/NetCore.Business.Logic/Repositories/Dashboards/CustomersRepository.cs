using NetCore.Business.Logic.RepositoryBase;
using NetCore.Contracts.Entity.Dashboards;
using NetCore.Data.Access.DataAccessModels.Dashboards;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Business.Logic.Repositories.Dashboards
{
    public class CustomersRepository : RepositoryBase<Customers>, ICustomersRepository
    {
        public CustomersRepository(DashboardsContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
