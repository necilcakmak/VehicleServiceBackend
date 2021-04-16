using Car.Entities.Concrete;
using Car.Entities.Dtos.InvoiceProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Entities.Dtos.InvoiceDtos
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Payment { get; set; }
        public DateTime InvoiceDate { get; set; }

    }
}
