using AutoMapper;
using Car.Entities.Concrete;
using Car.Entities.Dtos.CustomerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Service.AutoMapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerAddDto, Customer>()
                 .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now))
                 .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now))
                 .ForMember(dest => dest.IsActive, opt => opt.MapFrom(x => true));

            CreateMap<CustomerUpdateDto, Customer>()
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));

            CreateMap<Customer, CustomerDto>();
        }
    }
}
