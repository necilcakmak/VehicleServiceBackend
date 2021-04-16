using Car.Api.Filters;
using Car.Entities.Dtos.InvoiceDtos;
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
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _ınvoiceService;

        public InvoiceController(IInvoiceService ınvoiceService)
        {
            _ınvoiceService = ınvoiceService;
        }

        [HttpGet("invoice/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _ınvoiceService.Get(id);
            return Ok(result);
        }


        [HttpGet("invoices")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _ınvoiceService.GetAll();
            return Ok(result);
        }

        [HttpGet("invoiceLast")]
        public async Task<IActionResult> GetLastInvoice()
        {
            var result = await _ınvoiceService.GetLastAll();
            return Ok(result);
        }

        [HttpPost("invoice/create")]
        public async Task<IActionResult> InvoiceAdd(InvoiceAddDto ınvoiceAddDto)
        {
            var ınvoiceAdded = await _ınvoiceService.Add(ınvoiceAddDto);
            return Ok(ınvoiceAdded);
        }

        //[HttpPut("update")]
        //public async Task<IActionResult> InvoiceUpdate(CustomerUpdateDto customerUpdateDto)
        //{
        //    var customerUpdated = await _ınvoiceService.Update(customerUpdateDto);
        //    return Ok(customerUpdated);
        //}

        [HttpDelete("invoice/{id}")]
        public async Task<IActionResult> InvoiceDelete(int id)
        {
            var ınvoiceDeleted = await _ınvoiceService.Delete(id);
            return Ok(ınvoiceDeleted);
        }
    }
}
