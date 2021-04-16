using Car.Data.Abstract;
using Car.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarContext _context;
        private CustomerRepository _customerRepository;
        private CompanyPersonRepository _companyPersonRepository;
        private InvoiceProductRepository _ınvoiceProductRepository;
        private InvoiceRepository _ınvoiceRepository;
        private VehicleRepository _vehicleRepository;
        private VehiclePartRepository _vehiclePartRepository;

        public UnitOfWork(CarContext Context)
        {
            _context = Context;
        }
        public ICustomerRepository Customers => _customerRepository ?? new CustomerRepository(_context);

        public ICompanyPersonRepository CompanyPersons => _companyPersonRepository ?? new CompanyPersonRepository(_context);

        public IVehicleRepository Vehicles => _vehicleRepository ?? new VehicleRepository(_context);

        public IVehiclePartRepository VehicleParts => _vehiclePartRepository ?? new VehiclePartRepository(_context);

        public IInvoiceRepository Invoices => _ınvoiceRepository ?? new InvoiceRepository(_context);

        public IInvoiceProductRepository InvoiceProducts => _ınvoiceProductRepository ?? new InvoiceProductRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
