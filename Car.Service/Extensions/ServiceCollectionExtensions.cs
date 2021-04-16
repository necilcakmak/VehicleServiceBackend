using Car.Data.Abstract;
using Car.Data.Concrete;
using Car.Data.Context;
using Car.Service.Abstract;
using Car.Service.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Service.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<CarContext>(
                options => options.UseSqlServer(
                    connectionString,
                    b => b.MigrationsAssembly("Car.Api"))
                    );

            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ICustomerService, CustomerService>();
            serviceCollection.AddScoped<IVehicleService, VehicleService>();
            serviceCollection.AddScoped<IVehiclePartService, VehiclePartService>();
            serviceCollection.AddScoped<IInvoiceService, InvoiceService>();
            serviceCollection.AddScoped<IAuthService, AuthService>();
            return serviceCollection;
        }
       
    }
}
