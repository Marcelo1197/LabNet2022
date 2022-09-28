using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.NorthW.App.Common.Exceptions
{
    public class OutOfRangeStringException : Exception
    {
        public OutOfRangeStringException(int maxLength) : base($"No se puede ingresar más de {maxLength} caracteres/números. Intente de nuevo.")
        {

        }
    }
}
