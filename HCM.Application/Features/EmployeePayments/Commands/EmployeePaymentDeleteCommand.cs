using HCM.Application.Services.Employees;

namespace HCM.Application.Features.Employees.Commands;

public class EmployeePaymentDeleteCommand : IRequest<bool>
{
    public int[] Ids { get; set; }
}

public class EmployeePaymentDeleteCommandHandler : IRequestHandler<EmployeePaymentDeleteCommand, bool>
{
    private readonly IEmployeePaymentService _service;

    public EmployeePaymentDeleteCommandHandler(IEmployeePaymentService service)
    {
        _service = service;
    }

    public async Task<bool> Handle(EmployeePaymentDeleteCommand request, CancellationToken cancellationToken)
    {
        await _service.DeleteAsync(request.Ids);
        return true;
    }
}