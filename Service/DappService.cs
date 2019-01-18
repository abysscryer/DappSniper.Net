using AutoMapper;
using DappSniper.Net.Models;
using DappSniper.Net.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace DappSniper.Net.Service
{
    public class DappService : IDappService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DappService> _logger;

        public DappService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DappService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> CreateAsync(DappCreateModel createModel)
        {
            int effected = 0;
            try
            {
                var entity = _mapper.Map<Dapp>(createModel);
                entity.Contracts.Add(new Contract { Address = createModel.Address });
                _unitOfWork.DappRepository.Create(entity);
                effected = await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, createModel);
                throw;
            }

            return effected > 0;
        }

        public async Task<bool> DeleteAsync(string id, DappDeleteModel deleteModel)
        {
            int effected = 0;
            try
            {
                var source = await _unitOfWork.DappRepository.GetAsync(id);

                _unitOfWork.DappRepository.Remove(source);

                effected = await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, deleteModel);
                throw;
            }

            return effected > 0;
        }

        public async Task<DappViewModel> GetAsync(string id)
        {
            var data = await _unitOfWork.DappRepository.GetAsync(id);
            var model = _mapper.Map<DappViewModel>(data);
            return model;
        }

        public async Task<IPagedList<DappViewModel>> ListAsync(DappSearchModel searchModel)
        {
            var data = await _unitOfWork.DappRepository.ListAsync(searchModel.SearchString, searchModel.PageNumber, searchModel.PageSize);
            var items = await data.ToListAsync();
            var model = _mapper.Map<IEnumerable<DappViewModel>>(items);
            var view = new StaticPagedList<DappViewModel>(model, data.PageNumber, data.PageSize, data.TotalItemCount);

            return view;
        }

        public async Task<bool> UpdateAsync(string id, DappUpdateModel updateModel)
        {
            int effected = 0;
            try
            {
                var source = await _unitOfWork.DappRepository.GetAsync(id);
                var entity = _mapper.Map(updateModel, source);

                _unitOfWork.DappRepository.Update(entity);

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