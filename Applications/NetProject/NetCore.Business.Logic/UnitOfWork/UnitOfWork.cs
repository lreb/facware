using System;
using NetCore.Business.Logic.Repositories;
using NetCore.Contracts.Entity;
using NetCore.Contracts.UnitOfWork;
using NetCore.Data.Access;

namespace NetCore.Business.Logic.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataAccessContext _dataAccessContext;

        // Respoitories
        private IAccountRepository _account;
        private ISystemConfigurationRepository _systemConfiguration;
        // SP

        // Service or engines
        //private IAccountEngine _accountEngine;
        //private IAreaRepository _area;

        public IAccountRepository Account
        {
            get
            {
                if (_account == null)
                {
                    _account = new AccountRepository(this._dataAccessContext);
                }
                return _account;
            }
        }

        public ISystemConfigurationRepository SystemConfiguration 
        {
            get 
            {
                if(_systemConfiguration == null) 
                {
                    _systemConfiguration = new SystemConfigurationRepository(this._dataAccessContext);
                }
                return _systemConfiguration;
            }
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }

        public UnitOfWork(DataAccessContext dataAccessContext)
        {
            this._dataAccessContext = dataAccessContext;
        }
    }
}
