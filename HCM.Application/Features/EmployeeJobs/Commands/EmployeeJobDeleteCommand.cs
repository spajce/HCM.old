using HCM.Application.Services.Employees;

namespace HCM.Application.Features.Employees.Commands;

public class EmployeeJobDeleteCommand : IRequest<bool>
{
    public int[] Ids { get; set; }
}

public class EmployeeJobDeleteCommandHandler : IRequestHandler<EmployeeJobDeleteCommand, bool>
{
    private readonly IEmployeeJobService _service;

    public EmployeeJobDeleteCommandHandler(IEmployeeJobService service)
    {
        _service = service;
    }

    public async Task<bool> Handle(EmployeeJobDeleteCommand request, CancellationToken cancellationToken)
    {
        await _service.DeleteAsync(request.Ids);
        return true;
    }
}