using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Entities.Dtos.VehicleDtos
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
