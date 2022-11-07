using HCM.Application.Services.Jobs;

namespace HCM.Application.Features.JobPositions.Commands;

public class JobPositionPutCommand : JobDepartmentModel, IRequest<JobDepartmentModel>
{
}

public class JobPositionPutCommandHandler : IRequestHandler<JobPositionPutCommand, JobDepartmentModel>
{
    private readonly IJobDepartmentService _service;

    public JobPositionPutCommandHandler(IJobDepartmentService service)
    {
        _service = service;
    }

    public async Task<JobDepartmentModel> Handle(JobPositionPutCommand request, CancellationToken cancellationToken)
    {
        return await _service.PutAsync(request.Id, request);
    }
}