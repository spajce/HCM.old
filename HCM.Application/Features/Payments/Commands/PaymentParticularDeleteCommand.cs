using HCM.Application.Services.Payments;

namespace HCM.Application.Features.Payments.Commands;

public class PaymentParticularDeleteCommand : IRequest<bool>
{
    public int[] Ids { get; set; }
}

public class PaymentParticularDeleteCommandHandler : IRequestHandler<PaymentParticularDeleteCommand, bool>
{
    private readonly IPaymentParticularService _service;

    public PaymentParticularDeleteCommandHandler(IPaymentParticularService service)
    {
        _service = service;
    }

    public async Task<bool> Handle(PaymentParticularDeleteCommand request, CancellationToken cancellationToken)
    {
        await _service.DeleteAsync(request.Ids);
        return true;
    }
}