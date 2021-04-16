using Car.Api.Filters;
using Car.Entities.Dtos.VehicleDtos;
using Car.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car.Api.Controllers
{
    [Authorize]
    [ValidationFilter]
    [Route("api")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }
        [HttpGet("vehicle/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _vehicleService.Get(id);
            return Ok(result);
        }


        [HttpGet("vehicles")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _vehicleService.GetAll();
            return Ok(result);
        }


        [HttpPost("vehicle/create")]
        public async Task<IActionResult> VehicleAdd(VehicleAddDto vehicleAddDto)
        {
            var vehicleAdded = await _vehicleService.Add(vehicleAddDto);
            return Ok(vehicleAdded);
        }

        [HttpPut("vehicle/update")]
        public async Task<IActionResult> CustomerUpdate(VehicleAddDto vehicleAddDto)
        {
            var customerUpdated = await _vehicleService.Update(vehicleAddDto);
            return Ok(customerUpdated);
        }

        [HttpDelete("vehicle/{id}")]
        public async Task<IActionResult> VehicleDelete(int id)
        {
            var vehicleDeleted = await _vehicleService.Delete(id);
            return Ok(vehicleDeleted);
        }
    }
}
