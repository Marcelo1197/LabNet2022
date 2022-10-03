using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Queries.Dto
{
    public class CustomerWithOrdersDto
    {
        public string CustomerID { get; set; }

        public string CompanyName { get; set; }

        public string Region { get; set; }

        public int RelatedOrders { get; set; }

        public DateTime? OrderDate { get; set; }
    }
}
