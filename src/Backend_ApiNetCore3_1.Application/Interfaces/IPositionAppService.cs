using Backend_ApiNetCore3_1.Application.ViewModels.Request;
using Backend_ApiNetCore3_1.Application.ViewModels.Response;
using System;
using System.Collections.Generic;

namespace Backend_ApiNetCore3_1.Application.Interfaces
{
    public interface IPositionAppService : IDisposable
    {
        void Insert(PositionViewModelRequest viewModel);
        IEnumerable<PositionViewModelResponse> GetAll();
        PositionViewModelResponse GetById(int id);
        void Update(PositionViewModelRequest viewModel, int id);
        void Remove(int id);
    }
}
