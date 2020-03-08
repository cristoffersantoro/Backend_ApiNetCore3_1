using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend_ApiNetCore3_1.Application.Interfaces;
using Backend_ApiNetCore3_1.Application.ViewModels.Request;
using Backend_ApiNetCore3_1.Application.ViewModels.Response;
using Backend_ApiNetCore3_1.Domain.Interfaces;
using Backend_ApiNetCore3_1.Domain.Models;
using System;
using System.Collections.Generic;

namespace Backend_ApiNetCore3_1.Application.Services
{
    public class AppUserAppService : IAppUserAppService
    {
        private readonly IMapper _mapper;
        private readonly IAppUserRepository _appUserRepository;
        private readonly IUnitOfWork _unitOfWork;
        private bool disposed = false;

        public AppUserAppService(IMapper mapper,
                                      IUnitOfWork unitOfWork,
                                      IAppUserRepository appUserRepository)
        {
            _mapper = mapper;
            _appUserRepository = appUserRepository;
            _unitOfWork = unitOfWork;
        }

        #region AppUser
        public IEnumerable<AppUserViewModelResponse> GetAll()
        {
            return _appUserRepository.GetAll().ProjectTo<AppUserViewModelResponse>(_mapper.ConfigurationProvider);
        }

        public void Insert(AppUserViewModelRequest viewModel)
        {
            var model = _mapper.Map<AppUser>(viewModel);
            _appUserRepository.Add(model);

            _unitOfWork.Commit();
        }

        public AppUserViewModelResponse GetById(int id)
        {
            return _mapper.Map<AppUserViewModelResponse>(_appUserRepository.GetById(id));
        }

        public void Update(AppUserViewModelRequest viewModel, int id)
        {
            viewModel.Id = id;

            var model = _mapper.Map<AppUser>(viewModel);

            _appUserRepository.Update(model);

            _unitOfWork.Commit();
        }

        public void Remove(int id)
        {
            _appUserRepository.Remove(id);
            _unitOfWork.Commit();
        }

        #endregion




        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                // TODO: fazer a liberação do conteúdo gerenciado
            }

            disposed = true;
        }




    }
}
