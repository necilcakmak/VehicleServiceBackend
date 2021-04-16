using AutoMapper;
using Car.Entities.Concrete;
using Car.Entities.Dtos.VehicleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Service.AutoMapper
{
    public class VehicleProfile:Profile
    {
        public VehicleProfile()
        {
            CreateMap<VehicleAddDto, Vehicle>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(x => true));
            CreateMap<Vehicle, VehicleDto>();

        }
    }
}
