using DappSniper.Net.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;

namespace DappSniper.Net.Service
{
    public interface IRankService
    {
        Task<IPagedList<RankViewModel>> ListAsync(RankSearchModel searchModel);
        Task<bool> CreateAsync(RankCreateModel createModel);
        Task<bool> UpdateAsync(string id, RankUpdateModel updateModel);
        Task<bool> DeleteAsync(string id, RankDeleteModel deleteModel);
        Task<IEnumerable<RankViewModel>> RankAsync(RankSearchModel searchModel);
        Task<RankViewModel> GetAsync(string id);
    }
}
