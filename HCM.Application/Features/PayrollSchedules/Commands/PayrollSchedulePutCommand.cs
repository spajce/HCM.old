using HCM.Application.Services.Payrolls;

namespace HCM.Application.Features.Payrolls.Commands;

public class PayrollSchedulePutCommand : PayrollScheduleModel, IRequest<PayrollScheduleModel>
{
}

public class PayrollSchedulePutCommandHandler : IRequestHandler<PayrollSchedulePutCommand, PayrollScheduleModel>
{
    private readonly IPayrollScheduleService _service;

    public PayrollSchedulePutCommandHandler(IPayrollScheduleService service)
    {
        _service = service;
    }

    public async Task<PayrollScheduleModel> Handle(PayrollSchedulePutCommand request, CancellationToken cancellationToken)
    {
        return await _service.PutAsync(request.Id, request);
    }
}