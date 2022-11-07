using HCM.Application.Services.Jobs;

namespace HCM.Application.Features.JobCompensations.Queries;

public class GetJobCompensationLevelsQuery : IRequest<IEnumerable<JobCompensationLevelModel>>
{
}

public class GetAllJobCompensationLevelQueryHandler : IRequestHandler<GetJobCompensationLevelsQuery, IEnumerable<JobCompensationLevelModel>>
{
    private readonly IJobCompensationLevelService _service;

    public GetAllJobCompensationLevelQueryHandler(IJobCompensationLevelService service)
    {
        _service = service;
    }

    public async Task<IEnumerable<JobCompensationLevelModel>> Handle(GetJobCompensationLevelsQuery request, CancellationToken cancellationToken)
    {
        return await _service.GetAsync();
    }
}
