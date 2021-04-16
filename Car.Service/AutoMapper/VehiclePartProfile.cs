using AutoMapper;
using Car.Entities.Concrete;
using Car.Entities.Dtos.VehiclePartsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Service.AutoMapper
{
    public class VehiclePartProfile: Profile
    {
        public VehiclePartProfile()
        {
            CreateMap<VehiclePartAddDto, VehiclePart>()
               .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now))
               .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now))
               .ForMember(dest => dest.IsActive, opt => opt.MapFrom(x => true));
            CreateMap<VehiclePart, VehiclePartDto>();
        }
    }
}
