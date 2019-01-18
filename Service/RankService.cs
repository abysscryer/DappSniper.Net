using AutoMapper;
using DappSniper.Net.Data;
using DappSniper.Net.Models;
using DappSniper.Net.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace DappSniper.Net.Service
{
    public class RankService : IRankService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<RankService> _logger;

        public RankService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<RankService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> CreateAsync(RankCreateModel createModel)
        {
            int effected = 0;
            try
            {
                var entity = _mapper.Map<Rank>(createModel);
                entity.RecordId = _unitOfWork.RecordRepository.Max();
                //if (!_unitOfWork.RecordRepository.Exists(x =>x.Id == createModel.RecordId))
                //    entity.Record = new Record { Id = createModel.RecordId };

                _unitOfWork.RankRepository.Create(entity);

                effected = await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, createModel);
                throw;
            }

            return effected > 0;
        }

        public async Task<bool> DeleteAsync(string id, RankDeleteModel deleteModel)
        {
            int effected = 0;
            try
            {
                var source = await _unitOfWork.RankRepository.GetAsync(id);

                _unitOfWork.RankRepository.Remove(source);

                effected = await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, deleteModel);
                throw;
            }

            return effected > 0;
        }

        public async Task<IEnumerable<RankViewModel>> RankAsync(RankSearchModel searchModel)
        {
            var data = await _unitOfWork.RankRepository.RankAsync(searchModel.PageNumber, searchModel.PageSize);
            var model = _mapper.Map<IEnumerable<RankViewModel>>(data);

            return model;
        }

        public async Task<IPagedList<RankViewModel>> ListAsync(RankSearchModel searchModel)
        {
            var data = await _unitOfWork.RankRepository.ListAsync(searchModel.RecordId, searchModel.PageNumber, searchModel.PageSize);
            var items = await data.ToListAsync();
            var model = _mapper.Map<IEnumerable<RankViewModel>>(items);
            var view = new StaticPagedList<RankViewModel>(model, data.PageNumber, data.PageSize, data.TotalItemCount);

            return view;
        }

        public async Task<RankViewModel> GetAsync(string id)
        {
            var data = await _unitOfWork.RankRepository.GetAsync(id);
            var model = _mapper.Map<RankViewModel>(data);
            return model;
        }

        public async Task<bool> UpdateAsync(string id, RankUpdateModel updateModel)
        {
            int effected = 0;
            try
            {
                var source = await _unitOfWork.RankRepository.GetAsync(id);
                var entity = _mapper.Map(updateModel, source);

                _unitOfWork.RankRepository.Update(entity);

                effected = await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, updateModel);
                throw;
            }

            return effected > 0;
        }
    }
}
