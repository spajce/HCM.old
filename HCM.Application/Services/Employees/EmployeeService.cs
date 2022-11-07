using HCM.Application.Repositories.Employees;

namespace HCM.Application.Services.Employees;

public interface IEmployeeService
{
    Task<EmployeeModel> PostAsync(EmployeeModel o);
    Task<EmployeeModel> PutAsync(int id, EmployeeModel o);
    Task DeleteAsync(int[] id);
    Task<IEnumerable<EmployeeModel>> GetAsync();
    Task<IEnumerable<EmployeeModel>> GetAsync(string find);
    Task<PaginatedDataModel<EmployeeModel>> GetEmployees(PaginationFilterModel request);
}

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;
    private readonly IMapper _mapper;

    public EmployeeService(IEmployeeRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EmployeeModel> PostAsync(EmployeeModel o)
    {
        o.Active ??= true;

        var dto = _mapper.Map<EmployeeDto>(o);

        o.Id = await _repository.PostAsync(dto);
        o.CreateBy = dto.CreateBy;
        o.CreateAt = dto.CreateAt;

        return o;
    }

    public async Task<EmployeeModel> PutAsync(int id, EmployeeModel o)
    {
        var dto = _mapper.Map<EmployeeDto>(o);

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

    public async Task<IEnumerable<EmployeeModel>> GetAsync()
    {
        var dto = await _repository.GetEmployees().ToListAsync();

        var model = _mapper.Map<IEnumerable<EmployeeDto>, IEnumerable<EmployeeModel>>(dto);

        return model;
    }

    public async Task<IEnumerable<EmployeeModel>> GetAsync(string find)
    {
        var dto = await _repository.GetEmployees(find).ToListAsync();

        var model = _mapper.Map<IEnumerable<EmployeeDto>, IEnumerable<EmployeeModel>>(dto);

        return model;
    }

    public async Task<PaginatedDataModel<EmployeeModel>> GetEmployees(PaginationFilterModel request)
    {
        var dto = await _repository.GetEmployees(request);
        var model = _mapper.Map<PaginatedData<EmployeeDto>, PaginatedDataModel<EmployeeModel>>(dto);
        return model;
    }
}
