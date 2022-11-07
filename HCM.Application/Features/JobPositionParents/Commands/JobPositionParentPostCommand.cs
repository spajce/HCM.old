using HCM.Application.Services.Jobs;

namespace HCM.Application.Features.JobPositionParents.Commands;

public class JobPositionParentPostCommand : JobPositionParentModel, IRequest<JobPositionParentModel>
{
}

public class JobPositionParentPostCommandHandler : IRequestHandler<JobPositionParentPostCommand, JobPositionParentModel>
{
    private readonly IJobPositionParentService _service;

    public JobPositionParentPostCommandHandler(IJobPositionParentService service)
    {
        _service = service;
    }

    public async Task<JobPositionParentModel> Handle(JobPositionParentPostCommand request, CancellationToken cancellationToken)
    {
        return await _service.PostAsync(request);
    }
}
