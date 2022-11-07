using HCM.Application.Repositories.Payrolls;

namespace HCM.Application.Services.Payrolls;

public interface IPayrollScheduleDetailService
{
    Task<PayrollScheduleDetailModel> PostAsync(PayrollScheduleDetailModel o);
    Task<PayrollScheduleDetailModel> PutAsync(int id, PayrollScheduleDetailModel o);
    Task DeleteAsync(int[] id);
    Task<IEnumerable<PayrollScheduleDetailModel>> GetAsync(int idPayrollSchedule);
}

public class PayrollScheduleDetailService : IPayrollScheduleDetailService
{
    private readonly IPayrollScheduleDetailRepository _repository;
    private readonly IMapper _mapper;

    public PayrollScheduleDetailService(IPayrollScheduleDetailRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PayrollScheduleDetailModel> PostAsync(PayrollScheduleDetailModel o)
    {
        var dto = _mapper.Map<PayrollScheduleDetailDto>(o);

        o.Id = await _repository.PostAsync(dto);

        return o;
    }

    public async Task<PayrollScheduleDetailModel> PutAsync(int id, PayrollScheduleDetailModel o)
    {
        var dto = _mapper.Map<PayrollScheduleDetailDto>(o);

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


    public async Task<IEnumerable<PayrollScheduleDetailModel>> GetAsync(int idPayrollSchedule)
    {
        var dto = await _repository.GetPayrollScheduleDetails(idPayrollSchedule).ToListAsync();

        var model = _mapper.Map<IEnumerable<PayrollScheduleDetailDto>, IEnumerable<PayrollScheduleDetailModel>>(dto);

        return model;
    }
}
