using HCM.Application.Services.Jobs;

namespace HCM.Application.Features.JobCompensations.Queries;

public class GetAllJobDepartmentQuery : IRequest<IEnumerable<JobDepartmentModel>>
{
}

public class GetAllJobDepartmentQueryHandler : IRequestHandler<GetAllJobDepartmentQuery, IEnumerable<JobDepartmentModel>>
{
    private readonly IJobDepartmentService _service;

    public GetAllJobDepartmentQueryHandler(IJobDepartmentService service)
    {
        _service = service;
    }

    public async Task<IEnumerable<JobDepartmentModel>> Handle(GetAllJobDepartmentQuery request, CancellationToken cancellationToken)
    {
        return await _service.GetAsync();
    }
}
