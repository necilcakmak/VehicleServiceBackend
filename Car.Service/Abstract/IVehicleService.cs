using Car.Entities.Concrete;
using Car.Entities.Dtos.VehicleDtos;
using Car.Shared.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Service.Abstract
{
    public interface IVehicleService
    {
        Task<IDataResult<VehicleDto>> Get(int vehicleId);
        Task<IDataResult<IList<VehicleDto>>> GetAll();
        Task<IResult> Add(VehicleAddDto vehicle);
        Task<IResult> Update(VehicleAddDto vehicleAddDto);
        Task<IResult> Delete(int vehicleId);
    }
}
