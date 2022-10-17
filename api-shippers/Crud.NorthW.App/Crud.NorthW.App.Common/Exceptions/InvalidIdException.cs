using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.NorthW.App.Common.Exceptions
{
    public class InvalidIdException : Exception
    {
        public InvalidIdException() : base("Ingresó un valor negativo. La ID solo puede ser un entero positivo.") { }
    }
}
