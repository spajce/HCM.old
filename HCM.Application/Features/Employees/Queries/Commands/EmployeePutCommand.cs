﻿using HCM.Application.Services.Employees;
using HCM.Common.Models.Employees;

namespace HCM.Application.Features.Employees.Queries.Commands;

public class EmployeePutCommand : EmployeeModel, IRequest<EmployeeModel>
{
}

public class EmployeePutCommandHandler : IRequestHandler<EmployeePutCommand, EmployeeModel>
{
    private readonly IEmployeeService _service;

    public EmployeePutCommandHandler(IEmployeeService service)
    {
        _service = service;
    }

    public async Task<EmployeeModel> Handle(EmployeePutCommand request, CancellationToken cancellationToken)
    {
        return await _service.PutAsync(request.Id, request);
    }
}