using Car.Api.Filters;
using Car.Entities.Dtos;
using Car.Service.Abstract;
using Car.Shared.Result.Type;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car.Api.Controllers
{
    [ValidationFilter]
    [Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {       
            var result=await _authService.Authenticate(loginDto);
            return Ok(result);
        }


    }
}
