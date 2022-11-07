using HCM.Application.Services.Jobs;

namespace HCM.Application.Features.JobDepartments.Commands;

public class JobDepartmentPutCommand : JobDepartmentModel, IRequest<JobDepartmentModel>
{
}

public class JobDepartmentPutCommandHandler : IRequestHandler<JobDepartmentPutCommand, JobDepartmentModel>
{
    private readonly IJobDepartmentService _service;

    public JobDepartmentPutCommandHandler(IJobDepartmentService service)
    {
        _service = service;
    }

    public async Task<JobDepartmentModel> Handle(JobDepartmentPutCommand request, CancellationToken cancellationToken)
    {
        return await _service.PutAsync(request.Id, request);
    }
}