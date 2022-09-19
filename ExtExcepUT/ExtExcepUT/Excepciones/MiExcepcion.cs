using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtExcepUT.Excepciones
{
    public class MiExcepcion : Exception
    {
        public MiExcepcion() : base("Excepcion personalizada :)") { }
    }
}
