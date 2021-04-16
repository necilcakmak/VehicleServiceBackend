using Car.Entities.Concrete;
using Car.Entities.Dtos.CustomerDtos;
using Car.Shared.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Service.Abstract
{
    public interface ICustomerService
    {
        Task<IDataResult<CustomerDto>> Get(int customerId);
        Task<IDataResult<IList<CustomerDto>>> GetAll();
        Task<IResult> Add(CustomerAddDto customerAddDto);
        Task<IResult> Update(CustomerAddDto customerAddDto);
        Task<IResult> Delete(int customerId);
    }
}
