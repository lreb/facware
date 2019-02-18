using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NetCore.Contracts.Repository;
using NetCore.Data.Access;

namespace NetCore.Business.Logic.RepositoryBase
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class // IEntity
    {
        protected DataAccessContext RepositoryContext { get; set; }

        public RepositoryBase(DataAccessContext repositoryContext)
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
        }

        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
            this.RepositoryContext.Database.BeginTransaction();
            this.RepositoryContext.Database.RollbackTransaction();
            this.RepositoryContext.Database.CommitTransaction();
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
    }
}
