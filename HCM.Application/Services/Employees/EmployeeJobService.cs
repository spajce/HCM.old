using HCM.Application.Repositories.Employees;

namespace HCM.Application.Services.Employees;

public interface IEmployeeJobService
{
    Task<EmployeeJobModel> PostAsync(EmployeeJobModel o);
    Task<EmployeeJobModel> PutAsync(int id, EmployeeJobModel o);
    Task DeleteAsync(int[] id);
    Task<IEnumerable<EmployeeJobModel>> GetAsync(int idEmployee);
}

public class EmployeeJobService : IEmployeeJobService
{
    private readonly IEmployeeJobRepository _repository;
    private readonly IMapper _mapper;

    public EmployeeJobService(IEmployeeJobRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EmployeeJobModel> PostAsync(EmployeeJobModel o)
    {
        var dto = _mapper.Map<EmployeeJobDto>(o);

        o.Id = await _repository.PostAsync(dto);
        o.CreateBy = dto.CreateBy;
        o.CreateAt = dto.CreateAt;

        return o;
    }

    public async Task<EmployeeJobModel> PutAsync(int id, EmployeeJobModel o)
    {
        var dto = _mapper.Map<EmployeeJobDto>(o);

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


    public async Task<IEnumerable<EmployeeJobModel>> GetAsync(int idEmployee)
    {
        var dto = await _repository.GetEmployeeJobs(idEmployee).ToListAsync();

        var model = _mapper.Map<IEnumerable<EmployeeJobDto>, IEnumerable<EmployeeJobModel>>(dto);

        return model;
    }
}
