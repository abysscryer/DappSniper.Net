using DappSniper.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace DappSniper.Net.Service
{
    public interface IDappService
    {
        Task<IPagedList<DappViewModel>> ListAsync(DappSearchModel searchModel);
        Task<bool> CreateAsync(DappCreateModel createModel);
        Task<bool> UpdateAsync(string id, DappUpdateModel updateModel);
        Task<bool> DeleteAsync(string id, DappDeleteModel deleteModel);
        Task<DappViewModel> GetAsync(string id);
    }
}
