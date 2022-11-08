using HCM.Application.Services.Jobs;

namespace HCM.Application.Features.JobPositionParents.Queries;

public class GetJobPositionParentsQuery : IRequest<IEnumerable<JobPositionParentModel>>
{
}

public class GetAllJobPositionPutQueryHandler : IRequestHandler<GetJobPositionParentsQuery, IEnumerable<JobPositionParentModel>>
{
    private readonly IJobPositionParentService _service;

    public GetAllJobPositionPutQueryHandler(IJobPositionParentService service)
    {
        _service = service;
    }

    public async Task<IEnumerable<JobPositionParentModel>> Handle(GetJobPositionParentsQuery request, CancellationToken cancellationToken)
    {
        return await _service.GetAsync();
    }
}
