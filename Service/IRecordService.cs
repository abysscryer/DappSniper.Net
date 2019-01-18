using DappSniper.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace DappSniper.Net.Service
{
    public interface IRecordService
    {
        Task<IPagedList<RecordViewModel>> ListAsync(int pageNumber, int pageSize);
        Task<bool> CreateAsync(RecordCreateModel createModel);
        Task<bool> UpdateAsync(string id, RecordUpdateModel updateModel);
        Task<bool> DeleteAsync(string id, RecordDeleteModel deleteModel);
        Task<RecordViewModel> GetAsync(string id);
        
    }
}
