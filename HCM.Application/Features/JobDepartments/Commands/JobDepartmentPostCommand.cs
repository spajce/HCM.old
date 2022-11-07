using HCM.Application.Services.Jobs;

namespace HCM.Application.Features.JobDepartments.Commands;

public class JobDepartmentPostCommand : JobDepartmentModel, IRequest<JobDepartmentModel>
{
}

public class JobDepartmentPostCommandHandler : IRequestHandler<JobDepartmentPostCommand, JobDepartmentModel>
{
    private readonly IJobDepartmentService _service;

    public JobDepartmentPostCommandHandler(IJobDepartmentService service)
    {
        _service = service;
    }

    public async Task<JobDepartmentModel> Handle(JobDepartmentPostCommand request, CancellationToken cancellationToken)
    {
        return await _service.PostAsync(request);
    }
}
