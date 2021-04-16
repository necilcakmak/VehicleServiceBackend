using Car.Api.Filters;
using Car.Entities.Dtos.VehiclePartsDtos;
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
    public class VehiclePartController : ControllerBase
    {
        private readonly IVehiclePartService _vehiclePartService;

        public VehiclePartController(IVehiclePartService vehiclePartService)
        {
            _vehiclePartService = vehiclePartService;
        }
        [HttpGet("vehiclePart/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _vehiclePartService.Get(id);
            return Ok(result);
        }


        [HttpGet("vehicleParts")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _vehiclePartService.GetAll();
            return Ok(result);
        }


        [HttpPost("vehiclePart/create")]
        public async Task<IActionResult> VehiclePartAdd(VehiclePartAddDto vehiclePartAddDto)
        {
            var vehiclePartAdded = await _vehiclePartService.Add(vehiclePartAddDto);
            return Ok(vehiclePartAdded);
        }

        [HttpPut("vehiclePart/update")]
        public async Task<IActionResult> CustomerUpdate(VehiclePartAddDto vehiclePartAddDto)
        {
            var customerUpdated = await _vehiclePartService.Update(vehiclePartAddDto);
            return Ok(customerUpdated);
        }

        [HttpDelete("vehiclePart/{id}")]
        public async Task<IActionResult> VehiclePartDelete(int id)
        {
            var vehiclePartDeleted = await _vehiclePartService.Delete(id);
            return Ok(vehiclePartDeleted);
        }
    }
}
