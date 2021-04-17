using Car.Api.Filters;
using Car.Entities.Concrete;
using Car.Entities.Dtos.CustomerDtos;
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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("customer/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _customerService.Get(id);
            return Ok(result);
        }
        
        [HttpGet("customers")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _customerService.GetAll();
            return Ok(result);
        }


        [HttpPost("customer/create")]
        public async Task<IActionResult> CustomerAdd(CustomerAddDto customerAddDto)
        {
            var customerAdded = await _customerService.Add(customerAddDto);
            return Ok(customerAdded);
        }

        [HttpPut("customer/update")]
        public async Task<IActionResult> CustomerUpdate(CustomerAddDto customerAddDto)
        {
            var customerUpdated = await _customerService.Update(customerAddDto);
            return Ok(customerUpdated);
        }

        [HttpDelete("customer/{id}")]
        public async Task<IActionResult> CustomerDelete(int id)
        {
            var customerDeleted = await _customerService.Delete(id);
            return Ok(customerDeleted);
        }
    }
}
