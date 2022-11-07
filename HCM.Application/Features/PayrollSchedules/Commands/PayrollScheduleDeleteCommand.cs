using HCM.Application.Services.Payrolls;

namespace HCM.Application.Features.Payrolls.Commands;

public class PayrollScheduleDeleteCommand : IRequest<bool>
{
    public int[] Ids { get; set; }
}

public class PPayrollScheduleDeleteCommandHandler : IRequestHandler<PayrollScheduleDeleteCommand, bool>
{
    private readonly IPayrollScheduleService _service;

    public PPayrollScheduleDeleteCommandHandler(IPayrollScheduleService service)
    {
        _service = service;
    }

    public async Task<bool> Handle(PayrollScheduleDeleteCommand request, CancellationToken cancellationToken)
    {
        await _service.DeleteAsync(request.Ids);
        return true;
    }
}