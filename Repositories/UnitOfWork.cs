using DappSniper.Net.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DappSniper.Net.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private IDappRepository _dappRepository;
        private IRankRepository _rankRepository;
        private IRecordRepository _recordRepository;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IDappRepository DappRepository
        {
            get
            {
                return _dappRepository = _dappRepository ?? new DappRepository(_dbContext);
            }
        }

        public IRankRepository RankRepository
        {
            get
            {
                return _rankRepository = _rankRepository ?? new RankRepository(_dbContext);
            }
        }

        public IRecordRepository RecordRepository
        {
            get
            {
                return _recordRepository = _recordRepository ?? new RecordRepository(_dbContext);
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
