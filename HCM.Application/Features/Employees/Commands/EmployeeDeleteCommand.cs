using HCM.Application.Services.Employees;

namespace HCM.Application.Features.Employees.Commands;

public class EmployeeDeleteCommand : IRequest<bool>
{
    public int[] Ids { get; set; }
}

public class EmployeeDeleteCommandHandler : IRequestHandler<EmployeeDeleteCommand, bool>
{
    private readonly IEmployeeService _service;

    public EmployeeDeleteCommandHandler(IEmployeeService service)
    {
        _service = service;
    }

    public async Task<bool> Handle(EmployeeDeleteCommand request, CancellationToken cancellationToken)
    {
        await _service.DeleteAsync(request.Ids);
        return true;
    }
}