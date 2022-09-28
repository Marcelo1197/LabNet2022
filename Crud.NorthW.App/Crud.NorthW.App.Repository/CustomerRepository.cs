using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crud.NorthW.App.Data;
using Crud.NorthW.App.Entities;

namespace Crud.NorthW.App.Repository
{
    public class CustomerRepository : Repository<Customers>, ICustomerRepository
    {
        public CustomerRepository(NorthwindContext context) : base(context)
        {
        }

        public Customers Get(string id)
        {
            return Context.Set<Customers>().Find(id);
        }
    }
}
