using Car.Shared.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Entities.Concrete
{
    public class InvoiceProduct:EntityBase,IEntity
    {
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalTax { get; set; }
        public decimal SubTotal { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public int VehiclePartId { get; set; }
        public VehiclePart VehiclePart { get; set; }
    }
}
