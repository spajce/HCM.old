using HCM.Application.Services.Payrolls;

namespace HCM.Application.Features.Payrolls.Commands;

public class PayrollScheduleDetailPutCommand : PayrollScheduleDetailModel, IRequest<PayrollScheduleDetailModel>
{
}

public class PayrollScheduleDetailPutCommandHandler : IRequestHandler<PayrollScheduleDetailPutCommand, PayrollScheduleDetailModel>
{
    private readonly IPayrollScheduleDetailService _service;

    public PayrollScheduleDetailPutCommandHandler(IPayrollScheduleDetailService service)
    {
        _service = service;
    }

    public async Task<PayrollScheduleDetailModel> Handle(PayrollScheduleDetailPutCommand request, CancellationToken cancellationToken)
    {
        return await _service.PutAsync(request.Id, request);
    }
}