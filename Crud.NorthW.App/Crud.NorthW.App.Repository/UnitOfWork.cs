using Crud.NorthW.App.Data;
using Crud.NorthW.App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.NorthW.App.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NorthwindContext _context;

        public IShippersRepository ShippersR { get; private set; }

        public ICustomerRepository CustomersR { get; private set; }

        public UnitOfWork(NorthwindContext context)
        {
            _context = context;
            ShippersR = new ShippersRepository(_context);
            CustomersR = new CustomerRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
