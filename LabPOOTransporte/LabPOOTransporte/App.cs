using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LabPOOTransporte.Entidades;
using LabPOOTransporte.Excepciones;
using LabPOOTransporte.Servicios;

namespace LabPOOTransporte
{
    public class App
    {
        private const int Taxi = 1;
        private const int MaxPasajerosTaxi = 4;
        private const int Omnibus = 2;
        private const int MaxPasajerosOmnibus = 100;

        private List<TransportePublico> TransportesPublicos = new List<TransportePublico>();

        private bool continuarEjecutando = true;
        public void Ejecutar()
        {
            Console.WriteLine("\t##### App TAXIS & Omnibus #####");
            Console.WriteLine("\t¿Qué hace?\n\tLlena 5 taxis con pasajeros y 5 ómnibus con pasajeros y los muestra en una lista.\n\n");

            while (continuarEjecutando)
            {
                try
                {
                    Console.WriteLine("Ingrese un número: 1 o 2, según qué tipo de transporte llenar primero:\n01- Taxi\n02- Ómnibus");
                    int transporteElegido = Convert.ToInt16(Console.ReadLine());
                    if (TransporteElegidoValido(transporteElegido) is false)
                    {
                        throw new ExInputTipoTransporte();
                    }
                    if (transporteElegido == Taxi)
                    {
                        LlenarColeccionConTaxis();
                        Console.WriteLine("\nA continuación llene los ÓMNIBUS con pasajeros.");
                        LlenarColeccionConOmnibus();
                    }
                    if (transporteElegido == Omnibus)
                    {
                        LlenarColeccionConOmnibus();
                        Console.WriteLine("\nA continuación llene los TAXIS con pasajeros.");
                        LlenarColeccionConTaxis();
                    }
                    MostrarColeccionTransporte();
                    continuarEjecutando = false;
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
        }
        private void LlenarColeccionConTaxis()
        {
            int cantPasajerosTaxi;
            int i = 0;

            while (i < 5)
            {
                Console.WriteLine($"Ingrese la cantidad de pasajeros para el Taxi N{i + 1}:");
                try
                {
                    cantPasajerosTaxi = Convert.ToInt32(Console.ReadLine());
                    if (cantPasajerosTaxi <= 0)
                    {
                        Console.WriteLine("Ingresó un numero negativo o 0. Mínimo debe ingresar 1 pasajero.");
                    }
                    if (CantPasajerosValida(cantPasajerosTaxi, Taxi))
                    {
                        TransportesPublicos.Add(new Taxi(cantPasajerosTaxi, ApiPatente.GenerarPatenteRandom()));
                        i++;
                    }
                    else
                    {
                        Console.WriteLine("No pueden ir más de 4 pasajeros en un Taxi. Intenta de nuevo.");
                    }
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
        private void LlenarColeccionConOmnibus()
        {
            int cantPasajerosOmnibus;
            int i = 0;

            while (i < 5)
            {
                Console.WriteLine($"Ingrese la cantidad de pasajeros para el Omnibus N{i + 1}:");
                try
                {
                    cantPasajerosOmnibus = Convert.ToInt32(Console.ReadLine());
                    if (cantPasajerosOmnibus <= 0)
                    {
                        Console.WriteLine("Ingresó un numero negativo o 0. Mínimo debe ingresar 1 pasajero.");
                    }
                    if (CantPasajerosValida(cantPasajerosOmnibus, Omnibus))
                    {
                        TransportesPublicos.Add(new Omnibus(cantPasajerosOmnibus, ApiPatente.GenerarPatenteRandom()));
                        i++;
                    }
                    else
                    {
                        Console.WriteLine("No pueden ir más de 100 pasajeros en un Omnibus. Intenta de nuevo.");
                    }
                }
                catch (ExInputTipoTransporte ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        private void MostrarColeccionTransporte()
        {
            Console.WriteLine("\n\nLista de Taxis y Omnibus con su número de pasajeros por vehículo:\n");
            foreach (TransportePublico transporte in TransportesPublicos)
            {
                Console.WriteLine($"{transporte.GetType().Name} [{transporte.Patente}]: {transporte.CantPasajeros}");
            }
        }

        // Validaciones Input
        public bool TransporteElegidoValido(int input)
        {
            return (input != 1 && input != 2) ? false : true;
        }

        public bool CantPasajerosValida(int inputPasajeros, int tipoTransporte)
        {
            if (tipoTransporte == Taxi)
            {
                return (inputPasajeros <= MaxPasajerosTaxi) ? true : false;
            }
            else
            {
                return (inputPasajeros <= MaxPasajerosOmnibus) ? true : false;
            }
        }


    }
}
