using HCM.Application.Services.Payments;

namespace HCM.Application.Features.Payments.Commands;

public class PaymentParticularPutCommand : PaymentParticularModel, IRequest<PaymentParticularModel>
{
}

public class PaymentParticularPutCommandHandler : IRequestHandler<PaymentParticularPutCommand, PaymentParticularModel>
{
    private readonly IPaymentParticularService _service;

    public PaymentParticularPutCommandHandler(IPaymentParticularService service)
    {
        _service = service;
    }

    public async Task<PaymentParticularModel> Handle(PaymentParticularPutCommand request, CancellationToken cancellationToken)
    {
        return await _service.PutAsync(request.Id, request);
    }
}