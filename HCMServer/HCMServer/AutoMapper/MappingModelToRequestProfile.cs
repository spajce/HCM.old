
namespace HCMServer.AutoMapper;

public class MappingModelToRequestProfile : Profile
{
    public MappingModelToRequestProfile()
    {
        CreateMap<EmployeeModel, EmployeePostCommand>();
        CreateMap<EmployeeModel, EmployeePutCommand>();
        CreateMap<PaginationFilterModel, EmployeePaginationQuery>();

        CreateMap<EmployeePaymentModel, EmployeePaymentPostCommand>();
        CreateMap<EmployeePaymentModel, EmployeePaymentPostCommand>();
        CreateMap<EmployeePaymentModel, GetEmployeePaymentsByIdEmployeeQuery>();

        CreateMap<EmployeeJobModel, EmployeeJobPostCommand>();
        CreateMap<EmployeeJobModel, EmployeeJobPutCommand>();
        CreateMap<EmployeeJobModel, GetEmployeeJobsByIdEmployeeQuery>();

        CreateMap<JobCompensationLevelModel, JobCompensationLevelPostCommand>();
        CreateMap<JobCompensationLevelModel, JobCompensationLevelPutCommand>();
        CreateMap<JobCompensationLevelModel, GetJobCompensationLevelsQuery>();

        CreateMap<JobDepartmentModel, JobDepartmentPostCommand>();
        CreateMap<JobDepartmentModel, JobDepartmentPutCommand>();
        CreateMap<JobDepartmentModel, GetJobDepartmentsQuery>();

        CreateMap<JobPositionParentModel, JobPositionParentPostCommand>();
        CreateMap<JobPositionParentModel, JobPositionParentPutCommand>();
        CreateMap<JobPositionParentModel, GetPositionParentsQuery>();

        CreateMap<JobPositionModel, JobPositionPostCommand>();
        CreateMap<JobPositionModel, JobPositionPutCommand>();
        CreateMap<JobPositionModel, GetJobPositionsQuery>();

        CreateMap<PaymentParticularModel, PaymentParticularPostCommand>();
        CreateMap<PaymentParticularModel, PaymentParticularPutCommand>();
        CreateMap<PaymentParticularModel, GetPaymentParticularsQuery>();

        CreateMap<PayrollScheduleDetailModel, PayrollScheduleDetailDeleteCommand>();
        CreateMap<PayrollScheduleDetailModel, PayrollScheduleDetailPutCommand>();
        CreateMap<PayrollScheduleDetailModel, GetPayrollScheduleDetailsByIdPayrollScheduleQuery>();

        CreateMap<PayrollScheduleModel, PayrollSchedulePostCommand>();
        CreateMap<PayrollScheduleModel, PayrollSchedulePutCommand>();
        CreateMap<PayrollScheduleModel, GetPayrollScheduleDetailsByIdPayrollScheduleQuery>();
    }
}
