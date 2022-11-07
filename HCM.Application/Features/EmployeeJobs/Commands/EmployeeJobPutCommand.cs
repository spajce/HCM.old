using HCM.Application.Services.Employees;

namespace HCM.Application.Features.Employees.Commands;

public class EmployeeJobPutCommand : EmployeeJobModel, IRequest<EmployeeJobModel>
{
}

public class EmployeeJobPutCommandandler : IRequestHandler<EmployeeJobPutCommand, EmployeeJobModel>
{
    private readonly IEmployeeJobService _service;

    public EmployeeJobPutCommandandler(IEmployeeJobService service)
    {
        _service = service;
    }

    public async Task<EmployeeJobModel> Handle(EmployeeJobPutCommand request, CancellationToken cancellationToken)
    {
        return await _service.PutAsync(request.Id, request);
    }
}