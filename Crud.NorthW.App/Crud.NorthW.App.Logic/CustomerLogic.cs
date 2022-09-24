using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Crud.NorthW.App.Entities;
using Crud.NorthW.App.Data;

namespace Crud.NorthW.App.Logic
{
    public class CustomerLogic
    {
        private NorthwindContext _context;
        
        public CustomerLogic()
        {
            _context = new NorthwindContext();
        }

        public List<Customers> GetAll()
        {
            return _context.Customers.ToList();
        }
    }
}
