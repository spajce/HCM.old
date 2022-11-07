using HCM.Application.Services.Jobs;

namespace HCM.Application.Features.JobPositions.Commands;

public class JobPositionPostCommand : JobPositionModel, IRequest<ResultModel<JobPositionModel>>
{
}

public class JobPositionPostCommandHandler : IRequestHandler<JobPositionPostCommand, ResultModel<JobPositionModel>>
{
    private readonly IJobPositionService _service;

    public JobPositionPostCommandHandler(IJobPositionService service)
    {
        _service = service;
    }

    public async Task<ResultModel<JobPositionModel>> Handle(JobPositionPostCommand request, CancellationToken cancellationToken)
    {
        return await _service.PostAsync(request);
    }
}
