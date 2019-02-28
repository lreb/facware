using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NetCore.Contracts.Repository;
using NetCore.Data.Access;
using NetCore.Data.Access.DataAccessModels.Dashboards;

namespace NetCore.Business.Logic.RepositoryBase
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class // IEntity
    {
        //protected DataAccessContext RepositoryContext { get; set; }

        //public RepositoryBase(DataAccessContext repositoryContext)
        //{
        //    this.RepositoryContext = repositoryContext;
        //}

        protected DashboardsContext RepositoryContext { get; set; }

        protected Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction _transaction { get; set; }

        public RepositoryBase(DashboardsContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public IEnumerable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression);
        }

        public void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
            // return entity;
        }

        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
            //this.RepositoryContext.Database.BeginTransaction();
            //this.RepositoryContext.Database.RollbackTransaction();
            //this.RepositoryContext.Database.CommitTransaction();
        }

        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }

        public void Save()
        {
            this.RepositoryContext.SaveChanges();
        }

        public T GetById(long id)
        {
            return this.RepositoryContext.Set<T>().Find(id);
        }

        public void CreateTransaction()
        {
            _transaction = this.RepositoryContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }
    }
}
