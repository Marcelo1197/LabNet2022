using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExtExcepUT.Excepciones;

namespace ExtExcepUT
{
    public static class Logic
    {
        public static SystemException ArrojarExcepcion()
        {
            throw new SystemException();
        }

        public static MiExcepcion ArrojarExcepcionPersonalizada()
        {
            throw new MiExcepcion();
        }
    }
}
