using HCM.Application.Services.Employees;

namespace HCM.Application.Features.Employees.Queries.Pagination;

public class EmployeePaginationQuery : PaginationFilterModel, IRequest<PaginatedDataModel<EmployeeModel>>
{
}

public class EmployeesPaginationQueryHandler : IRequestHandler<EmployeePaginationQuery, PaginatedDataModel<EmployeeModel>>
{
    private readonly IEmployeeService _service;

    public EmployeesPaginationQueryHandler(IEmployeeService service)
    {
        _service = service;
    }

    public async Task<PaginatedDataModel<EmployeeModel>> Handle(EmployeePaginationQuery request, CancellationToken cancellationToken)
    {
        return await _service.GetEmployees(request);
    }
}
