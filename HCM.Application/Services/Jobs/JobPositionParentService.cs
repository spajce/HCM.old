using HCM.Application.Repositories.Jobs;

namespace HCM.Application.Services.Jobs;

public interface IJobPositionParentService
{
    Task<JobPositionParentModel> PostAsync(JobPositionParentModel o);
    Task<JobPositionParentModel> PutAsync(int id, JobPositionParentModel o);
    Task DeleteAsync(int[] id);
    Task<IEnumerable<JobPositionParentModel>> GetAsync();
}

public class JobPositionParentService : IJobPositionParentService
{
    private readonly IJobPositionParentRepository _repository;
    private readonly IMapper _mapper;

    public JobPositionParentService(IJobPositionParentRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<JobPositionParentModel> PostAsync(JobPositionParentModel o)
    {
        var dto = _mapper.Map<JobPositionParentDto>(o);

        o.Id = await _repository.PostAsync(dto);

        return o;
    }

    public async Task<JobPositionParentModel> PutAsync(int id, JobPositionParentModel o)
    {
        var dto = _mapper.Map<JobPositionParentDto>(o);

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


    public async Task<IEnumerable<JobPositionParentModel>> GetAsync()
    {
        var dto = await _repository.GetJobPositionParents().ToListAsync();

        var model = _mapper.Map<IEnumerable<JobPositionParentDto>, IEnumerable<JobPositionParentModel>>(dto);

        return model;
    }
}
