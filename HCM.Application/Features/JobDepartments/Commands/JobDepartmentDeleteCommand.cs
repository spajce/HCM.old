using HCM.Application.Services.Jobs;

namespace HCM.Application.Features.JobDepartments.Commands;

public class JobDepartmentDeleteCommand : IRequest<bool>
{
    public int[] Ids { get; set; }
}

public class JobDepartmentDeleteCommandHandler : IRequestHandler<JobDepartmentDeleteCommand, bool>
{
    private readonly IJobDepartmentService _service;

    public JobDepartmentDeleteCommandHandler(IJobDepartmentService service)
    {
        _service = service;
    }

    public async Task<bool> Handle(JobDepartmentDeleteCommand request, CancellationToken cancellationToken)
    {
        await _service.DeleteAsync(request.Ids);
        return true;
    }
}