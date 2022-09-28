using Crud.NorthW.App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.NorthW.App.Repository
{
    public interface ICustomerRepository : IRepository<Customers>
    {
        Customers Get(string id);
    }
}
