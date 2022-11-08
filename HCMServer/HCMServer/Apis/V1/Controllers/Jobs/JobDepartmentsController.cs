namespace HCMServer.Apis.V1.Controllers.Jobs;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class JobDepartmentsController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public JobDepartmentsController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        GetJobDepartmentsQuery q = new GetJobDepartmentsQuery();

        var result = await _mediator.Send(q).ConfigureAwait(false);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(JobDepartmentModel o)
    {
        var command = _mapper.Map<JobDepartmentPostCommand>(o);

        var result = await _mediator.Send(command).ConfigureAwait(false);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, JobDepartmentModel o)
    {
        if (id != o.Id)
            return BadRequest();

        var command = _mapper.Map<JobDepartmentPutCommand>(o);

        var result = await _mediator.Send(command).ConfigureAwait(false);

        return Ok(result);
    }

    [HttpDelete("{ids}")]
    public async Task<IActionResult> DeleteAsync(int[] ids)
    {
        var command = new JobDepartmentDeleteCommand
        {
            Ids = ids
        };

        var result = await _mediator.Send(command).ConfigureAwait(false);

        return Ok(result);
    }
}
