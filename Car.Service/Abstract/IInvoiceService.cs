using Car.Entities.Concrete;
using Car.Entities.Dtos;
using Car.Entities.Dtos.InvoiceDtos;
using Car.Shared.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Service.Abstract
{
    public interface IInvoiceService
    {
        Task<IDataResult<InvoiceDetailDto>> Get(int ınvoiceId);
        Task<IDataResult<IList<InvoiceDto>>> GetAll();
        Task<IDataResult<IList<InvoiceDto>>> GetLastAll();
        Task<IResult> Add(InvoiceAddDto ınvoice);
        Task<InvoiceAddDto> Calculate(InvoiceAddDto ınvoice);
        Task<IDataResult<Invoice>> Update(Invoice ınvoice);
        Task<IResult> Delete(int ınvoiceId);
        Task<IList<InvoiceProduct>> GetInvoiceProduct(int invoiceId);
    }
}
