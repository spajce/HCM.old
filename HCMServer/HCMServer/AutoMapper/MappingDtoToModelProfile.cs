using HCM.Application.Common.Extensions;
using HCM.Common.Models.Payments;
using HCM.Common.Models.Payrolls;

namespace HCMServer.AutoMapper;

public class MappingDtoToModelProfile : Profile
{
    public MappingDtoToModelProfile()
    {
        //CreateMap<Result, ResultModel>();

        // Employee
        CreateMap<EmployeeModel, EmployeeDto>().ForMember(dest => dest.IdEmployee, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.ToDateOnly()))
            .ForMember(dest => dest.EmploymentDate, opt => opt.MapFrom(src => src.EmploymentDate.ToDateOnly()));

        CreateMap<EmployeeDto, EmployeeModel>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdEmployee))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.ToDateTime()))
            .ForMember(dest => dest.EmploymentDate, opt => opt.MapFrom(src => src.EmploymentDate.ToDateTime()));

        CreateMap<PaginatedDataModel<EmployeeModel>, PaginatedData<EmployeeDto>>().ReverseMap();

        // Employee Job
        CreateMap<EmployeeJobModel, EmployeeJobDto>().ForMember(dest => dest.IdEmployeeJob, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.BasePayType, opt => opt.MapFrom(src => src!.JobBasePayType!.GetDescription()))
            .ForMember(dest => dest.EffectiveDate, opt => opt.MapFrom(src => src.EffectiveDate.ToDateOnly()));

        CreateMap<EmployeeJobDto, EmployeeJobModel>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdEmployeeJob))
            .ForMember(dest => dest.JobBasePayType, opt => opt.MapFrom(src => src!.BasePayType!.ToEnum<JobBasePayType>()))
            .ForMember(dest => dest.EffectiveDate, opt => opt.MapFrom(src => src.EffectiveDate.ToDateTime()));

        // Employee Payment
        CreateMap<EmployeePaymentModel, EmployeePaymentDto>().ForMember(dest => dest.IdEmployeePayment, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.DocDate, opt => opt.MapFrom(src => src.DocDate.ToDateOnly()))
            .ForMember(dest => dest.ReleasedDate, opt => opt.MapFrom(src => src.ReleasedDate.ToDateOnly()))
            .ForMember(dest => dest.EffectiveDate, opt => opt.MapFrom(src => src.EffectiveDate.ToDateOnly()));

        CreateMap<EmployeePaymentDto, EmployeePaymentModel>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdEmployeePayment))
            .ForMember(dest => dest.DocDate, opt => opt.MapFrom(src => src.DocDate.ToDateTime()))
            .ForMember(dest => dest.ReleasedDate, opt => opt.MapFrom(src => src.ReleasedDate.ToDateTime()))
            .ForMember(dest => dest.EffectiveDate, opt => opt.MapFrom(src => src.EffectiveDate.ToDateTime()));

        // Job
        CreateMap<JobCompensationLevelModel, JobCompensationLevelDto>().ForMember(dest => dest.IdJobCompensationLevel, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.BasePayType, opt => opt.MapFrom(src => src!.JobBasePayType!.GetDescription()));

        CreateMap<JobCompensationLevelDto, JobCompensationLevelModel>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdJobCompensationLevel))
         .ForMember(dest => dest.JobBasePayType, opt => opt.MapFrom(src => src!.BasePayType!.ToEnum<JobBasePayType>()));

        CreateMap<JobDepartmentModel, JobDepartmentDto>().ForMember(dest => dest.IdJobDepartment, opt => opt.MapFrom(src => src.Id)).ReverseMap();

        CreateMap<JobPositionModel, JobPositionDto>().ForMember(dest => dest.IdJobPosition, opt => opt.MapFrom(src => src.Id)).ReverseMap();

        CreateMap<JobPositionParentModel, JobPositionParentDto>().ForMember(dest => dest.IdJobPositionParent, opt => opt.MapFrom(src => src.Id)).ReverseMap();

        // Job Payment
        CreateMap<PaymentParticularModel, PaymentParticularDto>().ForMember(dest => dest.IdPaymentParticular, opt => opt.MapFrom(src => src.Id)).ReverseMap();

        // Payroll Schedule
        CreateMap<PayrollScheduleModel, PayrollScheduleDto>().ForMember(dest => dest.IdPayrollSchedule, opt => opt.MapFrom(src => src.Id)).ReverseMap();

        CreateMap<PayrollScheduleDetailModel, PayrollScheduleDetailDto>().ForMember(dest => dest.IdPayrollScheduleDetail, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.DateStart, opt => opt.MapFrom(src => src.DateStart.ToDateOnly()))
            .ForMember(dest => dest.DateEnd, opt => opt.MapFrom(src => src.DateEnd.ToDateOnly()));

        CreateMap<PayrollScheduleDetailDto, PayrollScheduleDetailModel>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdPayrollScheduleDetail))
          .ForMember(dest => dest.DateStart, opt => opt.MapFrom(src => src.DateStart.ToDateTime()))
          .ForMember(dest => dest.DateEnd, opt => opt.MapFrom(src => src.DateStart.ToDateTime()));

    }
}
