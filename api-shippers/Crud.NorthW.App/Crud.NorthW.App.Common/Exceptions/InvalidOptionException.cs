using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.NorthW.App.Common.Exceptions
{
    public class InvalidOptionException : Exception
    {
        public InvalidOptionException() : base("Ingresaste un valor distinto a 1 o 5. Solo se admiten los enteros 1 (uno) o 5 (cinco).")
        {

        }
    }
}
