using HCM.Application.Services.Jobs;

namespace HCM.Application.Features.JobPositionParents.Commands;

public class JobPositionParentPutCommand : JobPositionParentModel, IRequest<JobPositionParentModel>
{
}

public class JobPositionParentPutCommandHandler : IRequestHandler<JobPositionParentPutCommand, JobPositionParentModel>
{
    private readonly IJobPositionParentService _service;

    public JobPositionParentPutCommandHandler(IJobPositionParentService service)
    {
        _service = service;
    }

    public async Task<JobPositionParentModel> Handle(JobPositionParentPutCommand request, CancellationToken cancellationToken)
    {
        return await _service.PutAsync(request.Id, request);
    }
}