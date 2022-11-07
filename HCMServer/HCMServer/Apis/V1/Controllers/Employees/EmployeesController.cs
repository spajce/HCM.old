using HCM.Common.Models;
using HCM.Application.Features.Employees.Queries.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using HCM.Common.Models.Employees;
using HCM.Application.Features.Employees.Queries.Commands;

namespace HCMServer.Apis.V1.Controllers.Employees
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public EmployeesController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationFilterModel page)
        {
            var query = _mapper.Map<EmployeePaginationQuery>(page);

            var result = await _mediator.Send(query).ConfigureAwait(false);

            return Ok(result);
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<IActionResult> PostAsync(EmployeeModel o)
        {
            var command = _mapper.Map<EmployeePostCommand>(o);

            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, EmployeeModel o)
        {
            if (id != o.Id)
                return BadRequest();

            var command = _mapper.Map<EmployeePostCommand>(o);

            var result = await _mediator.Send(command).ConfigureAwait(false);

            return Ok(result);
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{ids}")]
        public async Task<IActionResult> DeleteAsync(int[] ids)
        {
            var command = new EmployeeDeleteCommand
            {
                Ids = ids
            };

            var result = await _mediator.Send(command).ConfigureAwait(false);

            return Ok(result);
        }
    }
}
