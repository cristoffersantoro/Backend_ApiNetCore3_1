using Backend_ApiNetCore3_1.Application.ViewModels.Request;
using Backend_ApiNetCore3_1.Application.ViewModels.Response;
using System;
using System.Collections.Generic;

namespace Backend_ApiNetCore3_1.Application.Interfaces
{
    public interface IEmployeeAppService : IDisposable
    {
        #region Employee
        void Insert(EmployeeViewModelRequest viewModel);
        IEnumerable<EmployeeViewModelResponse> GetAll();
        EmployeeViewModelResponse GetById(int id);
        void Update(EmployeeViewModelRequest viewModel, int id);
        void Remove(int id);
        #endregion

    }
}
