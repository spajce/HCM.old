using HCM.Application.Services.Jobs;

namespace HCM.Application.Features.JobCompensations.Commands;

public class JobCompensationLevelPostCommand : JobCompensationLevelModel, IRequest<JobCompensationLevelModel>
{
}

public class JobCompensationLevelPostCommandHandler : IRequestHandler<JobCompensationLevelPostCommand, JobCompensationLevelModel>
{
    private readonly IJobCompensationLevelService _service;

    public JobCompensationLevelPostCommandHandler(IJobCompensationLevelService service)
    {
        _service = service;
    }

    public async Task<JobCompensationLevelModel> Handle(JobCompensationLevelPostCommand request, CancellationToken cancellationToken)
    {
        return await _service.PostAsync(request);
    }
}
