using HCM.Application.Repositories.Jobs;

namespace HCM.Application.Services.Jobs;

public interface IJobPositionService
{
    Task<ResultModel<JobPositionModel>> PostAsync(JobPositionModel o);
    Task<ResultModel<JobPositionModel>> PutAsync(int id, JobPositionModel o);
    Task DeleteAsync(int[] id);
    Task<IEnumerable<JobPositionModel>> GetAsync();
}

public class JobPositionService : IJobPositionService
{
    private readonly IJobPositionRepository _repository;
    private readonly IMapper _mapper;

    public JobPositionService(IJobPositionRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResultModel<JobPositionModel>> PostAsync(JobPositionModel o)
    {
        var dto = _mapper.Map<JobPositionDto>(o);

        o.Id = await _repository.PostAsync(dto);

        return ResultModel<JobPositionModel>.Success(o);
    }

    public async Task<ResultModel<JobPositionModel>> PutAsync(int id, JobPositionModel o)
    {
        var dto = _mapper.Map<JobPositionDto>(o);

        await _repository.PutAsync(id, dto);

        return ResultModel<JobPositionModel>.Success(o);
    }

    public async Task DeleteAsync(int[] ids)
    {
        // TODO: BulkDelete
        foreach (var id in ids)
        {
            await _repository.RemoveAsync(id);
        }
    }


    public async Task<IEnumerable<JobPositionModel>> GetAsync()
    {
        var dto = await _repository.GetJobPositions().ToListAsync();

        var model = _mapper.Map<IEnumerable<JobPositionDto>, IEnumerable<JobPositionModel>>(dto);

        return model;
    }
}
