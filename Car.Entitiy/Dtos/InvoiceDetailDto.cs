using Car.Entities.Concrete;
using Car.Entities.Dtos.InvoiceProductDtos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Car.Entities.Dtos
{

    public class InvoiceDetailDto
    {

        public string Description { get; set; }
        public string Payment { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string CompanyPersonName { get; set; }

        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAdress { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public ICollection<InvoiceProductDto> InvoiceProducts { get; set; }


        [JsonIgnore]
        public Customer Customer
        {
            get;
        }

        public void setCustomer(Customer customer)
        {
            this.CustomerName = customer.Name;
            this.CustomerAdress = customer.Adress;
            this.CustomerEmail = customer.Email;
            this.CustomerPhoneNumber = customer.PhoneNumber;
        }

        [JsonIgnore]
        public CompanyPerson CompanyPerson
        {
            get;
        }

        public void setCompanyPerson(CompanyPerson companyPerson)
        {
            this.CompanyPersonName = companyPerson.Name;
           
        }


    }
}
