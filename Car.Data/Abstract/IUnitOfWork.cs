using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Data.Abstract
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        ICustomerRepository Customers { get; }
        ICompanyPersonRepository CompanyPersons { get; }
        IVehicleRepository Vehicles{ get; }
        IVehiclePartRepository VehicleParts { get; }
        IInvoiceRepository Invoices { get; }
        IInvoiceProductRepository InvoiceProducts { get; }
        Task<int> SaveAsync();
    }
}
