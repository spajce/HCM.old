using HCM.Application.Services.Jobs;
using HCM.Application.Services.Payments;

namespace HCM.Application.Features.Payments.Queries;

public class GetPaymentParticularsQuery : IRequest<IEnumerable<PaymentParticularModel>>
{
}

public class GetAllJobPositionPutQueryHandler : IRequestHandler<GetPaymentParticularsQuery, IEnumerable<PaymentParticularModel>>
{
    private readonly IPaymentParticularService _service;

    public GetAllJobPositionPutQueryHandler(IPaymentParticularService service)
    {
        _service = service;
    }

    public async Task<IEnumerable<PaymentParticularModel>> Handle(GetPaymentParticularsQuery request, CancellationToken cancellationToken)
    {
        return await _service.GetAsync();
    }
}
