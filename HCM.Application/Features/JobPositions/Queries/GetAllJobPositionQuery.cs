using HCM.Application.Services.Jobs;

namespace HCM.Application.Features.JobPositions.Queries;

public class GetAllJobPositionQuery : IRequest<IEnumerable<JobPositionModel>>
{
}

public class GetAllJobPositionPutQueryHandler : IRequestHandler<GetAllJobPositionQuery, IEnumerable<JobPositionModel>>
{
    private readonly IJobPositionService _service;

    public GetAllJobPositionPutQueryHandler(IJobPositionService service)
    {
        _service = service;
    }

    public async Task<IEnumerable<JobPositionModel>> Handle(GetAllJobPositionQuery request, CancellationToken cancellationToken)
    {
        return await _service.GetAsync();
    }
}
