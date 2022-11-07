using HCM.Application.Services.Jobs;

namespace HCM.Application.Features.JobCompensations.Queries;

public class GetJobDepartmentsQuery : IRequest<IEnumerable<JobDepartmentModel>>
{
}

public class GetAllJobDepartmentQueryHandler : IRequestHandler<GetJobDepartmentsQuery, IEnumerable<JobDepartmentModel>>
{
    private readonly IJobDepartmentService _service;

    public GetAllJobDepartmentQueryHandler(IJobDepartmentService service)
    {
        _service = service;
    }

    public async Task<IEnumerable<JobDepartmentModel>> Handle(GetJobDepartmentsQuery request, CancellationToken cancellationToken)
    {
        return await _service.GetAsync();
    }
}
