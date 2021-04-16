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
    public class CompanyPersonRepository : EntityRepository<CompanyPerson>, ICompanyPersonRepository
    {
        private CarContext carContext { get => _context as CarContext; }
        public CompanyPersonRepository(DbContext context) : base(context)
        {
        }
    }
}
