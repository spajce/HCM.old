using HCM.Application.Repositories.Payments;
using HCM.Common.Models.Payments;

namespace HCM.Application.Services.Payments;

public interface IPaymentParticularService
{
    Task<PaymentParticularModel> PostAsync(PaymentParticularModel o);
    Task<PaymentParticularModel> PutAsync(int id, PaymentParticularModel o);
    Task DeleteAsync(int[] id);
    Task<IEnumerable<PaymentParticularModel>> GetAsync();
}

public class PaymentParticularService : IPaymentParticularService
{
    private readonly IPaymentParticularRepository _repository;
    private readonly IMapper _mapper;

    public PaymentParticularService(IPaymentParticularRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PaymentParticularModel> PostAsync(PaymentParticularModel o)
    {
        var dto = _mapper.Map<PaymentParticularDto>(o);

        o.Id = await _repository.PostAsync(dto);

        return o;
    }

    public async Task<PaymentParticularModel> PutAsync(int id, PaymentParticularModel o)
    {
        var dto = _mapper.Map<PaymentParticularDto>(o);

        await _repository.PutAsync(id, dto);

        return o;
    }

    public async Task DeleteAsync(int[] ids)
    {
        // TODO: BulkDelete
        foreach (var id in ids)
        {
            await _repository.RemoveAsync(id);
        }
    }


    public async Task<IEnumerable<PaymentParticularModel>> GetAsync()
    {
        var dto = await _repository.GetPaymentParticulars().ToListAsync();

        var model = _mapper.Map<IEnumerable<PaymentParticularDto>, IEnumerable<PaymentParticularModel>>(dto);

        return model;
    }
}
