using NetCore.Contracts.Repository;
using NetCore.Data.Access.DataAccessModels.Dashboards;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Contracts.Entity.Dashboards
{
    public interface IAreasRepository : IRepositoryBase<Areas>
    {
        void CompareAndUpdate(Areas dbArea, Areas area);
        void LogicalDelete(Areas dbArea);
    }
}
