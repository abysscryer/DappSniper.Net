using DappSniper.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace DappSniper.Net.Repositories
{
    public interface IRankRepository : IRepository<Rank>
    {
        Task<IPagedList<Rank>> ListAsync(string recordId, int pageNuber, int pageSize);
        Task<IEnumerable<Rank>> RankAsync(int pageNuber, int pageSize);
        Task<Rank> GetAsync(string id);
    }
}
