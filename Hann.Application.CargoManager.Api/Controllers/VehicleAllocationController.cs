using Hann.Application.CargoManager.Application.DTOs.VehicleAllocations;
using Hann.Application.CargoManager.Application.Features.VehicleAllocations.Requests.Commands;
using Hann.Application.CargoManager.Application.Features.VehicleAllocations.Requests.Queries;
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
   // [Authorize]
    public class VehicleAllocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehicleAllocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<VehicleAllocationController>
        [HttpGet]
        public async Task<ActionResult<List<VehicleAllocationDto>>> Get()
        {
            var response = await _mediator.Send(new GetVehicleAllocationListRequest());
            return Ok(response);
        }

        // GET api/<VehicleAllocationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleAllocationDto>> Get(int id)
        {
            var response = await _mediator.Send(new GetVehicleAllocationRequest { Id = id });
            return Ok(response);
        }

        // POST api/<VehicleAllocationController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateVehicleAllocationDto createVehicleAllocationDto)
        {
            var command = new CreateVehicleAllocationCommand { CreateVehicleAllocationDto = createVehicleAllocationDto };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        // PUT api/<VehicleAllocationController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateVehicleAllocationDto updateVehicleAllocationDto)
        {
            var command = new UpdateVehicleAllocationCommand { UpdateVehicleAllocationDto = updateVehicleAllocationDto };
            await _mediator.Send(command);

            return NoContent();
        }

        // DELETE api/<VehicleAllocationController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteVehicleAllocationCommand { Id = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
