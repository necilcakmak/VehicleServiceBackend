using AutoMapper;
using Car.Entities.Concrete;
using Car.Entities.Dtos;
using Car.Entities.Dtos.InvoiceDtos;
using Car.Entities.Dtos.InvoiceProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Service.AutoMapper
{
    public class InvoiceProfile:Profile
    {
        public InvoiceProfile()
        {
            CreateMap<InvoiceAddDto, Invoice>()
           .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now))
           .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now))
           .ForMember(dest => dest.IsActive, opt => opt.MapFrom(x => true));
            CreateMap<Invoice, InvoiceDto>();


            CreateMap<InvoiceProduct, InvoiceProductDto>();
            CreateMap<Invoice, InvoiceDetailDto>();
        }
    }
}
