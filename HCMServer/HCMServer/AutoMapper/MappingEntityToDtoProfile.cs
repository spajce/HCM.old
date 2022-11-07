using System.Reflection;
using AutoMapper;
using HCM.Domain.DTOs;
using HCM.Domain.Entities;

namespace HCMServer.AutoMapper;

public class MappingEntityToDtoProfile : Profile
{
    public MappingEntityToDtoProfile()
    {
        CreateMap<Employee, EmployeeDto > ().ReverseMap();
        CreateMap<EmployeePayment, EmployeePaymentDto>().ReverseMap();
        CreateMap<EmployeeJob, EmployeeJobDto>().ReverseMap();
        CreateMap<JobCompensationLevel, JobCompensationLevelDto>().ReverseMap();
        CreateMap<JobDepartment, JobDepartmentDto>().ReverseMap();
        CreateMap<JobPosition, JobPositionDto>().ReverseMap();
        CreateMap<JobPositionParent, JobPositionParentDto>().ReverseMap();
        CreateMap<PaymentParticular, PaymentParticularDto>().ReverseMap();
        CreateMap<PayrollSchedule, PayrollScheduleDto>().ReverseMap();
        CreateMap<PayrollScheduleDetail, PayrollScheduleDetailDto>().ReverseMap();
    }
}
