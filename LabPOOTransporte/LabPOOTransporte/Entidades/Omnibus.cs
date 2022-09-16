using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabPOOTransporte.Entidades
{
    public class Omnibus : TransportePublico
    {
        public Omnibus(int cantPasajeros, string patente) : base(cantPasajeros, patente)
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
