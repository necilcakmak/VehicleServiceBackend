using Car.Entities.Concrete;
using Car.Entities.Dtos.VehiclePartsDtos;
using Car.Shared.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Service.Abstract
{
    public interface IVehiclePartService
    {
        Task<IDataResult<VehiclePartDto>> Get(int vehiclePartId);
        Task<IDataResult<IList<VehiclePartDto>>> GetAll();
        Task<IResult> Add(VehiclePartAddDto vehiclePart);
        Task<IResult> Update(VehiclePartAddDto vehiclePart);
        Task<IResult>Delete(int vehiclePartId);
    }
}
