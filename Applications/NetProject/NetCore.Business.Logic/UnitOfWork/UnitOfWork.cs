using System;
using NetCore.Business.Logic.Repositories;
using NetCore.Business.Logic.Repositories.Dashboards;
using NetCore.Contracts.Entity;
using NetCore.Contracts.Entity.Dashboards;
using NetCore.Contracts.UnitOfWork;
using NetCore.Data.Access;
using NetCore.Data.Access.DataAccessModels.Dashboards;

namespace NetCore.Business.Logic.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        //private readonly DataAccessContext _dataAccessContext;
        private readonly DashboardsContext _dataAccessContext;

        // Respoitories
        //private IAccountRepository _account;
        //private ISystemConfigurationRepository _systemConfiguration;

        private IAreasRepository _area;
        private IAreasPropertiesRepository _areaProperty;
        private ICustomersRepository _customer;
        private IShiftsRepository _shift;
        private IUsersRepository _user;

        public IAreasRepository Area { get { if (_area == null) { _area = new AreasRepository(this._dataAccessContext); } return _area; } }
        public IAreasPropertiesRepository AreaProperty { get { if (_areaProperty == null) { _areaProperty = new AreasPropertiesRepository(this._dataAccessContext); } return _areaProperty; } }
        public ICustomersRepository Customer { get { if (_customer == null) { _customer = new CustomersRepository(this._dataAccessContext); } return _customer; } }
        public IShiftsRepository Shift { get { if (_shift == null) { _shift = new ShiftsRepository(this._dataAccessContext); } return _shift; } }
        public IUsersRepository User { get { if (_user == null) { _user = new UsersRepository(this._dataAccessContext); } return _user; } }

        // SP

        // Service or engines
        //private IAccountEngine _accountEngine;
        //private IAreaRepository _area;

        //public IAccountRepository Account
        //{
        //    get
        //    {
        //        if (_account == null)
        //        {
        //            _account = new AccountRepository(this._dataAccessContext);
        //        }
        //        return _account;
        //    }
        //}

        //public ISystemConfigurationRepository SystemConfiguration 
        //{
        //    get 
        //    {
        //        if(_systemConfiguration == null) 
        //        {
        //            _systemConfiguration = new SystemConfigurationRepository(this._dataAccessContext);
        //        }
        //        return _systemConfiguration;
        //    }
        //}


        public int Commit()
        {
            throw new NotImplementedException();
        }

        public UnitOfWork(DashboardsContext dataAccessContext)
        {
            this._dataAccessContext = dataAccessContext;
        }
    }
}
