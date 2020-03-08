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
    public class EmployeeAppService : IEmployeeAppService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _employeeRepository;


        public EmployeeAppService(IMapper mapper,
                                  IUnitOfWork unitOfWork,
                                  IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _employeeRepository = employeeRepository;
        }

        #region Employee
        public IEnumerable<EmployeeViewModelResponse> GetAll()
        {

            return _employeeRepository.GetAll().ProjectTo<EmployeeViewModelResponse>(_mapper.ConfigurationProvider);
        }

        public EmployeeViewModelResponse GetById(int id)
        {
            return _mapper.Map<EmployeeViewModelResponse>(_employeeRepository.GetById(id));
        }

        public void Insert(EmployeeViewModelRequest viewModel)
        {
            var model = _mapper.Map<Employee>(viewModel);
            _employeeRepository.Add(model);

            _unitOfWork.Commit();
        }

        public void Update(EmployeeViewModelRequest viewModel, int id)
        {
            viewModel.Id = id;
            var model = _mapper.Map<Employee>(viewModel);
            _employeeRepository.Update(model);

            _unitOfWork.Commit();

        }

        public void Remove(int id)
        {
            _employeeRepository.Remove(id);
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
            GC.SuppressFinalize(this);
        }


    }
}
