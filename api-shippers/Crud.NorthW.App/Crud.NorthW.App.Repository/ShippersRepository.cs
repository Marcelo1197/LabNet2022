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
    public class ShippersRepository : Repository<Shippers>, IShippersRepository
    {
        public ShippersRepository(NorthwindContext context) : base(context)
        {
        }
    }
}
