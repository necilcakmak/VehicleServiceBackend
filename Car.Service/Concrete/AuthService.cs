using AutoMapper.Configuration;
using Blog.Business.Abstract;
using Blog.Data.Abstract;
using Blog.Entities.Concrete;
using Blog.Entities.Dto;
using Blog.Shared.Data.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public AuthService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<Result<Author>> Authenticate(LoginDto loginDto)
        {
            var loginUser = await _unitOfWork.Authors.GetAsync(c => c.Email == loginDto.Email);
            if (loginUser != null && loginUser.Email == loginDto.Email && BCrypt.Net.BCrypt.Verify(loginDto.Password, loginUser.Password))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                //appSettings de oluşturduğumuz TokenKey imizi ıConfiguration ile okuyabiliyoruz.
                var key = Encoding.ASCII.GetBytes(_configuration["TokenKey"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name,loginUser.Id.ToString()),
                        new Claim(ClaimTypes.Role,loginUser.Role)
                    }),
                    //1 saatlik token ürettik
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                //login başarılı ise ilgili kullanıcının bilgilerini ve tokenı dönüyoruz.
                return new Result<Author>(tokenHandler.WriteToken(token), "Token succesfuly", true);
            }
            //giriş başarısız ise aşağıda ki oluşturduğumuz hatayı dönüyoruz.
            return new Result<Author>(null, "error", false);
        }
    }
}
