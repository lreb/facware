using NetCore.Business.Logic.RepositoryBase;
using NetCore.Contracts.Entity.Dashboards;
using NetCore.Data.Access.DataAccessModels.Dashboards;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Business.Logic.Repositories.Dashboards
{
    public class AreasRepository : RepositoryBase<Areas>, IAreasRepository
    {
        public AreasRepository(DashboardsContext repositoryContext)
            : base(repositoryContext)   
        {
        }

        public void CompareAndUpdate(Areas dbArea, Areas area)
        {
            dbArea.CustomerId = (dbArea.CustomerId == area.CustomerId) ? dbArea.CustomerId : area.CustomerId;
            dbArea.Name = (dbArea.Name == area.Name) ? dbArea.Name : area.Name;
            dbArea.Type = (dbArea.Type == area.Type) ? dbArea.Type : area.Type;
            dbArea.Description = (dbArea.Description == area.Description) ? dbArea.Description : area.Description;
            dbArea.UpdateDate = DateTime.Now;
            Update(dbArea);
            Save();
        }

        public void LogicalDelete(Areas dbArea)
        {
            dbArea.Enabled = false;
            dbArea.UpdateDate = DateTime.Now;
            Update(dbArea);
            Save();
        }
    }
}
