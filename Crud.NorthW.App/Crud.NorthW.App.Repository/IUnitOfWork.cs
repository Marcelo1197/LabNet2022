using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.NorthW.App.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IShippersRepository ShippersR { get;}

        ICustomerRepository CustomersR { get;}

        int Complete();
    }
}
