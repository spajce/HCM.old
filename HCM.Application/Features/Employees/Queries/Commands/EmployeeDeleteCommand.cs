using HCM.Application.Services.Employees;
using HCM.Common.Models.Employees;

namespace HCM.Application.Features.Employees.Queries.Commands;

public class EmployeeDeleteCommand : IRequest<bool>
{
    public int[] Ids { get; set; }
}

public class DeleteEmployeeCommandHandler : IRequestHandler<EmployeeDeleteCommand, bool>
{
    private readonly IEmployeeService _service;

    public DeleteEmployeeCommandHandler(IEmployeeService service)
    {
        _service = service;
    }

    public async Task<bool> Handle(EmployeeDeleteCommand request, CancellationToken cancellationToken)
    {
        await _service.DeleteAsync(request.Ids);
        return true;
    }
}