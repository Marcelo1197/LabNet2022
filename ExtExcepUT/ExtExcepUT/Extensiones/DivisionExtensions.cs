using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtExcepUT.Extensiones
{
    public static class DivisionExtensions
    {
        public static decimal DividirPor(this decimal dividendo, decimal divisor)
        {
            decimal resultado = 0;
            try
            {
                resultado = dividendo / divisor;
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine("\n¡Solo Chuck Norris divide por cero!");
                Console.WriteLine($"[{ex.Message}]\n");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return resultado;
        }
    }
}
