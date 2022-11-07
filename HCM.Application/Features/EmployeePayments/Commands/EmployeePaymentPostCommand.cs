using HCM.Application.Services.Employees;

namespace HCM.Application.Features.Employees.Commands;

public class EmployeePaymentPostCommand : EmployeePaymentModel, IRequest<EmployeePaymentModel>
{
}

public class EmployeePaymentPostCommandHandler : IRequestHandler<EmployeePaymentPostCommand, EmployeePaymentModel>
{
    private readonly IEmployeePaymentService _service;

    public EmployeePaymentPostCommandHandler(IEmployeePaymentService service)
    {
        _service = service;
    }

    public async Task<EmployeePaymentModel> Handle(EmployeePaymentPostCommand request, CancellationToken cancellationToken)
    {
        return await _service.PostAsync(request);
    }
}
