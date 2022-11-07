using HCM.Application.Services.Payrolls;

namespace HCM.Application.Features.Payrolls.Commands;

public class PayrollScheduleDetailPostCommand : PayrollScheduleDetailModel, IRequest<PayrollScheduleDetailModel>
{
}

public class PayrollSchedulePostDetailCommandHandler : IRequestHandler<PayrollScheduleDetailPostCommand, PayrollScheduleDetailModel>
{
    private readonly IPayrollScheduleDetailService _service;

    public PayrollSchedulePostDetailCommandHandler(IPayrollScheduleDetailService service)
    {
        _service = service;
    }

    public async Task<PayrollScheduleDetailModel> Handle(PayrollScheduleDetailPostCommand request, CancellationToken cancellationToken)
    {
        return await _service.PostAsync(request);
    }
}
