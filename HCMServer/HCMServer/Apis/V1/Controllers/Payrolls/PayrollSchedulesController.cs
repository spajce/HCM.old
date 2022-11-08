namespace HCMServer.Apis.V1.Controllers.Payrolls;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class PayrollSchedulesController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public PayrollSchedulesController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        GetPayrollSchedulesQuery q = new GetPayrollSchedulesQuery();

        var result = await _mediator.Send(q).ConfigureAwait(false);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(PayrollScheduleModel o)
    {
        var command = _mapper.Map<PayrollSchedulePostCommand>(o);

        var result = await _mediator.Send(command).ConfigureAwait(false);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, PayrollScheduleModel o)
    {
        if (id != o.Id)
            return BadRequest();

        var command = _mapper.Map<PayrollSchedulePutCommand>(o);

        var result = await _mediator.Send(command).ConfigureAwait(false);

        return Ok(result);
    }

    [HttpDelete("{ids}")]
    public async Task<IActionResult> DeleteAsync(int[] ids)
    {
        var command = new PayrollScheduleDeleteCommand
        {
            Ids = ids
        };

        var result = await _mediator.Send(command).ConfigureAwait(false);

        return Ok(result);
    }
}
