using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.NorthW.App.Common.Exceptions
{
    public class InvalidPhoneException : Exception
    {
        public InvalidPhoneException() : base("Ingresó una o más letras o no ingresó nada. Solo está permitido ingresar números.") { }
    }
}
