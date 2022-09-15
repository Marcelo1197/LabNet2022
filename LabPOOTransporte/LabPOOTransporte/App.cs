using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LabPOOTransporte.Entidades;
using LabPOOTransporte.Excepciones;

namespace LabPOOTransporte
{
    public class App
    {
        private const int Taxi = 1;
        private const int Omnibus = 2;
        private const int MaximoPasajeros = 5;

        private List<TransportePublico> TransportesPublicos = new List<TransportePublico>();

        public void Ejecutar()
        {
            Console.WriteLine("\t##### App TAXIS & Omnibus #####");
            Console.WriteLine("\t¿Qué hace?\n\tLlena 5 taxis con pasajeros y 5 ómnibus con pasajeros y los muestra en una lista.\n\n");

            try
            {
                Console.WriteLine("Ingrese un número: 1 o 2, según qué tipo de transporte llenar primero:\n01- Taxi\n02- Ómnibus");
                int transporteElegido = Convert.ToInt16(Console.ReadLine());
                if (DatoEntradaValido(transporteElegido) is false)
                {
                    throw new ExInputTipoTransporte();
                }
                if (transporteElegido == Taxi)
                {
                    LlenarColeccionTransporte(Taxi);
                    Console.WriteLine("\nA continuación llene los ÓMNIBUS con pasajeros.");
                    LlenarColeccionTransporte(Omnibus);
                }
                if (transporteElegido == Omnibus)
                {
                    LlenarColeccionTransporte(Omnibus);
                    Console.WriteLine("\nA continuación llene los TAXIS con pasajeros.");
                    LlenarColeccionTransporte(Taxi);
                }
                MostrarColeccionTransporte();
            }
            catch(ExInputTipoTransporte ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void LlenarColeccionTransporte(int TipoTransporte)
        {
            if (TipoTransporte == 1)
            {
                int cantPasajerosTaxi = 0;
                for (int i = 0; i < MaximoPasajeros; i++)
                {
                    Console.WriteLine($"Ingrese la cantidad de pasajeros para el Taxi N{i + 1}:");
                    cantPasajerosTaxi = Convert.ToInt16(Console.ReadLine());
                    TransportesPublicos.Add(new Taxi(cantPasajerosTaxi));
                }

            }

            if (TipoTransporte == 2)
            {
                int cantPasajerosOmnibus = 0;
                for (int i = 0; i < MaximoPasajeros; i++)
                {
                    Console.WriteLine($"Ingrese la cantidad de pasajeros para el Omnibus N{i + 1}:");
                    cantPasajerosOmnibus = Convert.ToInt16(Console.ReadLine());
                    TransportesPublicos.Add(new Omnibus(cantPasajerosOmnibus));
                }
            }
        }

        private void MostrarColeccionTransporte()
        {
            Console.WriteLine("\n\nLista de Taxis y Omnibus con su número de pasajeros por vehículo:\n");
            foreach (TransportePublico transporte in TransportesPublicos)
            {
                Console.WriteLine($"{transporte.GetType().Name}: {transporte.CantPasajeros}");
            }
        }

        private bool DatoEntradaValido(int input)
        {
            return (input != 1 && input != 2) ? false : true;
        }


    }
}
