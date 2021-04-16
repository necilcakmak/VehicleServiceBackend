using Car.Shared.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Entities.Concrete
{
    public class Invoice:EntityBase,IEntity
    {
        public string Description { get; set; }
        public string Payment { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int CompanyPersonId { get; set; }
        public CompanyPerson CompanyPerson { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<InvoiceProduct> InvoiceProducts { get; set; }
    }
}
