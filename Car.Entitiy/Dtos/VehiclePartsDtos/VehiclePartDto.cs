using Car.Entities.Concrete;
using Car.Entities.Dtos.VehicleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Entities.Dtos.VehiclePartsDtos
{
    public class VehiclePartDto
    {
        public int Id { get; set; }
        public string PartType { get; set; }
        public string PartCode { get; set; }
        public int Stock { get; set; }
        public decimal TaxRate { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public string TaxStatus { get; set; }
        public int VehicleId { get; set; }
        public VehicleDto Vehicle { get; set; }
    }
}
