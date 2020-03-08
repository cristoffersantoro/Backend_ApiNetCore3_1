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
    public class PositionAppService : IPositionAppService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPositionRepository _positionRepository;
        private bool disposed = false;

        public PositionAppService(IMapper mapper,
                                  IUnitOfWork unitOfWork,
                                  IPositionRepository positionRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _positionRepository = positionRepository;
        }

        #region Position
        public IEnumerable<PositionViewModelResponse> GetAll()
        {
            return _positionRepository.GetAll().ProjectTo<PositionViewModelResponse>(_mapper.ConfigurationProvider);
        }
        public PositionViewModelResponse GetById(int id)
        {
            return _mapper.Map<PositionViewModelResponse>(_positionRepository.GetById(id));
        }

        public void Insert(PositionViewModelRequest viewModel)
        {
            var model = _mapper.Map<Position>(viewModel);
            _positionRepository.Add(model);

            _unitOfWork.Commit();
        }

        public void Update(PositionViewModelRequest viewModel, int id)
        {
            viewModel.Id = id;
            var model = _mapper.Map<Position>(viewModel);
            _positionRepository.Update(model);

            _unitOfWork.Commit();
        }

        public void Remove(int id)
        {
            _positionRepository.Remove(id);
            _unitOfWork.Commit();
        }

        #endregion


        /**********************************************************************************************************
        * ATENÇÃO: O template implementa a interface IDisposable porém não implementava
        * completamente os métodos necessários. Abaixo um protótipo da implentação completa
        * mas é preciso avaliar o que utilizar neles e se irá utilizá-los realmente.
        * Estas referências podem ajudar:
        * - https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose?view=netframework-4.8
        * - https://docs.microsoft.com/pt-br/dotnet/api/system.gc.suppressfinalize?view=netframework-4.8
        * - https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/classes-and-structs/destructors
        * 
        **********************************************************************************************************/

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
