using DappSniper.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using X.PagedList;

namespace DappSniper.Net.Repositories
{
    public interface IRecordRepository : IRepository<Record>
    {
        bool Exists(Expression<Func<Record, bool>> expression);
        string Max();
        Task<IPagedList<Record>> ListAsync(int pageNumber, int pageSize);
        Task<Record> GetAsync(string id);
    }
}
