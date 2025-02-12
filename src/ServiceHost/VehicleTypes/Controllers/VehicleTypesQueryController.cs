using FleetManagement.Application.Contract.VehicleTypes.Queries;
using FleetManagement.Domain.Models.VehicleTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceHost.VehicleTypes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleTypesQueryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehicleTypesQueryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get a vehicle type by ID.
        /// </summary>
        [HttpGet("{id:long}")]
        public async Task<ActionResult<VehicleType>> GetById(long id)
        {
            var vehicleType = await _mediator.Send(new GetVehicleTypeByIdQuery(id));
            return vehicleType != null ? Ok(vehicleType) : NotFound();
        }

        /// <summary>
        /// Get all vehicle types.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<VehicleType>>> GetAll()
        {
            var vehicleTypes = await _mediator.Send(new GetAllVehicleTypesQuery());
            return Ok(vehicleTypes);
        }
    }

}
