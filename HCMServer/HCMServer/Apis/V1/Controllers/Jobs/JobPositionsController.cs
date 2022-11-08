namespace HCMServer.Apis.V1.Controllers.Jobs;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class JobPositionsController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public JobPositionsController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        GetJobPositionsQuery q = new GetJobPositionsQuery();

        var result = await _mediator.Send(q).ConfigureAwait(false);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(JobPositionModel o)
    {
        var command = _mapper.Map<JobPositionPostCommand>(o);

        var result = await _mediator.Send(command).ConfigureAwait(false);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, JobPositionModel o)
    {
        if (id != o.Id)
            return BadRequest();

        var command = _mapper.Map<JobPositionPutCommand>(o);

        var result = await _mediator.Send(command).ConfigureAwait(false);

        return Ok(result);
    }

    [HttpDelete("{ids}")]
    public async Task<IActionResult> DeleteAsync(int[] ids)
    {
        var command = new JobPositionDeleteCommand
        {
            Ids = ids
        };

        var result = await _mediator.Send(command).ConfigureAwait(false);

        return Ok(result);
    }
}
