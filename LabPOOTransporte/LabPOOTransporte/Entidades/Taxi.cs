using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabPOOTransporte.Entidades
{
    internal class Taxi : TransportePublico
    {  
        public Taxi(int cantPasajeros) : base(cantPasajeros)
        {

        }

        public override void Avanzar()
        {
            throw new NotImplementedException();
        }

        public override void Detenerse()
        {
            throw new NotImplementedException();
        }
    }
}
