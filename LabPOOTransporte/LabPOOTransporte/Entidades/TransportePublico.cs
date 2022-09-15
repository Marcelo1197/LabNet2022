using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabPOOTransporte.Entidades
{
    public abstract class TransportePublico
    {
        public int CantPasajeros { get; set; } = 0;

        public TransportePublico(int cantPasajeros)
        {
            CantPasajeros = cantPasajeros;
        }

        public abstract void Avanzar();
        public abstract void Detenerse();
    }
}
