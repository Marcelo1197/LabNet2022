using Crud.NorthW.App.Entities;
using Crud.NorthW.App.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.NorthW.App.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mostramos lista de Customers");
            CustomerLogic cl = new CustomerLogic();
            List<Customers> customersList = cl.GetAll();

            foreach (var customer in customersList)
            {
                Console.WriteLine($"\nID: {customer.CustomerID}\nCompañia: {customer.CompanyName}\nNombre de contacto:{customer.ContactName}\n");
            }
            Console.ReadKey();
        }
    }
}
