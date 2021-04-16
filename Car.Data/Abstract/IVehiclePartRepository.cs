using Car.Entities.Concrete;
using Car.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Data.Abstract
{
    public interface IVehiclePartRepository:IEntityRepository<VehiclePart>
    {
    }
}
