using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabPOOTransporte.Servicios
{
    static class ApiPatente
    {
        private static Random random = new Random();
        private static  int longitudPatente = 7;

        public static string GenerarPatenteRandom()
        {
            string caracteres = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789";
            string patenteRandom = new string(
                Enumerable.Repeat(caracteres, longitudPatente)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());

            return patenteRandom;
        }
    }
}
