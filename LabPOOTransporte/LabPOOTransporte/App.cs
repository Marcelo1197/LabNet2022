using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LabPOOTransporte.Entidades;

namespace LabPOOTransporte
{
    public class App
    {
        private const int TAXI = 1;
        private const int OMNIBUS = 2;

        private List<TransportePublico> TransportesPublicos = new List<TransportePublico>();

        public void Ejecutar()
        {
            Console.WriteLine("\t##### App TAXIS & Omnibus #####");
            Console.WriteLine("\t¿Qué hace?\n\tLlena 5 taxis con pasajeros y 5 ómnibus con pasajeros y los muestra en una lista.\n\n");

            // Carga de datos
            Console.WriteLine("Ingrese un número: 1 o 2, según qué tipo de transporte llenar primero:\n01- Taxi\n02- Ómnibus");
            int transporteElegido = Convert.ToInt16(Console.ReadLine());
            if (transporteElegido == TAXI)
            {
                LlenarColeccionTransporte(TAXI);
                Console.WriteLine("\nA continuación llene los ÓMNIBUS con pasajeros.");
                LlenarColeccionTransporte(OMNIBUS);
            }

            if (transporteElegido == OMNIBUS)
            {
                LlenarColeccionTransporte(OMNIBUS);
                Console.WriteLine("\nA continuación llene los TAXIS con pasajeros.");
                LlenarColeccionTransporte(TAXI);
            }

            // Muestra datos cargados
            Console.WriteLine("\n\nLista de Taxis y Omnibus con su número de pasajeros por vehículo:\n");
            foreach (TransportePublico transporte in TransportesPublicos)
            {
                Console.WriteLine($"{transporte.GetType().Name}: {transporte.CantPasajeros}");
            }

        }

        private void LlenarColeccionTransporte(int TipoTransporte)
        {
            if (TipoTransporte == 1)
            {
                int cantPasajerosTaxi = 0;
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Ingrese la cantidad de pasajeros para el Taxi N{i + 1}:");
                    cantPasajerosTaxi = Convert.ToInt16(Console.ReadLine());
                    TransportesPublicos.Add(new Taxi(cantPasajerosTaxi));
                }

            }

            if (TipoTransporte == 2)
            {
                int cantPasajerosOmnibus = 0;
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Ingrese la cantidad de pasajeros para el Omnibus N{i + 1}:");
                    cantPasajerosOmnibus = Convert.ToInt16(Console.ReadLine());
                    TransportesPublicos.Add(new Omnibus(cantPasajerosOmnibus));
                }
            }
        }


    }
}
