using AutoMapper;
using HCM.Application.Common.Extensions;
using HCM.Application.Common.Models;
using HCM.Application.Features.Employees.Queries.Commands;
using HCM.Common.Models;
using HCM.Common.Models.Employees;
using HCM.Domain.DTOs;

namespace HCMServer.AutoMapper;

public class MappingDtoToModelProfile : Profile
{
    public MappingDtoToModelProfile()
    {
        CreateMap<EmployeeModel, EmployeeDto>().ForMember(dest => dest.IdEmployee, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.ToDateOnly()))
            .ForMember(dest => dest.EmploymentDate, opt => opt.MapFrom(src => src.EmploymentDate.ToDateOnly()));

        CreateMap<EmployeeDto, EmployeeModel>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdEmployee))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.ToDateTime()))
            .ForMember(dest => dest.EmploymentDate, opt => opt.MapFrom(src => src.EmploymentDate.ToDateTime()));

        CreateMap<PaginatedDataModel<EmployeeModel>, PaginatedData<EmployeeDto>>().ReverseMap();
    }
}
