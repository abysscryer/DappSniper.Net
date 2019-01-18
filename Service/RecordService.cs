using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DappSniper.Net.Models;
using DappSniper.Net.Repositories;
using Microsoft.Extensions.Logging;
using X.PagedList;

namespace DappSniper.Net.Service
{
    public class RecordService : IRecordService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<RecordService> _logger;

        public RecordService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<RecordService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> CreateAsync(RecordCreateModel createModel)
        {
            int effected = 0;
            try
            {
                var entity = _mapper.Map<Record>(createModel);

                _unitOfWork.RecordRepository.Create(entity);

                effected = await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, createModel);
                throw;
            }

            return effected > 0;
        }

        public async Task<IPagedList<RecordViewModel>> ListAsync(int pageNumber, int pageSize)
        {
            var data = await _unitOfWork.RecordRepository.ListAsync(pageNumber, pageSize);
            var items = await data.ToListAsync();
            var model = _mapper.Map<IEnumerable<RecordViewModel>>(items);
            var view = new StaticPagedList<RecordViewModel>(model, data.PageNumber, data.PageSize, data.TotalItemCount);

            return view;
        }

        public async Task<bool> UpdateAsync(string id, RecordUpdateModel updateModel)
        {
            int effected = 0;
            try
            {
                var source = await _unitOfWork.RecordRepository.GetAsync(id);
                var entity = _mapper.Map(updateModel, source);

                _unitOfWork.RecordRepository.Update(entity);

                effected = await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, updateModel);
                throw;
            }

            return effected > 0;
        }

        public async Task<RecordViewModel> GetAsync(string id)
        {
            var data = await _unitOfWork.RecordRepository.GetAsync(id);
            var model = _mapper.Map<RecordViewModel>(data);

            return model;
        }

        public async Task<bool> DeleteAsync(string id, RecordDeleteModel deleteModel)
        {
            int effected = 0;
            try
            {
                var source = await _unitOfWork.RecordRepository.GetAsync(id);

                _unitOfWork.RecordRepository.Remove(source);

                effected = await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, deleteModel);
                throw;
            }

            return effected > 0;
        }
    }
}
