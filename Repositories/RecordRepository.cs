using DappSniper.Net.Data;
using DappSniper.Net.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using X.PagedList;

namespace DappSniper.Net.Repositories
{
    public class RecordRepository : Repository<Record>, IRecordRepository
    {
        public RecordRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public bool Exists(Expression<Func<Record, bool>> predicate)
        {
            return _dbContext.Records.Any(predicate);
        }

        public string Max()
        {
            return _dbContext.Records.Max(x => x.Id);
        }

        public async Task<Record> GetAsync(string id)
        {
            return await _dbContext.Records.Where(x => x.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<IPagedList<Record>> ListAsync(int pageNumber, int pageSize)
        {
            IQueryable<Record> query = _dbContext.Records;

            query = query.OrderByDescending(x => x.Id);

            return await query.ToPagedListAsync(pageNumber, pageSize);
        }
    }
}
