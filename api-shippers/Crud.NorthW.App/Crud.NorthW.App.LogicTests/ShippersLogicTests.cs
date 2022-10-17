using Microsoft.VisualStudio.TestTools.UnitTesting;
using Crud.NorthW.App.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Data.Entity;
using Crud.NorthW.App.Entities;
using Crud.NorthW.App.Data;

namespace Crud.NorthW.App.Logic.Tests
{
    [TestClass()]
    public class ShippersLogicTests
    {
        [TestMethod()]
        public void GetTest()
        {
            // Arrange
            var shipperId = 1;
            var shipperCompanyName = "Sanchez SA";
            var shipperPhone = "373453433";
            var shipperMock = new Shippers
            {
                ShipperID = shipperId,
                CompanyName = shipperCompanyName,
                Phone = shipperPhone
            };

            var mockSet = new Mock<DbSet<Shippers>>();
            var mockContext = new Mock<NorthwindContext>();
            mockContext.Setup(mock => mock.Shippers).Returns(mockSet.Object);
            ShippersLogic sl = new ShippersLogic(mockContext.Object);



            Assert.Fail();
        }
    }
}