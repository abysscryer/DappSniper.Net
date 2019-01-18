using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DappSniper.Net.Data;
using DappSniper.Net.Models;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace DappSniper.Net.Repositories
{
    public class DappRepository : Repository<Dapp>, IDappRepository
    {
        public DappRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<Dapp> GetAsync(string id)
        {
            return await _dbContext.Dapps.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IPagedList<Dapp>> ListAsync(string searchString, int pageNumber, int pageSize)
        {

            IQueryable<Dapp> query = _dbContext.Dapps;

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x => x.Name.Contains(searchString) == true);
            }

            query = query.OrderBy(x => x.Name);

            return await query.ToPagedListAsync(pageNumber, pageSize);
        }
    }
}
