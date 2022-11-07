using HCM.Application.Repositories.Payrolls;

namespace HCM.Application.Services.Payrolls;

public interface IPayrollScheduleService
{
    Task<PayrollScheduleModel> PostAsync(PayrollScheduleModel o);
    Task<PayrollScheduleModel> PutAsync(int id, PayrollScheduleModel o);
    Task DeleteAsync(int[] id);
    Task<IEnumerable<PayrollScheduleModel>> GetAsync();
}

public class PayrollScheduleService : IPayrollScheduleService
{
    private readonly IPayrollScheduleRepository _repository;
    private readonly IMapper _mapper;

    public PayrollScheduleService(IPayrollScheduleRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PayrollScheduleModel> PostAsync(PayrollScheduleModel o)
    {
        var dto = _mapper.Map<PayrollScheduleDto>(o);

        o.Id = await _repository.PostAsync(dto);

        return o;
    }

    public async Task<PayrollScheduleModel> PutAsync(int id, PayrollScheduleModel o)
    {
        var dto = _mapper.Map<PayrollScheduleDto>(o);

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


    public async Task<IEnumerable<PayrollScheduleModel>> GetAsync()
    {
        var dto = await _repository.GetPayrollSchedules().ToListAsync();

        var model = _mapper.Map<IEnumerable<PayrollScheduleDto>, IEnumerable<PayrollScheduleModel>>(dto);

        return model;
    }
}
