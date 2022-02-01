using Hann.Application.CargoManager.Application.DTOs.Terminals;
using Hann.Application.CargoManager.Application.Features.Terminals.Requests.Commands;
using Hann.Application.CargoManager.Application.Features.Terminals.Requests.Queries;
using Hann.Application.CargoManager.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hann.Application.CargoManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize]
    public class TerminalController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TerminalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<TerminalController>
        [HttpGet]
        public async Task<ActionResult<List<TerminalDto>>> Get()
        {
            var response = await _mediator.Send(new GetTerminalListRequest());
            return Ok(response);
        }

        // GET api/<TerminalController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TerminalDto>> Get(int id)
        {
            var response = await _mediator.Send(new GetTerminalRequest { Id = id });
            return Ok(response);
        }

        // POST api/<TerminalController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTerminalDto createTerminalDto)
        {
            var command = new CreateTerminalComand { CreateTerminalDto = createTerminalDto };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        // PUT api/<TerminalController>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateTerminalDto updateTerminalDto)
        {
            var command = new UpdateTerminalCommand { UpdateTerminalDto = updateTerminalDto };
            await _mediator.Send(command);

            return NoContent();
        }

        // DELETE api/<TerminalController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteTerminalCommand { Id = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
