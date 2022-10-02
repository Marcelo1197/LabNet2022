using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class InvalidOptionMenuException : Exception
    {
        public InvalidOptionMenuException() : base("Ingresaste un valor distinto a 1 o 5. Solo se admiten los enteros 1 (uno) o 5 (cinco).")
        {

        }

    }
}
