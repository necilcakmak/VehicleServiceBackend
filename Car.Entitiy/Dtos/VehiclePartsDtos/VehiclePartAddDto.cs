using Car.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Entities.Dtos.VehiclePartsDtos
{
    public class VehiclePartAddDto
    {
        public int Id { get; set; }

        [DisplayName("Parça Tipi")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden az olmamalıdır.")]
        public string PartType { get; set; }

        [DisplayName("Parça Kodu")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(15, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden az olmamalıdır.")]
        public string PartCode { get; set; }

        [DisplayName("Stok Miktarı")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public int? Stock { get; set; }

        [DisplayName("Vergi Oranı")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]

        public decimal? TaxRate { get; set; }

        [DisplayName("Alış Fiyatı")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public decimal? BuyPrice { get; set; }

        [DisplayName("Satış Fiyatı")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public decimal? SellPrice { get; set; }

        [DisplayName("Vergi Durumu")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public string TaxStatus { get; set; }

        [DisplayName("Hangi Aracın?")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public int? VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
