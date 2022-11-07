using HCM.Application.Services.Jobs;

namespace HCM.Application.Features.JobCompensations.Commands;

public class JobCompensationLevelDeleteCommand : IRequest<bool>
{
    public int[] Ids { get; set; }
}

public class JobCompensationLevelDeleteCommandHandler : IRequestHandler<JobCompensationLevelDeleteCommand, bool>
{
    private readonly IJobCompensationLevelService _service;

    public JobCompensationLevelDeleteCommandHandler(IJobCompensationLevelService service)
    {
        _service = service;
    }

    public async Task<bool> Handle(JobCompensationLevelDeleteCommand request, CancellationToken cancellationToken)
    {
        await _service.DeleteAsync(request.Ids);
        return true;
    }
}