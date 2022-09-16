using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabPOOTransporte.Excepciones
{
    public class ExInputTipoTransporte : Exception
    {
        public ExInputTipoTransporte() : base("El dato ingresado es incorrecto. Debe ingresar el entero 1 o 2. No se aceptan otros tipos ni valores de numeros.")
        {

        }
    }
}
