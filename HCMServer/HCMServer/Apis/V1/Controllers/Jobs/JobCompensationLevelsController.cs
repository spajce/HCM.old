namespace HCMServer.Apis.V1.Controllers.Jobs;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class JobCompensationLevelsController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public JobCompensationLevelsController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        GetJobCompensationLevelsQuery q = new GetJobCompensationLevelsQuery();

        var result = await _mediator.Send(q).ConfigureAwait(false);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(JobCompensationLevelModel o)
    {
        var command = _mapper.Map<JobCompensationLevelPostCommand>(o);

        var result = await _mediator.Send(command).ConfigureAwait(false);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, JobCompensationLevelModel o)
    {
        if (id != o.Id)
            return BadRequest();

        var command = _mapper.Map<JobCompensationLevelPutCommand>(o);

        var result = await _mediator.Send(command).ConfigureAwait(false);

        return Ok(result);
    }

    [HttpDelete("{ids}")]
    public async Task<IActionResult> DeleteAsync(int[] ids)
    {
        var command = new JobCompensationLevelDeleteCommand
        {
            Ids = ids
        };

        var result = await _mediator.Send(command).ConfigureAwait(false);

        return Ok(result);
    }
}
