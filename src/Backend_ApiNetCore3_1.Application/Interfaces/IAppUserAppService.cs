using Backend_ApiNetCore3_1.Application.ViewModels.Request;
using Backend_ApiNetCore3_1.Application.ViewModels.Response;
using System;
using System.Collections.Generic;

namespace Backend_ApiNetCore3_1.Application.Interfaces
{
    public interface IAppUserAppService : IDisposable
    {
        void Insert(AppUserViewModelRequest viewModel);
        IEnumerable<AppUserViewModelResponse> GetAll();
        AppUserViewModelResponse GetById(int id);
        void Update(AppUserViewModelRequest viewModel, int id);
        void Remove(int id);
    }
}
