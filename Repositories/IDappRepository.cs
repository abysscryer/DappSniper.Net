using DappSniper.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace DappSniper.Net.Repositories
{
    public interface IDappRepository : IRepository<Dapp>
    {
        Task<IPagedList<Dapp>> ListAsync(string searchString, int pageNumber, int pageSize);
        Task<Dapp> GetAsync(string id);
    }
}
