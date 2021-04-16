using AutoMapper;
using Car.Data.Abstract;
using Car.Entities.Concrete;
using Car.Entities.Dtos.CustomerDtos;
using Car.Service.Abstract;
using Car.Shared.Result.Abstract;
using Car.Shared.Result.Concrete;
using Car.Shared.Result.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Service.Concrete
{
    class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> Add(CustomerAddDto customerAddDto)
        {
            Dictionary<string, string> validationErrors = new Dictionary<string, string>();
            var uniqueEmail = await _unitOfWork.Customers.GetAsync(x=>x.Email==customerAddDto.Email);
            if (uniqueEmail != null)
            {
                Result result = new Result(ResultStatus.Error, "Validation Errors");
                validationErrors.Add("Email", "Email Kullanımda.");
                result.validationErrors = validationErrors;
                return result;
            }
            var customer = _mapper.Map<Customer>(customerAddDto);
            await _unitOfWork.Customers.AddAsync(customer);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, "Kayıt Oluşturuldu");
           
        }

        public async Task<IResult> Delete(int customerId)
        {
            var result = await _unitOfWork.Customers.AnyAsync(a => a.Id == customerId);
            if (result)
            {
                var customer = await _unitOfWork.Customers.GetAsync(a => a.Id == customerId);

                customer.IsActive = false;
                await _unitOfWork.Customers.UpdateAsync(customer);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success,"Kayıt Silindi.");
            }
            return new Result(ResultStatus.Error, "Kayıt Bulunamadı.");
        }

        public async Task<IDataResult<CustomerDto>> Get(int customerId)
        {
            var customer = await _unitOfWork.Customers.GetAsync(c => c.Id == customerId);
            if (customer != null)
            {
                return new DataResult<CustomerDto>(ResultStatus.Success, new CustomerDto
                {
                    Id=customer.Id,
                    Name = customer.Name,
                    Email = customer.Email,
                    TaxNo = customer.TaxNo,
                    PhoneNumber=customer.PhoneNumber,
                    Adress=customer.Adress,
                    CreatedDate=customer.CreatedDate
                });
            }
            return new DataResult<CustomerDto>(ResultStatus.Error, "Böyle bir kullanıcı bulunamadı", null);
        }

        public async Task<IDataResult<IList<CustomerDto>>> GetAll()
        {
            var customer = await _unitOfWork.Customers.GetAllAsync(x=>x.IsActive==true);
            if (customer.Count > -1)
            {
                return new DataResult<List<CustomerDto>>(ResultStatus.Success, _mapper.Map<List<CustomerDto>>(customer));
            }
            return new DataResult<List<CustomerDto>>(ResultStatus.Error, "Müşteriler  bulunamadı.",null);
        }

        public async Task<IResult> Update(CustomerAddDto customerAddDto)
        {
            Dictionary<string, string> validationErrors = new Dictionary<string, string>();
            var customerInDb = await _unitOfWork.Customers.GetAsync(x => x.Email == customerAddDto.Email && x.Id != customerAddDto.Id);

            if (customerInDb != null)
            {
                Result result = new Result(ResultStatus.Error, "Validation Errors");
                validationErrors.Add("Email", "E-mail Kullanımda.");
                result.validationErrors = validationErrors;
                return result;
            }
            var customer = _mapper.Map<Customer>(customerAddDto);
            await _unitOfWork.Customers.UpdateAsync(customer);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, "Müşteri Kaydedildi.");
        }
    }
}
