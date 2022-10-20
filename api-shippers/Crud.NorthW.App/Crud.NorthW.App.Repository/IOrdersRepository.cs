using Crud.NorthW.App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.NorthW.App.Repository
{
    public interface IOrdersRepository : IRepository<Orders>
    {
        List<Orders> FindOrdersByShipperId(int idShipper);
        void RemoveShipperRelated(int id);
    }
}
