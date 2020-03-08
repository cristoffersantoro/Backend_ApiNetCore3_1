using AutoMapper;
using Backend_ApiNetCore3_1.Application.ViewModels.Response;
using Backend_ApiNetCore3_1.Domain.Models;
using System;

namespace Backend_ApiNetCore3_1.Application.AutoMapper
{
    public class AutoMappingProfileResponseService : Profile
    {
        public AutoMappingProfileResponseService()
        {


            CreateMap<AppUser, AppUserViewModelResponse>();

            CreateMap<Employee, EmployeeViewModelResponse>()
                .BeforeMap((src, dest) => src.SalaryValue = src.Decrypt(src.SalaryValue))
                .ForMember(dest => dest.SalaryValue, opts => opts.MapFrom(src => Convert.ToDecimal(src.SalaryValue)));

            CreateMap<Position, PositionViewModelResponse>();

        }
    }
}
