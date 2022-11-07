using HCM.Application.Services.Payments;

namespace HCM.Application.Features.Payments.Commands;

public class PaymentParticularPostCommand : PaymentParticularModel, IRequest<PaymentParticularModel>
{
}

public class PaymentParticularPostCommandHandler : IRequestHandler<PaymentParticularPostCommand, PaymentParticularModel>
{
    private readonly IPaymentParticularService _service;

    public PaymentParticularPostCommandHandler(IPaymentParticularService service)
    {
        _service = service;
    }

    public async Task<PaymentParticularModel> Handle(PaymentParticularPostCommand request, CancellationToken cancellationToken)
    {
        return await _service.PostAsync(request);
    }
}
