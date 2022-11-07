using HCM.Application.Services.Employees;

namespace HCM.Application.Features.Employees.Commands;

public class EmployeeJobPostCommand : EmployeeJobModel, IRequest<EmployeeJobModel>
{
}

public class EmployeeJobPostCommandHandler : IRequestHandler<EmployeeJobPostCommand, EmployeeJobModel>
{
    private readonly IEmployeeJobService _service;

    public EmployeeJobPostCommandHandler(IEmployeeJobService service)
    {
        _service = service;
    }

    public async Task<EmployeeJobModel> Handle(EmployeeJobPostCommand request, CancellationToken cancellationToken)
    {
        return await _service.PostAsync(request);
    }
}
