using Hann.Application.CargoManager.Application.DTOs.VehicleTypes;
using Hann.Application.CargoManager.Application.Features.VehicleTypes.Requests.Commands;
using Hann.Application.CargoManager.Application.Features.VehicleTypes.Requests.Queries;
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
    //[Authorize]
    public class VehicleTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehicleTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<VehicleTypeController>
        [HttpGet]
        public async Task<ActionResult<List<VehicleTypeDto>>> Get()
        {
            var response = await _mediator.Send(new GetVehicleTypeListRequest());
            return Ok(response);
        }

        // GET api/<VehicleTypeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleTypeDto>> Get(int id)
        {
            var response = await _mediator.Send(new GetVehicleTypeRequest {Id = id});
            return Ok(response);
        }

        // POST api/<VehicleTypeController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> PostAsync([FromBody] CreateVehicleTypeDto createVehicleTypeDto)
        {
            var command = new CreateVehicleTypeCommand { CreateVehicleTypeDto = createVehicleTypeDto };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        // PUT api/<VehicleTypeController>
        [HttpPut]
        public async Task<ActionResult> PutAsync([FromBody] UpdateVehicleTypeDto updateVehicleTypeDto)
        {
            var command = new UpdateVehicleTypeCommand { UpdateVehicleTypeDto = updateVehicleTypeDto };
            await _mediator.Send(command);

            return NoContent();
        }

        // DELETE api/<VehicleTypeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var command = new DeleteVehicleTypeCommand { Id = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
