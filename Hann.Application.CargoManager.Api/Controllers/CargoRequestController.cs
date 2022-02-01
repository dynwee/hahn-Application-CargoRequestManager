using Hann.Application.CargoManager.Application.DTOs.CargoRequests;
using Hann.Application.CargoManager.Application.Features.CargoRequests.Requests.Commands;
using Hann.Application.CargoManager.Application.Features.CargoRequests.Requests.Queries;
using Hann.Application.CargoManager.Application.Responses;
using Hann.Application.CargoManager.Domain;
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
    //[Authorize]
    public class CargoRequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CargoRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CargoRequestController>
        [HttpGet]
        public async Task<ActionResult<List<CargoRequestDto>>> Get()
        {
            var response = await _mediator.Send(new GetCargoRequestList());
            return Ok(response);
        }

        // GET api/<CargoRequestController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CargoRequestDto>> Get(int id)
        {
            var response = await _mediator.Send(new GetCargoRequest { Id = id });
            return Ok(response);
        }

        // GET api/<CargoRequestController>/5
        [HttpGet("details/{id}")]
        public async Task<ActionResult<CargoRequestDetailsDto>> GetDetails(int id)
        {
            var response = await _mediator.Send(new GetCargoRequestDetails { Id = id });
            return Ok(response);
        }

        // POST api/<CargoRequestController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCargoRequestDto createCargoRequestDto)
        {
            var command = new CreateCargoRequestCommand { CreateCargoRequestDto = createCargoRequestDto };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        // PUT api/<CargoRequestController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] int id,[FromBody] UpdateCargoRequestDto updateCargoRequestDto)
        {
            var command = new UpdateCargoRequestCommand { Id = id, UpdateCargoRequestDto = updateCargoRequestDto };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch([FromRoute]int id,[FromBody] ChangeCargoRequestStatusDto changeCargoRequestStatusDto)
        {
            var command = new UpdateCargoRequestCommand { Id=id, ChangeCargoRequestStatusDto = changeCargoRequestStatusDto };
            await _mediator.Send(command);

            return NoContent();
        }

        // DELETE api/<CargoRequestController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCargoRequestCommand { Id = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
