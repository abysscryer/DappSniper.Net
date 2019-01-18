using DappSniper.Net.Data;
using DappSniper.Net.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace DappSniper.Net.Repositories
{
    public class RankRepository : Repository<Rank>, IRankRepository
    {
        public RankRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<Rank> GetAsync(string id)
        {
            return await _dbContext.Ranks
                .Include(x => x.Dapp)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IPagedList<Rank>> ListAsync(string recordId, int pageNumber, int pageSize)
        {
            IQueryable<Rank> query = _dbContext.Ranks.Include(x => x.Dapp);

            if (!string.IsNullOrEmpty(recordId))
            {
                query = query.Where(x => x.RecordId == recordId);
            }

            query = query.OrderByDescending(x => x.RecordId).ThenBy(x => x.No);
            
            return await query.ToPagedListAsync(pageNumber, pageSize);
        }

        public async Task<IEnumerable<Rank>> RankAsync(int pageNumber, int pageSize)
        {   
            var recordId = _dbContext.Records.Where(x => x.IsPublish == true).Max(x => x.Id);

            IQueryable<Rank> query = _dbContext.Ranks.Include(x => x.Dapp);

            query = query.OrderByDescending(x => x.RecordId).ThenBy(x => x.No);

            return await query.ToPagedListAsync(pageNumber, pageSize);
        }

    }
}
