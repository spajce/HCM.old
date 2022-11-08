namespace HCMServer.Apis.V1.Controllers.Payments;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class PaymentParticularsController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public PaymentParticularsController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        GetPaymentParticularsQuery q = new GetPaymentParticularsQuery();

        var result = await _mediator.Send(q).ConfigureAwait(false);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(PaymentParticularModel o)
    {
        var command = _mapper.Map<PaymentParticularPostCommand>(o);

        var result = await _mediator.Send(command).ConfigureAwait(false);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, PaymentParticularModel o)
    {
        if (id != o.Id)
            return BadRequest();

        var command = _mapper.Map<PaymentParticularPutCommand>(o);

        var result = await _mediator.Send(command).ConfigureAwait(false);

        return Ok(result);
    }

    [HttpDelete("{ids}")]
    public async Task<IActionResult> DeleteAsync(int[] ids)
    {
        var command = new PaymentParticularDeleteCommand
        {
            Ids = ids
        };

        var result = await _mediator.Send(command).ConfigureAwait(false);

        return Ok(result);
    }
}
