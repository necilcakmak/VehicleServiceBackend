using Car.Entities.Concrete;
using Car.Entities.Dtos;
using Car.Shared.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Service.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult<CompanyPerson>> Authenticate(LoginDto loginDto);
    }
}
