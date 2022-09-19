using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtExcepUT.Front
{
    public class Menu
    {
        private int OpcionElegida;
        private string[] Opciones;
        private string Instrucciones;

        public Menu(string instrucciones, string[] opciones)
        {
            Instrucciones = instrucciones;
            Opciones = opciones;
            OpcionElegida = 0;
            
        }

        private void mostrarOpciones()
        {
            string opcionActual;
            string prefijo;

            Console.WriteLine(Instrucciones);
            for (int i = 0; i < Opciones.Length; i++)
            {
                opcionActual = Opciones[i];
                if (i == OpcionElegida)
                {
                    prefijo = "*";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;   
                }
                else
                {
                    prefijo = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"{prefijo} <<< {opcionActual} >>>"); 
            }
            Console.ResetColor();
        }

        public int Ejecutar()
        {
            ConsoleKey teclaPresionada;
            do
            {
                Console.Clear();
                mostrarOpciones();

                ConsoleKeyInfo infoTecla = Console.ReadKey(true);
                teclaPresionada = infoTecla.Key;
                if (teclaPresionada == ConsoleKey.UpArrow)
                {
                    OpcionElegida--;
                    if (OpcionElegida == -1)
                    {
                        OpcionElegida = Opciones.Length - 1;
                    }
                }
                else if (teclaPresionada == ConsoleKey.DownArrow)
                {
                    OpcionElegida++;
                    if (OpcionElegida == Opciones.Length)
                    {
                        OpcionElegida = 0;
                    }
                }

            } while (teclaPresionada != ConsoleKey.Enter);

            return OpcionElegida;
        }
    }
}
