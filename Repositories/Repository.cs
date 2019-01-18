using DappSniper.Net.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DappSniper.Net.Repositories
{
    public class Repository<T> : IRepository<T>
         where T : class
    {
        protected readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual void Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public virtual void Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public virtual void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        //public virtual bool Exists(Expression<Func<T, bool>> predicate)
        //{
        //    return _dbContext.Set<T>().Any(x => predicate);
        //}
    }
}
