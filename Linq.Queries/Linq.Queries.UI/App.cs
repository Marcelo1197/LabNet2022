using Common.Exceptions;
using Common.Extensions;
using Linq.Queries.Data;
using Linq.Queries.Entities;
using Linq.Queries.Logic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Queries.UI
{
    public static class OpcionMenu
    {
        public const int Query1 = 0;
        public const int Query2 = 1;
        public const int Query3 = 2;
        public const int Query4 = 3;
        public const int Query5 = 4;
        public const int Query6 = 5;
        public const int Query7 = 6;
        public const int Query8 = 7;
        public const int Query9 = 8;
        public const int Query10 = 9;
        public const int Query11 = 10;
        public const int Query12 = 11;
        public const int Query13 = 12;
        public const int Salir = 13;
    }
    public class App
    {
        private CustomersLogic cl = new CustomersLogic();
        private ProductsLogic pl = new ProductsLogic();

        private string appIntro = "Aplicación para ejecutar queries con Method Syntax y Query Syntax de LINQ.\n\n";
        private string appInstrucctions = "Elija la query a ejecutar desplazandose con las teclas ↑ (Arriba) ↓ (Abajo) y apretando Enter";
        private string[] options = new string[] {
               "1) Query para devolver objeto customer.",
               "2) Query para devolver todos los productos sin stock.",
               "3) Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad",
               "4) Query para devolver todos los customers de la Región WA",
               "5) Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789",
               "6) Query para devolver los nombre de los Customers. Mostrarlos en Mayuscula y en Minuscula",
               "7) Query para devolver Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1/1/1997.",
               "8)  Query para devolver los primeros 3 Customers de la  Región WA",
               "9) Query para devolver lista de productos ordenados por nombre",
               "10)  Query para devolver lista de productos ordenados por unit in stock de mayor a menor.",
               "11) Query para devolver las distintas categorías asociadas a los productos",
               "12) Query para devolver el primer elemento de una lista de productos",
               "13) Query para devolver los customer con la cantidad de ordenes asociadas",
               "14) \nSALIR"
        };

        public App() { }

        public void Run()
        {
            Menu mainMenu = new Menu($"{appIntro}\n{appInstrucctions}", options);
            const int salir = 13;
            const int continuar = 1;
            int opcionElegida;

            do
            {
                opcionElegida = mainMenu.Run();

                if (opcionElegida == OpcionMenu.Query1) mostrarUnCustomer();

                else if (opcionElegida == OpcionMenu.Query2) mostrarProductosSinStock();

                else if (opcionElegida == OpcionMenu.Query3) mostrarProductosFiltradosPrecioYstock();

                else if (opcionElegida == OpcionMenu.Query4) mostrarCustomersRegionWA();

                else if (opcionElegida == OpcionMenu.Query5) mostrarProductoConId789();

                else if (opcionElegida == OpcionMenu.Query6) mostrarNombresCustomers();

                else if (opcionElegida == OpcionMenu.Query7) mostrarCustomersFiltradosRegionYfechaOrden();

                else if (opcionElegida == OpcionMenu.Query8) mostrarPrimeros3CustomersRegionWA();

                else if (opcionElegida == OpcionMenu.Query9) mostrarProductosOrdenadosNombre();

                else if (opcionElegida == OpcionMenu.Query10) mostrarProductosOrdenadosStock();

                else if (opcionElegida == OpcionMenu.Query11) mostrarCategoriasAsociadasProductos();

                else if (opcionElegida == OpcionMenu.Query12) mostrarPrimerElementoListaProductos();

                else if (opcionElegida == OpcionMenu.Query13) mostrarCantidadOrdenesPorCustomer();

                if (opcionElegida != salir)
                {
                    try
                    {
                        Console.WriteLine("\n¿Continuar con otras operaciones o salir?\n\t01-CONTINUAR\t13-SALIR");
                        opcionElegida = Convert.ToInt32(Console.ReadLine());
                        opcionElegida.ValidateOption();
                    }
                    catch (InvalidOptionMenuException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("No ingresaste nada o ingresaste una letra. Solo ingresa los enteros 1 o 2");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            } while (opcionElegida != salir);

            Console.WriteLine("\n\n\t### Se cerró con éxito la aplicación. ###");

        }

        public void mostrarUnCustomer()
        {
            var customer = cl.unObjetoCustomer();
            Console.WriteLine($"\tID #{customer.CustomerID} - {customer.CompanyName}");
        }

        public void mostrarProductosSinStock()
        {
            var productos = pl.queryProductosSinStock();

            foreach (var p in productos)
            {
                Console.WriteLine($"ID #{p.ProductID} - {p.ProductName} - STOCK: {p.UnitsInStock}");
            }
        }

        public void mostrarProductosFiltradosPrecioYstock()
        {
            var productos = pl.queryProdFiltradosPrecioStock();

            foreach (var p in productos)
            {
                Console.WriteLine($"ID #{p.ProductID} - {p.ProductName} - PRECIO: {p.UnitPrice} - STOCK: {p.UnitsInStock}");
            }
        }

        public void mostrarCustomersRegionWA()
        {
            var customers = cl.customersRegionWa();

            foreach (var c in customers)
            {
                Console.WriteLine($"ID #{c.CustomerID} - {c.CompanyName} - {c.Region}");
            }
        }

        public void mostrarProductoConId789()
        {
            var productoId789 = pl.producto789();
            Console.WriteLine((productoId789 == null) ? "No existe el Producto con ID 789" : $"ID #{productoId789.ProductID} - {productoId789.ProductName}");
        }

        public void mostrarNombresCustomers()
        {
            var customers = cl.customersMayusculasMinusculas();

            foreach (var c in customers)
            {
                Console.WriteLine($"#ID: {c.CompanyName.ToUpper()} - {c.CompanyName.ToLower()}");
            }
        }

        public void mostrarCustomersFiltradosRegionYfechaOrden()
        {
            var customers = cl.customersFiltradosRegionYfechaOrden();

            foreach (var c in customers)
            {
                Console.WriteLine($"ID #{c.CustomerID} - {c.CompanyName} - Fecha de Orden: {c.OrderDate}");
            }
        }

        public void mostrarPrimeros3CustomersRegionWA()
        {
            var customers = cl.primerosTresCustomers();

            foreach (var c in customers)
            {
                Console.WriteLine($"ID #{c.CustomerID} - {c.CompanyName} - REGION: {c.Region}");
            }
        }

        public void mostrarProductosOrdenadosNombre()
        {
            var productos = pl.queryProductosOrdenadosNombre();

            foreach (var p in productos)
            {
                Console.WriteLine($"ID #{p.ProductID} - Nombre Producto: {p.ProductName}");
            }
        }

        public void mostrarProductosOrdenadosStock()
        {
            var productos = pl.queryProductosOrdenadosStock();

            foreach (var p in productos)
            {
                Console.WriteLine($"ID #{p.ProductID} - {p.ProductName} - STOCK: {p.UnitsInStock}");
            }
        }

        public void mostrarCategoriasAsociadasProductos()
        {
            var productos = pl.productosConCategorias();

            foreach (var p in productos)
            {
                Console.WriteLine($"Categoria: {p.CategoryID} - Producto asociado: ID #{p.ProductID} - {p.ProductName}");
            }
        }

        public void mostrarPrimerElementoListaProductos()
        {
            var producto = pl.PrimerProducto();

            Console.WriteLine($"#ID {producto.ProductID} - {producto.ProductName}");
        }

        public void mostrarCantidadOrdenesPorCustomer()
        {
            var customers = cl.customersCantidadOrdenesAsociadas();

            foreach (var c in customers)
            {
                Console.WriteLine($"ID Customer: {c.CustomerID} - {c.RelatedOrders}");
            }
        }
    }
}
/*
   switch (opcionElegida)
   {
       case OpcionMenu.Query1:
           imprimirResultadoQuery1();
           break;
       case OpcionMenu.Query2:
           break;
       case OpcionMenu.Query3:
           break;
       case OpcionMenu.Query4:
           break;
       case OpcionMenu.Query5:
           break;
       case OpcionMenu.Query6:
           break;
       case OpcionMenu.Query7:
           break;
       case OpcionMenu.Query8:
           break;
       default:
           continuarOcerrarApp();
           break;
   }
   */