using HCM.Application.Repositories.Employees;

namespace HCM.Application.Services.Employees;

public interface IEmployeePaymentService
{
    Task<EmployeePaymentModel> PostAsync(EmployeePaymentModel o);
    Task<EmployeePaymentModel> PutAsync(int id, EmployeePaymentModel o);
    Task DeleteAsync(int[] id);
    Task<IEnumerable<EmployeePaymentModel>> GetAsync(int idEmployee);
}

public class EmployeePaymentService : IEmployeePaymentService
{
    private readonly IEmployeePaymentRepository _repository;
    private readonly IMapper _mapper;

    public EmployeePaymentService(IEmployeePaymentRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EmployeePaymentModel> PostAsync(EmployeePaymentModel o)
    {
        var dto = _mapper.Map<EmployeePaymentDto>(o);

        o.Id = await _repository.PostAsync(dto);
        o.CreateBy = dto.CreateBy;
        o.CreateAt = dto.CreateAt;

        return o;
    }

    public async Task<EmployeePaymentModel> PutAsync(int id, EmployeePaymentModel o)
    {
        var dto = _mapper.Map<EmployeePaymentDto>(o);

        await _repository.PutAsync(id, dto);

        o.UpdateBy = dto.UpdateBy;
        o.UpdateAt = dto.UpdateAt;

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


    public async Task<IEnumerable<EmployeePaymentModel>> GetAsync(int idEmployee)
    {
        var dto = await _repository.GetEmployeePayments(idEmployee).ToListAsync();

        var model = _mapper.Map<IEnumerable<EmployeePaymentDto>, IEnumerable<EmployeePaymentModel>>(dto);

        return model;
    }
}
