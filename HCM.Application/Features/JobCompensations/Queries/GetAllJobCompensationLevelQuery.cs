using HCM.Application.Services.Jobs;

namespace HCM.Application.Features.JobCompensations.Queries;

public class GetAllJobCompensationLevelQuery : IRequest<IEnumerable<JobCompensationLevelModel>>
{
}

public class GetAllJobCompensationLevelQueryHandler : IRequestHandler<GetAllJobCompensationLevelQuery, IEnumerable<JobCompensationLevelModel>>
{
    private readonly IJobCompensationLevelService _service;

    public GetAllJobCompensationLevelQueryHandler(IJobCompensationLevelService service)
    {
        _service = service;
    }

    public async Task<IEnumerable<JobCompensationLevelModel>> Handle(GetAllJobCompensationLevelQuery request, CancellationToken cancellationToken)
    {
        return await _service.GetAsync();
    }
}
