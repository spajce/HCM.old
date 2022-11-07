using HCM.Application.Repositories.Jobs;

namespace HCM.Application.Services.Jobs;

public interface IJobCompensationLevelService
{
    Task<JobCompensationLevelModel> PostAsync(JobCompensationLevelModel o);
    Task<JobCompensationLevelModel> PutAsync(int id, JobCompensationLevelModel o);
    Task DeleteAsync(int[] id);
    Task<IEnumerable<JobCompensationLevelModel>> GetAsync();
}

public class JobCompensationLevelService : IJobCompensationLevelService
{
    private readonly IJobCompensationLevelRepository _repository;
    private readonly IMapper _mapper;

    public JobCompensationLevelService(IJobCompensationLevelRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<JobCompensationLevelModel> PostAsync(JobCompensationLevelModel o)
    {
        var dto = _mapper.Map<JobCompensationLevelDto>(o);

        o.Id = await _repository.PostAsync(dto);

        return o;
    }

    public async Task<JobCompensationLevelModel> PutAsync(int id, JobCompensationLevelModel o)
    {
        var dto = _mapper.Map<JobCompensationLevelDto>(o);

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


    public async Task<IEnumerable<JobCompensationLevelModel>> GetAsync()
    {
        var dto = await _repository.GetJobCompensationLevels().ToListAsync();

        var model = _mapper.Map<IEnumerable<JobCompensationLevelDto>, IEnumerable<JobCompensationLevelModel>>(dto);

        return model;
    }
}
