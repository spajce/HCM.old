namespace HCMServer.Apis.V1.Controllers.EmployeePayments;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class EmployeePaymentsController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public EmployeePaymentsController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("{idEmployee}")]
    public async Task<IActionResult> GetAsync(int idEmployee)
    {
        GetEmployeePaymentsByIdEmployeeQuery q = new GetEmployeePaymentsByIdEmployeeQuery
        {
            IdEmployee = idEmployee
        };

        var result = await _mediator.Send(q).ConfigureAwait(false);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(EmployeePaymentModel o)
    {
        var command = _mapper.Map<EmployeePaymentPostCommand>(o);

        var result = await _mediator.Send(command).ConfigureAwait(false);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, EmployeePaymentModel o)
    {
        if (id != o.Id)
            return BadRequest();

        var command = _mapper.Map<EmployeePaymentPutCommand>(o);

        var result = await _mediator.Send(command).ConfigureAwait(false);

        return Ok(result);
    }

    [HttpDelete("{ids}")]
    public async Task<IActionResult> DeleteAsync(int[] ids)
    {
        var command = new EmployeePaymentDeleteCommand
        {
            Ids = ids
        };

        var result = await _mediator.Send(command).ConfigureAwait(false);

        return Ok(result);
    }
}
