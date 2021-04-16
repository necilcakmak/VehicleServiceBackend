using Car.Entities.Concrete;
using Car.Entities.Dtos.VehiclePartsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Car.Entities.Dtos.InvoiceProductDtos
{
    public class InvoiceProductDto
    {
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalTax { get; set; }
        public decimal SubTotal { get; set; }
        public string ItemDescription { get; set; }
        public int VehiclePartId { get; set; }

        [JsonIgnore]
        public VehiclePartDto VehiclePart
        {
            get
            {
                return null;
            }
            set
            {
                this.ItemDescription = value.Vehicle.Brand + " "
                + value.Vehicle.Model + " "
                + value.PartType + " Parça Kodu:"
                + value.PartCode;
            }
        }


    }
}
