using Car.Data.Abstract;
using Car.Entities.Concrete;
using Car.Entities.Dtos;
using Car.Service.Abstract;
using Car.Shared.Result.Abstract;
using Car.Shared.Result.Concrete;
using Car.Shared.Result.Type;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Car.Service.Concrete
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
        public async Task<IDataResult<CompanyPerson>> Authenticate(LoginDto loginDto)
        {
            var loginUser = await _unitOfWork.CompanyPersons.GetAsync(c => c.Email == loginDto.Email);
            //login isteği atan kullanıcıyı db de ara ilgili email varsa ve parolalar doğru ise gir ve token  üret.

            if (loginUser!=null && loginUser.Email == loginDto.Email && BCrypt.Net.BCrypt.Verify(loginDto.Password, loginUser.Password))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                //appSettings de oluşturduğumuz TokenKey imizi ıConfiguration ile okuyabiliyoruz.
                var key = Encoding.ASCII.GetBytes(_configuration["TokenKey"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name,loginUser.Id.ToString())
                    }),
                    //1 saatlik token ürettik
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                //login başarılı ise ilgili kullanıcının bilgilerini ve tokenı dönüyoruz.
                return new DataResult<CompanyPerson>(ResultStatus.Success, tokenHandler.WriteToken(token), loginUser);

            }
            //giriş başarısız ise aşağıda ki oluşturduğumuz hatayı dönüyoruz.
            DataResult<CompanyPerson> res = new DataResult<CompanyPerson>(ResultStatus.Error, "Validation Errors");
            Dictionary<string, string> validationErrors = new Dictionary<string, string>();
            validationErrors.Add("Hata", "Email veya Parola Hatalı");
            res.validationErrors = validationErrors;
            return res;

        }
    }
}
