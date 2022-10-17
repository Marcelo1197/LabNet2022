using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crud.NorthW.App.WebAPI.Models
{
    public class ShippersResponse
    {
        public int ShipperID { get; set; }

        public string CompanyName { get; set; }

        public string Phone { get; set; }
    }
}