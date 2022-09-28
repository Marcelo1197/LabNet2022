using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Crud.NorthW.App.Entities;
using Crud.NorthW.App.Data;
using Crud.NorthW.App.Repository;

namespace Crud.NorthW.App.Logic
{
    public class CustomerLogic: BaseLogic
    {
        private UnitOfWork unitOfWork;
        
        public CustomerLogic()
        {
            unitOfWork = new UnitOfWork(_context);
        }

        //Constructor for UnitTests with Moq
        public CustomerLogic(NorthwindContext context)
        {

        }

        public Customers Get(string Id)
        {
            var customerFinded = unitOfWork.CustomersR.Get(Id);
            return customerFinded;
        }

        public IEnumerable<Customers> GetAll()
        {
            var customersList = unitOfWork.CustomersR.GetAll();
            return customersList;
        }

        public void Add(Customers customer)
        {
            unitOfWork.CustomersR.Add(customer);
            unitOfWork.Complete();
        }

        public void Update(Customers customer)
        {
            var modifiedCustomer = Get(customer.CustomerID);
            modifiedCustomer.CompanyName = customer.CompanyName;
            modifiedCustomer.ContactName = customer.ContactName;
            modifiedCustomer.Phone = customer.Phone;
            unitOfWork.Complete();

        }

        public void Delete(Customers customer)
        {
            unitOfWork.CustomersR.Delete(customer);
            unitOfWork.Complete();
        }
    }
}
