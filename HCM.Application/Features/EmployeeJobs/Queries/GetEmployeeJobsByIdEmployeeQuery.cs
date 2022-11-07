using HCM.Application.Services.Employees;

namespace HCM.Application.Features.Employees.Queries;

public class GetEmployeeJobsByIdEmployeeQuery : IRequest<IEnumerable<EmployeeJobModel>>
{
    public int IdEmployee { get; set; }
}

public class GetEmployeeJobsByIdEmployeeHandler : IRequestHandler<GetEmployeeJobsByIdEmployeeQuery, IEnumerable<EmployeeJobModel>>
{
    private readonly IEmployeeJobService _service;

    public GetEmployeeJobsByIdEmployeeHandler(IEmployeeJobService service)
    {
        _service = service;
    }

    public async Task<IEnumerable<EmployeeJobModel>> Handle(GetEmployeeJobsByIdEmployeeQuery request, CancellationToken cancellationToken)
    {
        return await _service.GetAsync(request.IdEmployee);
    }
}
