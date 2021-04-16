using Car.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Entities.Dtos.InvoiceDtos
{
    public class InvoiceAddDto
    {
        [DisplayName("Fatura Açıklaması")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden az olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Ödeme Tipi")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden az olmamalıdır.")]
        public string Payment { get; set; }

        [DisplayName("Fatura Kesim Tarihi")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public DateTime InvoiceDate { get; set; }

        [DisplayName("Müşteri")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<InvoiceProduct> InvoiceProducts { get; set; }
    }
}
