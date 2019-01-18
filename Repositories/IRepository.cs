using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DappSniper.Net.Repositories
{
    public interface IRepository<T>
        where T : class
    {
        void Create(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
