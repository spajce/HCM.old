using HCM.Application.Services.Payrolls;

namespace HCM.Application.Features.Payrolls.Queries;

public class GetAllPayrollScheduleQuery : IRequest<IEnumerable<PayrollScheduleModel>>
{
}

public class GetAllPayrollScheduleQueryHandler : IRequestHandler<GetAllPayrollScheduleQuery, IEnumerable<PayrollScheduleModel>>
{
    private readonly IPayrollScheduleService _service;

    public GetAllPayrollScheduleQueryHandler(IPayrollScheduleService service)
    {
        _service = service;
    }

    public async Task<IEnumerable<PayrollScheduleModel>> Handle(GetAllPayrollScheduleQuery request, CancellationToken cancellationToken)
    {
        return await _service.GetAsync();
    }
}
