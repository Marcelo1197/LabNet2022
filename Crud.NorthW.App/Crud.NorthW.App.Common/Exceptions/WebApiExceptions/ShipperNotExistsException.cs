using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.NorthW.App.Common.Exceptions.WebApiExceptions
{
    public class ShipperNotExistsException : Exception
    {
        public ShipperNotExistsException() : base("El shipper que solicitó no existe. Intente con otro por favor.")
        {

        }
    }
}
