using HCM.Application.Services.Jobs;

namespace HCM.Application.Features.JobCompensations.Commands;

public class JobCompensationLevelPutCommand : JobCompensationLevelModel, IRequest<JobCompensationLevelModel>
{
}

public class JobCompensationLevelPutCommandCommandHandler : IRequestHandler<JobCompensationLevelPutCommand, JobCompensationLevelModel>
{
    private readonly IJobCompensationLevelService _service;

    public JobCompensationLevelPutCommandCommandHandler(IJobCompensationLevelService service)
    {
        _service = service;
    }

    public async Task<JobCompensationLevelModel> Handle(JobCompensationLevelPutCommand request, CancellationToken cancellationToken)
    {
        return await _service.PutAsync(request.Id, request);
    }
}