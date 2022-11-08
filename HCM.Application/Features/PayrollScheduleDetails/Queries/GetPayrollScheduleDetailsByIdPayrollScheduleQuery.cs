using HCM.Application.Services.Payrolls;

namespace HCM.Application.Features.Payrolls.Queries;

public class GetPayrollScheduleDetailsByIdPayrollScheduleQuery : IRequest<IEnumerable<PayrollScheduleDetailModel>>
{
    public int IdPayrollSchedule { get; set; }
}

public class GetPayrollScheduleDetailsByIdPayrollScheduleQueryHandler : IRequestHandler<GetPayrollScheduleDetailsByIdPayrollScheduleQuery, IEnumerable<PayrollScheduleDetailModel>>
{
    private readonly IPayrollScheduleDetailService _service;

    public GetPayrollScheduleDetailsByIdPayrollScheduleQueryHandler(IPayrollScheduleDetailService service)
    {
        _service = service;
    }

    public async Task<IEnumerable<PayrollScheduleDetailModel>> Handle(GetPayrollScheduleDetailsByIdPayrollScheduleQuery request, CancellationToken cancellationToken)
    {
        return await _service.GetAsync(request.IdPayrollSchedule);
    }
}
