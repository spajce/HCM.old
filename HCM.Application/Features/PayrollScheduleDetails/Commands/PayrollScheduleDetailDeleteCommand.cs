using HCM.Application.Services.Payrolls;

namespace HCM.Application.Features.Payrolls.Commands;

public class PayrollScheduleDetailDeleteCommand : IRequest<bool>
{
    public int[] Ids { get; set; }
}

public class PPayrollScheduleDetailDeleteCommandHandler : IRequestHandler<PayrollScheduleDeleteCommand, bool>
{
    private readonly IPayrollScheduleDetailService _service;

    public PPayrollScheduleDetailDeleteCommandHandler(IPayrollScheduleDetailService service)
    {
        _service = service;
    }

    public async Task<bool> Handle(PayrollScheduleDeleteCommand request, CancellationToken cancellationToken)
    {
        await _service.DeleteAsync(request.Ids);
        return true;
    }
}