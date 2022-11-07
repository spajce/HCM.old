using HCM.Application.Services.Jobs;

namespace HCM.Application.Features.JobPositionParents.Queries;

public class GetAllPositionParentQuery : IRequest<IEnumerable<JobPositionParentModel>>
{
}

public class GetAllJobPositionPutQueryHandler : IRequestHandler<GetAllPositionParentQuery, IEnumerable<JobPositionParentModel>>
{
    private readonly IJobPositionParentService _service;

    public GetAllJobPositionPutQueryHandler(IJobPositionParentService service)
    {
        _service = service;
    }

    public async Task<IEnumerable<JobPositionParentModel>> Handle(GetAllPositionParentQuery request, CancellationToken cancellationToken)
    {
        return await _service.GetAsync();
    }
}
