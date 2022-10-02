using Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class InputValidationExtensions
    {
        public static void ValidateOption(this int input)
        {
            int continuarPrograma = 1;
            int salir = 5;

            if (input != continuarPrograma && input != salir)
            {
                throw new InvalidOptionMenuException();
            }
        }
    }
}
