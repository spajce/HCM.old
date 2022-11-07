
using HCM.Application.Repositories.Employees;
using HCM.Application.Services.Employees;
using HCM.Common.Models.Employees;

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
