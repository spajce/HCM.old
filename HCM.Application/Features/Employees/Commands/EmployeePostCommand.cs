using HCM.Application.Services.Employees;

namespace HCM.Application.Features.Employees.Commands;

public class EmployeePostCommand : EmployeeModel, IRequest<EmployeeModel>
{
}

public class EmployeePostCommandHandler : IRequestHandler<EmployeePostCommand, EmployeeModel>
{
    private readonly IEmployeeService _service;

    public EmployeePostCommandHandler(IEmployeeService service)
    {
        _service = service;
    }

    public async Task<EmployeeModel> Handle(EmployeePostCommand request, CancellationToken cancellationToken)
    {
        return await _service.PostAsync(request);
    }
}
