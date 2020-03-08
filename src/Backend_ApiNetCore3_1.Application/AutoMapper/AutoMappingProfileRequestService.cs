using AutoMapper;
using Backend_ApiNetCore3_1.Application.ViewModels.Request;
using Backend_ApiNetCore3_1.Domain.Models;

namespace Backend_ApiNetCore3_1.Application.AutoMapper
{
    public class AutoMappingProfileRequestService : Profile
    {
        public AutoMappingProfileRequestService()
        {
            CreateMap<AppUserViewModelRequest, AppUser>();


            CreateMap<PositionViewModelRequest, Position>();


            CreateMap<EmployeeViewModelRequest, Employee>()
                .AfterMap((src, dest) => dest.SalaryValue = dest.Encrypt(src.SalaryValue.ToString())); ;

        }
    }
}
