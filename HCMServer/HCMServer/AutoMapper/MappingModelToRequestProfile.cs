using AutoMapper;
using HCM.Application.Common.Extensions;
using HCM.Application.Common.Models;
using HCM.Application.Features.Employees.Commands;
using HCM.Application.Features.Employees.Queries.Pagination;
using HCM.Common.Models;
using HCM.Common.Models.Employees;
using HCM.Domain.DTOs;

namespace HCMServer.AutoMapper;

public class MappingModelToRequestProfile : Profile
{
    public MappingModelToRequestProfile()
    {
        CreateMap<EmployeeModel, EmployeePostCommand>().ReverseMap();
        CreateMap<EmployeeModel, EmployeePutCommand>().ReverseMap();
        CreateMap<PaginationFilterModel, EmployeePaginationQuery>().ReverseMap();
    }
}
