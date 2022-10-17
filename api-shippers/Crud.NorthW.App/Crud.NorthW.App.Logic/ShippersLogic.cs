using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crud.NorthW.App.Data;
using Crud.NorthW.App.Entities;
using Crud.NorthW.App.Repository;

namespace Crud.NorthW.App.Logic
{
    public class ShippersLogic: BaseLogic
    {
        private UnitOfWork unitOfWork;

        public ShippersLogic()
        {
            unitOfWork = new UnitOfWork(_context);
        }

        //Constructor for UnitTest with Moq 
        public ShippersLogic(NorthwindContext context) { }

        public Shippers Get(int Id)
        {
            var shipperFinded = unitOfWork.ShippersR.Get(Id);
            return shipperFinded;
        }

        public IEnumerable<Shippers> GetAll()
        {
            var shipperList = unitOfWork.ShippersR.GetAll();
            return shipperList;
        }

        public void Add(Shippers shipper)
        {
            unitOfWork.ShippersR.Add(shipper);
            unitOfWork.Complete();
        }

        public void Update(Shippers shipper)
        {
            var modifiedShipper = Get(shipper.ShipperID);
            modifiedShipper.CompanyName = shipper.CompanyName;
            modifiedShipper.Phone = shipper.Phone;
            unitOfWork.Complete();
        }

        public void Delete(Shippers shipper)
        {
            unitOfWork.ShippersR.Delete(shipper);
            unitOfWork.Complete();
        }
    }
}
