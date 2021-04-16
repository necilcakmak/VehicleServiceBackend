using Car.Shared.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Entities.Concrete
{
    public class Vehicle:EntityBase,IEntity
    {
        public string Model { get; set; }
        public string Brand { get; set; }
    }
}
