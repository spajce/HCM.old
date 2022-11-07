using HCM.Application.Services.Jobs;

namespace HCM.Application.Features.JobPositions.Commands;

public class JobPositionDeleteCommand : IRequest<bool>
{
    public int[] Ids { get; set; }
}

public class JobPositionDeleteCommandHandler : IRequestHandler<JobPositionDeleteCommand, bool>
{
    private readonly IJobPositionService _service;

    public JobPositionDeleteCommandHandler(IJobPositionService service)
    {
        _service = service;
    }

    public async Task<bool> Handle(JobPositionDeleteCommand request, CancellationToken cancellationToken)
    {
        await _service.DeleteAsync(request.Ids);
        return true;
    }
}