namespace HCMServer.Apis.V1.Controllers.EmployeeJobs;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class EmployeeJobsController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public EmployeeJobsController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("{idEmployee}")]
    public async Task<IActionResult> GetAsync(int idEmployee)
    {
        GetEmployeeJobsByIdEmployeeQuery q = new GetEmployeeJobsByIdEmployeeQuery
        {
            IdEmployee = idEmployee
        };

        var result = await _mediator.Send(q).ConfigureAwait(false);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(EmployeeJobModel o)
    {
        var command = _mapper.Map<EmployeeJobPostCommand>(o);

        var result = await _mediator.Send(command).ConfigureAwait(false);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, EmployeeJobModel o)
    {
        if (id != o.Id)
            return BadRequest();

        var command = _mapper.Map<EmployeeJobPutCommand>(o);

        var result = await _mediator.Send(command).ConfigureAwait(false);

        return Ok(result);
    }

    [HttpDelete("{ids}")]
    public async Task<IActionResult> DeleteAsync(int[] ids)
    {
        var command = new EmployeeJobDeleteCommand
        {
            Ids = ids
        };

        var result = await _mediator.Send(command).ConfigureAwait(false);

        return Ok(result);
    }
}
