using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.NorthW.App.Common.Exceptions
{
    public class InvalidStringException : Exception
    {
        public InvalidStringException() : base("Ingresó números o no ingresó nada, debe ingresar un cadena.") { }    
    }
}
