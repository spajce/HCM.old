using HCM.Application.Services.Employees;

namespace HCM.Application.Features.Employees.Commands;

public class EmployeePaymentPutCommand : EmployeePaymentModel, IRequest<EmployeePaymentModel>
{
}

public class EmployeePaymentPutCommandandler : IRequestHandler<EmployeePaymentPutCommand, EmployeePaymentModel>
{
    private readonly IEmployeePaymentService _service;

    public EmployeePaymentPutCommandandler(IEmployeePaymentService service)
    {
        _service = service;
    }

    public async Task<EmployeePaymentModel> Handle(EmployeePaymentPutCommand request, CancellationToken cancellationToken)
    {
        return await _service.PutAsync(request.Id, request);
    }
}