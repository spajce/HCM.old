namespace HCMServer.Apis.V1.Controllers.Payrolls;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class PayrollScheduleDetailsController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public PayrollScheduleDetailsController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("{idPayrollSchedule}")]
    public async Task<IActionResult> GetAsync(int idPayrollSchedule)
    {
        GetPayrollScheduleDetailsByIdPayrollScheduleQuery q = new GetPayrollScheduleDetailsByIdPayrollScheduleQuery()
        {
            IdPayrollSchedule = idPayrollSchedule
        };

        var result = await _mediator.Send(q).ConfigureAwait(false);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(PayrollScheduleDetailModel o)
    {
        var command = _mapper.Map<PayrollScheduleDetailPostCommand>(o);

        var result = await _mediator.Send(command).ConfigureAwait(false);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, PayrollScheduleDetailModel o)
    {
        if (id != o.Id)
            return BadRequest();

        var command = _mapper.Map<PayrollScheduleDetailPutCommand>(o);

        var result = await _mediator.Send(command).ConfigureAwait(false);

        return Ok(result);
    }

    [HttpDelete("{ids}")]
    public async Task<IActionResult> DeleteAsync(int[] ids)
    {
        var command = new PayrollScheduleDetailDeleteCommand
        {
            Ids = ids
        };

        var result = await _mediator.Send(command).ConfigureAwait(false);

        return Ok(result);
    }
}
