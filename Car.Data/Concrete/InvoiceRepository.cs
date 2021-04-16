using Car.Data.Abstract;
using Car.Data.Context;
using Car.Entities.Concrete;
using Car.Shared.Data.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Data.Concrete
{
    public class InvoiceRepository : EntityRepository<Invoice>, IInvoiceRepository
    {
        private CarContext carContext { get => _context as CarContext; }
        public InvoiceRepository(DbContext context) : base(context)
        {

        }

        public async Task<IList<Invoice>> GetLastInvoices()
        {
            
            return await carContext.Invoices.OrderByDescending(x=>x.CreatedDate).Take(10).Where(x=>x.IsActive==true).ToListAsync();
        }
    }
}
