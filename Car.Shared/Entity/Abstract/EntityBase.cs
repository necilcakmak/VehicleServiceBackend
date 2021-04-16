using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Shared.Entity.Abstract
{
    public abstract class EntityBase
    {
        public  int Id { get; set; }
        public  bool IsActive { get; set; } 
        public  DateTime CreatedDate { get; set; } 
        public  DateTime ModifiedDate { get; set; } 

    }
}
