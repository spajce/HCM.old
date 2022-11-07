using HCM.Application.Repositories.Jobs;

namespace HCM.Application.Services.Jobs;

public interface IJobDepartmentService
{
    Task<JobDepartmentModel> PostAsync(JobDepartmentModel o);
    Task<JobDepartmentModel> PutAsync(int id, JobDepartmentModel o);
    Task DeleteAsync(int[] id);
    Task<IEnumerable<JobDepartmentModel>> GetAsync();
}

public class JobDepartmentService : IJobDepartmentService
{
    private readonly IJobDepartmentRepository _repository;
    private readonly IMapper _mapper;

    public JobDepartmentService(IJobDepartmentRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<JobDepartmentModel> PostAsync(JobDepartmentModel o)
    {
        var dto = _mapper.Map<JobDepartmentDto>(o);

        o.Id = await _repository.PostAsync(dto);

        return o;
    }

    public async Task<JobDepartmentModel> PutAsync(int id, JobDepartmentModel o)
    {
        var dto = _mapper.Map<JobDepartmentDto>(o);

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


    public async Task<IEnumerable<JobDepartmentModel>> GetAsync()
    {
        var dto = await _repository.GetJobDepartments().ToListAsync();

        var model = _mapper.Map<IEnumerable<JobDepartmentDto>, IEnumerable<JobDepartmentModel>>(dto);

        return model;
    }
}
