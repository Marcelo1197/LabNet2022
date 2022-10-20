using Crud.NorthW.App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crud.NorthW.App.Data;

namespace Crud.NorthW.App.Repository
{
    public class OrdersRepository : Repository<Orders>, IOrdersRepository
    {
        public OrdersRepository(NorthwindContext _context) : base(_context)
        {

        }

        public List<Orders> FindOrdersByShipperId(int idShipper)
        {
            return this.Context.Set<Orders>()
                .Where(o => o.ShipVia == idShipper)
                .ToList();
        }

        public void RemoveShipperRelated(int idShipper)
        {
            var ordersToUnlink = this.FindOrdersByShipperId(idShipper);
            foreach (var order in ordersToUnlink)
            {
                order.ShipVia = null;
            }
        }
    }
}
