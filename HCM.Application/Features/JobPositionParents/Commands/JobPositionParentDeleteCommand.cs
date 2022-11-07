using HCM.Application.Services.Jobs;

namespace HCM.Application.Features.JobPositionParents.Commands;

public class JobPositionParentDeleteCommand : IRequest<bool>
{
    public int[] Ids { get; set; }
}

public class JobPositionDeleteCommandHandler : IRequestHandler<JobPositionParentDeleteCommand, bool>
{
    private readonly IJobPositionParentService _service;

    public JobPositionDeleteCommandHandler(IJobPositionParentService service)
    {
        _service = service;
    }

    public async Task<bool> Handle(JobPositionParentDeleteCommand request, CancellationToken cancellationToken)
    {
        await _service.DeleteAsync(request.Ids);
        return true;
    }
}