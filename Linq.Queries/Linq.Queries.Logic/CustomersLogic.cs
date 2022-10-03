using Linq.Queries.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Queries.Logic
{
    public class CustomersLogic : BaseLogic
    {
        public CustomerDTO unObjetoCustomer() //Query #1
        {
            return _context.Customers
                .Select(c => new CustomerDTO
                {
                    CustomerID = c.CustomerID,
                    CompanyName = c.CompanyName
                })
                .FirstOrDefault();
        }

        public IQueryable<CustomerDTO> customersRegionWa() //Query #4
        {
            return _context.Customers
                .Where(c => c.Region == "WA")
                .Select(c => new CustomerDTO
                {
                    CustomerID = c.CustomerID,
                    CompanyName = c.CompanyName,
                    Region = c.Region
                });
        }

        public IQueryable<CustomerDTO> customersMayusculasMinusculas() // Query #6
        {
            return _context.Customers
                .Select(c => new CustomerDTO
                {
                    CompanyName = c.ContactName
                });
        }

        public IQueryable<CustomerWithOrdersDto> customersFiltradosRegionYfechaOrden() // Query #7
        {
            var fechaMinimaOrder = new DateTime(1997, 1, 1);
            return from o in _context.Orders
                   join c in _context.Customers
                   on new { o.CustomerID }
                   equals new { c.CustomerID }
                   where o.OrderDate > fechaMinimaOrder && c.Region == "WA"
                   select new CustomerWithOrdersDto
                   {
                       CustomerID = c.CustomerID,
                       CompanyName = c.CompanyName,
                       Region = c.Region,
                       OrderDate = o.OrderDate
                   };
        }

        public IQueryable<CustomerDTO> primerosTresCustomers()
        {
            var queryPrimeros3CustomersWA = (from c in _context.Customers
                                             where c.Region == "WA"
                                             select new CustomerDTO
                                             {
                                                 CustomerID = c.CustomerID,
                                                 CompanyName = c.CompanyName,
                                                 Region = c.Region
                                             }).Take(3);
            return queryPrimeros3CustomersWA;
        }

        public IQueryable<CustomerWithOrdersDto> customersCantidadOrdenesAsociadas() // Query para devolver los customer con la cantidad de ordenes asociadas"
        {
            var queryCustomersConOrders = from o in _context.Orders
                                          join c in _context.Customers
                                          on new { o.CustomerID }
                                          equals new { c.CustomerID }
                                          select new CustomerWithOrdersDto
                                          {
                                              CustomerID = c.CustomerID,
                                              CompanyName = c.ContactName,
                                             
                                          };

        var query = from c in _context.Customers
                    join o in _context.Orders
                    on new { c.CustomerID }
                    equals new { o.CustomerID }
                    group c by o.CustomerID into Ordenes
                    select new CustomerWithOrdersDto
                    {
                        CustomerID = Ordenes.Key,
                        RelatedOrders = Ordenes.Count()
                    };

            return query;
        }
    }
}
