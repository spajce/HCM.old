using HCM.Application.Services.Jobs;

namespace HCM.Application.Features.JobPositions.Queries;

public class GetJobPositionsQuery : IRequest<IEnumerable<JobPositionModel>>
{
}

public class GetAllJobPositionPutQueryHandler : IRequestHandler<GetJobPositionsQuery, IEnumerable<JobPositionModel>>
{
    private readonly IJobPositionService _service;

    public GetAllJobPositionPutQueryHandler(IJobPositionService service)
    {
        _service = service;
    }

    public async Task<IEnumerable<JobPositionModel>> Handle(GetJobPositionsQuery request, CancellationToken cancellationToken)
    {
        return await _service.GetAsync();
    }
}
