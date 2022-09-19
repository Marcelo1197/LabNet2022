using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtExcepUT.Excepciones
{
    public class ExcepDivisionCero : Exception
    {
        public ExcepDivisionCero() : base("Error, no se puede realizar una división por cero.") { }
    }
}
