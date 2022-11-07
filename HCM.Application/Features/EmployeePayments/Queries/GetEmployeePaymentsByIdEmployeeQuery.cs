using HCM.Application.Services.Employees;

namespace HCM.Application.Features.Employees.Queries;

public class GetEmployeePaymentsByIdEmployeeQuery : IRequest<IEnumerable<EmployeePaymentModel>>
{
    public int IdEmployee { get; set; }
}

public class GetEmployeePaymentsByIdEmployeeHandler : IRequestHandler<GetEmployeePaymentsByIdEmployeeQuery, IEnumerable<EmployeePaymentModel>>
{
    private readonly IEmployeePaymentService _service;

    public GetEmployeePaymentsByIdEmployeeHandler(IEmployeePaymentService service)
    {
        _service = service;
    }

    public async Task<IEnumerable<EmployeePaymentModel>> Handle(GetEmployeePaymentsByIdEmployeeQuery request, CancellationToken cancellationToken)
    {
        return await _service.GetAsync(request.IdEmployee);
    }
}
