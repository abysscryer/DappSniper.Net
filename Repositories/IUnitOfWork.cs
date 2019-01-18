using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DappSniper.Net.Repositories
{
    public interface IUnitOfWork
    {
        IDappRepository DappRepository { get; }
        IRankRepository RankRepository { get; }
        IRecordRepository RecordRepository { get; }

        Task<int> SaveAsync();
    }
}
