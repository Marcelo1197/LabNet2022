using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExtExcepUT.Excepciones;
using ExtExcepUT.Extensiones;

namespace ExtExcepUT.Front
{
    public static class Opcion {
        public static int Continuar = 1;
        public static int Salir = 4;
    }

    public class App
    {
        private int ejercicioElegido;
        private string[] Ejercicios = new string[] { "Ejercicio 1", "Ejercicio 2", "Ejercicio 3", "Ejercicio 4", "SALIR"};
        private string introduccion = "Aplicación que resuelve los 4 ejercicios aplicando los siguientes conceptos:\nExtension Methods y Exceptions.";
        private string instrucciones = "Elija el Ejercicio que quiera ver (muevase con las Flechitas y presione Enter)";

        public void Ejecutar()
        {
            var menu = new Menu($"{introduccion}\n{instrucciones}\n", Ejercicios);
            do
            {
                ejercicioElegido = menu.Ejecutar();
                if (ejercicioElegido == 0)
                {
                    ArrojarExcepDivisionCero();
                }
                else if (ejercicioElegido == 1)
                {
                    ChuckNorrisDivision();
                }
                else if (ejercicioElegido == 2)
                {
                    ExcepcionesDesdeLogic(2);
                }
                else if (ejercicioElegido == 3)
                {
                    ExcepcionesDesdeLogic(3);
                }

                if (ejercicioElegido != 4)
                {
                    try
                    {
                        Console.WriteLine("¿Continuar con otros ejercicios o salir?\n01-CONTINUAR\n02-SALIR");
                        ejercicioElegido = (Convert.ToInt32(Console.ReadLine()) == 1) ? Opcion.Continuar : Opcion.Salir;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("No ingresaste nada o ingresaste una letra. Solo ingresa los enteros 1 o 2");
                        Console.WriteLine("¿Continuar con otros ejercicios o salir?\n01-CONTINUAR\n02-SALIR");
                        ejercicioElegido = (Convert.ToInt32(Console.ReadLine()) == 1) ? Opcion.Continuar : Opcion.Salir;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("No ingresaste nada o ingresaste una letra. Solo ingresa los enteros 1 o 2");
                        Console.WriteLine("¿Continuar con otros ejercicios o salir?\n01-CONTINUAR\n02-SALIR");
                        ejercicioElegido = (Convert.ToInt32(Console.ReadLine()) == 1) ? Opcion.Continuar : Opcion.Salir;
                    }
                }
            } while (ejercicioElegido != 4);
            Console.WriteLine("\n\nFIN DEL PROGRAMA");
        }

        public void ArrojarExcepDivisionCero()
        {
            Console.WriteLine("Ingrese un numero cualquiera. El mismo se intentará dividir por cero y se arrojará una excepción.");
            decimal resultado;

            try
            {
                decimal numeroIngresado = Convert.ToDecimal(Console.ReadLine());
                resultado = numeroIngresado / 0;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("No ingresaste nada o ingresaste una letra/Palabra. Solo debes ingresar numeros.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("\nOperación finalizada.\n[Fin Ejercicio 1]\n");
            }

        }

        public void ChuckNorrisDivision()
        {
            Console.WriteLine("Ingrese dos numeros para ser divididos. Si el divisor es 0, se mostrará un mensaje de Chuck Norris ;), caso contrario solo el resultado.");
            try
            {
                Console.WriteLine("Ingrese el dividendo");
                decimal dividendo = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Ingrese el divisor");
                decimal divisor = Convert.ToDecimal(Console.ReadLine());
                decimal resultado = dividendo.DividirPor(divisor);
                if (divisor != 0)
                {
                    Console.WriteLine($"\nResultado: {Decimal.Round(resultado, 2)}");
                } 
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Seguro Ingreso una letra o no ingreso nada!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("[Fin ejercicio 2.]\n");
            }         
        }

        public void ExcepcionesDesdeLogic(int ejercicioElegido)
        {
            try
            {
                if (ejercicioElegido == 2)
                {
                    Logic.ArrojarExcepcion();
                }
                if (ejercicioElegido == 3)
                {
                    Logic.ArrojarExcepcionPersonalizada();
                }
            }
            catch(SystemException ex)
            {
                Console.WriteLine($"\nTipo de excepcion: {ex.GetType().Name}");
                Console.WriteLine($"Mensaje: {ex.Message}\n");  
            }
            catch(MiExcepcion ex)
            {
                Console.WriteLine($"\nTipo de excepcion:{ex.GetType().Name}");
                Console.WriteLine($"Mensaje: {ex.Message}\n");
            }
            finally
            {
                Console.WriteLine($"Fin del Ejercicio {(ejercicioElegido == 2 ? "3" : "4")}\n");
            }
        }


    }
}
