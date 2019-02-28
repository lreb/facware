using Microsoft.EntityFrameworkCore.Storage;
using NetCore.Contracts.Entity.Dashboards;
using NetCore.Contracts.Entity.Dashboards.Services;
using NetCore.Data.Access.DataAccessModels.Dashboards;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Business.Logic.Services.Dashboards
{
    internal class AreasPropertiesService : IAreasPropertiesService
    {
        DashboardsContext _repositoryContext;
        private IAreasRepository _areas;
        private IAreasPropertiesRepository _properties;

        public AreasPropertiesService(DashboardsContext repositoryContext, IAreasRepository areas, IAreasPropertiesRepository properties)
        {
            _repositoryContext = repositoryContext;
            _areas = areas;
            _properties = properties;
        }

        public Areas Create(Areas area)
        {
            using (var transaction = _repositoryContext.Database.BeginTransaction())
            {
                //bool autoCommit = false;
                //IDbContextTransaction txn = null;
                //if (_repositoryContext.Database.CurrentTransaction == null)
                //{
                //    txn = _repositoryContext.Database.BeginTransaction();
                //    autoCommit = true;
                //}
                //else
                //{
                //    txn = _repositoryContext.Database.CurrentTransaction;
                //}
                try
                {
                    _repositoryContext.Add(area);
                    //_areas.Create(area);
                    //_areas.Save();
                    _repositoryContext.SaveChanges();
                    // List<AreasProperties> ap = new List<AreasProperties>().AddRange(area.AreasProperties)
                    //foreach (var property in area.AreasProperties)
                    //{
                    //    _repositoryContext.AreasProperties.Add(new AreasProperties { AreaId = area.Id, Group = property.Group, Parameter = property.Parameter, Value = property.Value });
                    //    //_properties.Create(new AreasProperties { AreaId = area.Id, Group = property.Group, Parameter = property.Parameter, Value = property.Value });
                        
                    //}
                    //_repositoryContext.SaveChanges();
                    _repositoryContext.Database.CommitTransaction();
                    return area;
                }
                catch (Exception e)
                {
                    _repositoryContext.Database.RollbackTransaction();
                    return null;
                }
            }
        }
    }
}
