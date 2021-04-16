using AutoMapper;
using Car.Data.Abstract;
using Car.Entities.Concrete;
using Car.Entities.Dtos;
using Car.Entities.Dtos.InvoiceDtos;
using Car.Service.Abstract;
using Car.Shared.Result.Abstract;
using Car.Shared.Result.Concrete;
using Car.Shared.Result.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Service.Concrete
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InvoiceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<InvoiceAddDto> Calculate(InvoiceAddDto invoiceAddDto)
        {
            foreach (var i in invoiceAddDto.InvoiceProducts)
            {
                var vehiclePart = await _unitOfWork.VehicleParts.GetAsync(x => x.Id == i.VehiclePartId);
                vehiclePart.Stock -= i.Quantity;
                var totalTax = vehiclePart.TaxRate * vehiclePart.SellPrice * i.Quantity / 100;
                var subTotal = vehiclePart.SellPrice * i.Quantity;
                var totalPrice = totalTax + subTotal;
                i.TotalPrice = totalPrice;
                i.SubTotal = subTotal;
                i.TotalTax = totalTax;
                await _unitOfWork.VehicleParts.UpdateAsync(vehiclePart);
                await _unitOfWork.SaveAsync();
            }

            return invoiceAddDto;
        }

        public async Task<IResult> Add(InvoiceAddDto invoiceAddDto)
        {
            var calculatedData = await Calculate(invoiceAddDto);
            var ınvoice = _mapper.Map<Invoice>(calculatedData);
            ınvoice.CompanyPersonId = 1;
            await _unitOfWork.Invoices.AddAsync(ınvoice);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, "Kayıt Oluşturuldu");
        }

        public async Task<IResult> Delete(int ınvoiceId)
        {
            var result = await _unitOfWork.Invoices.AnyAsync(a => a.Id == ınvoiceId);
            if (result)
            {
                var ınvoice = await _unitOfWork.Invoices.GetAsync(a => a.Id == ınvoiceId);

                ınvoice.IsActive = false;
                await _unitOfWork.Invoices.UpdateAsync(ınvoice);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Kayıt Silindi.");
            }
            return new Result(ResultStatus.Error, "Kayıt Bulunamadı.");
        }

        public async Task<IDataResult<InvoiceDetailDto>> Get(int ınvoiceId)
        {
            var ınvoice = await _unitOfWork.Invoices.GetAsync(c => c.Id == ınvoiceId, c => c.Customer, c => c.CompanyPerson, c => c.InvoiceProducts);
            var invoicesProduct = await GetInvoiceProduct(ınvoiceId);
            if (ınvoice != null)
            {
                if (invoicesProduct != null)
                {
                    ınvoice.InvoiceProducts = invoicesProduct;
                }
                return new DataResult<InvoiceDetailDto>(ResultStatus.Success, _mapper.Map<InvoiceDetailDto>(ınvoice));
            }
            return new DataResult<InvoiceDetailDto>(ResultStatus.Error, "Böyle bir fatura bulunamadı", null);
        }

        public async Task<IDataResult<IList<InvoiceDto>>> GetAll()
        {
            var ınvoices = await _unitOfWork.Invoices.GetAllAsync(x => x.IsActive == true, v => v.Customer, v => v.CompanyPerson);

            if (ınvoices.Count > -1)
            {
                return new DataResult<List<InvoiceDto>>(ResultStatus.Success, _mapper.Map<List<InvoiceDto>>(ınvoices));
            }
            return new DataResult<List<InvoiceDto>>(ResultStatus.Error, "Fatura  bulunamadı.", null);
        }
        public async Task<IDataResult<IList<InvoiceDto>>> GetLastAll()
        {
            var ınvoices = await _unitOfWork.Invoices.GetLastInvoices();

            if (ınvoices.Count > -1)
            {
                return new DataResult<List<InvoiceDto>>(ResultStatus.Success, _mapper.Map<List<InvoiceDto>>(ınvoices));
            }
            return new DataResult<List<InvoiceDto>>(ResultStatus.Error, "Fatura  bulunamadı.", null);
        }

        public async Task<IList<InvoiceProduct>> GetInvoiceProduct(int invoiceId)
        {
            var ınvoicesProduct = await _unitOfWork.InvoiceProducts.GetAllAsync(v => v.InvoiceId == invoiceId, v => v.VehiclePart, v => v.VehiclePart.Vehicle);
            return ınvoicesProduct;
        }

        public async Task<IDataResult<Invoice>> Update(Invoice ınvoice)
        {
            throw new NotImplementedException();
        }
    }
}
