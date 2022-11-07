using HCM.Application.Services.Payrolls;

namespace HCM.Application.Features.Payrolls.Commands;

public class PayrollSchedulePostCommand : PayrollScheduleModel, IRequest<PayrollScheduleModel>
{
}

public class PayrollSchedulePostCommandHandler : IRequestHandler<PayrollSchedulePostCommand, PayrollScheduleModel>
{
    private readonly IPayrollScheduleService _service;

    public PayrollSchedulePostCommandHandler(IPayrollScheduleService service)
    {
        _service = service;
    }

    public async Task<PayrollScheduleModel> Handle(PayrollSchedulePostCommand request, CancellationToken cancellationToken)
    {
        return await _service.PostAsync(request);
    }
}
