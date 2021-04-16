using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Entities.Dtos.CustomerDtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }      
        public string Email { get; set; }      
        public string PhoneNumber { get; set; }     
        public string TaxNo { get; set; }
        public string Adress { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
