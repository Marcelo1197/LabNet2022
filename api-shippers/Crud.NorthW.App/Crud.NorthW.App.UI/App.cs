using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crud.NorthW.App.Logic;
using Crud.NorthW.App.Logic.Validation;
using Crud.NorthW.App.Entities;
using Crud.NorthW.App.Common.Exceptions;
using System.Data.Entity.Infrastructure;

namespace Crud.NorthW.App.UI
{

    public class App
    {
        private string appIntro = "Aplicación para realizar operaciones del tipo: Consulta y ABM sobre las entidades:\n\t'Customers'\n\t'Shippers'\n";
        private string appInstrucctions = "Elija la operación a realizar desplazandose con las teclas ↑ (Arriba) ↓ (Abajo) y apretando Enter";
        private string[] options = new string[] {
               "1) Consulta simple a entidad Customers",
               "2) Consulta simple a entidad Shippers",
               "3) Agregar un nuevo registro Shippers",
               "4) Actualizar un registro Shippers Existente",
               "5) Eliminar un registro Shippers",
               "6) SALIR"
        };

        private CustomerLogic cl = new CustomerLogic();
        private ShippersLogic sl = new ShippersLogic();

        public void Run()
        {
            Menu mainMenu = new Menu($"{appIntro}\n{appInstrucctions}", options);
            int selectedOption;
            int exit = 5;
            int keepRunning = 1;

            do
            {
                selectedOption = mainMenu.Run();
                if (selectedOption == 0)
                {
                    ShowAllCustomers();
                }
                else if (selectedOption == 1)
                {
                    ShowAllShippers();
                }
                else if (selectedOption == 2) 
                {
                    AddShipperMenu();
                }
                else if (selectedOption == 3) 
                {
                    UpdateShipperMenu();
                }
                else if (selectedOption == 4) 
                {
                    DeleteShipperMenu();
                }

                if (selectedOption != exit)
                {
                    do
                    {
                        try
                        {
                            Console.WriteLine("\n¿Continuar con otras operaciones o salir?\n\t01-CONTINUAR\t05-SALIR");
                            selectedOption = Convert.ToInt32(Console.ReadLine());
                            selectedOption.ValidateOption();
                        }
                        catch (InvalidOptionException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("No ingresaste nada o ingresaste una letra. Solo ingresa los enteros 1 o 2");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("No ingresaste nada o ingresaste una letra. Solo ingresa los enteros 1 o 2");
                        }
                    } while (selectedOption != keepRunning && selectedOption != exit);
                }
            } while (selectedOption != exit);
            Console.WriteLine("\n\t### Se cerró con éxito la aplicación. ###");
        }

        public void ShowAllCustomers()
        {
            var customersList = cl.GetAll();
            foreach (var c in customersList)
            {
                Console.WriteLine($"#ID: {c.CustomerID} - Empresa: [{c.CompanyName}] - Dueño [{c.ContactName}]");
            }
        }

        public void ShowAllShippers()
        {
            var shippersList = sl.GetAll();
            foreach (var s in shippersList)
            {
                Console.WriteLine($"#ID: {s.ShipperID} - Empresa: [{s.CompanyName}] - Telefono: [{s.Phone}]");
            }
        }

        public void AddShipperMenu()
        {
            bool inputsNotValidated = true;
            do
            {
                try
                {
                    Console.WriteLine("Complete los datos a continuación para agregar un nuevo Shipper:");
                    Console.WriteLine("Nombre de la empresa del Shipper:");
                    string inputCompanyNameShipper = Console.ReadLine();
                    inputCompanyNameShipper.ValidateCompanyName();
                    Console.WriteLine("Telefono de contacto del Shipper:");
                    string inputPhoneShipper = Console.ReadLine();
                    inputPhoneShipper.ValidatePhone();
                    sl.Add(new Shippers()
                    {
                        CompanyName = inputCompanyNameShipper,
                        Phone = inputPhoneShipper
                    });
                    Console.WriteLine($"\n\tSe agregó con éxito el nuevo Registro Shipper: {inputCompanyNameShipper}");
                    inputsNotValidated = false;
                }
                catch(OutOfRangeStringException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(InvalidStringException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(InvalidPhoneException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (inputsNotValidated);

        }

        public void UpdateShipperMenu()
        {
            bool inputsNotValidated = true;

            Console.WriteLine("Lista de Shippers disponibles para Actualizar:\n");
            ShowAllShippers();
            do
            {
                try
                {
                    Console.WriteLine("Ingrese la ID del Shipper que quiera modificar:");
                    int inputIdShipper = Convert.ToInt32(Console.ReadLine());
                    inputIdShipper.ValidateId();
                    Shippers shipperUpdated = sl.Get(inputIdShipper);
                    Console.WriteLine("Actualice el nombre de empresa para el Shipper:");
                    string inputCompanyNameShipper = Console.ReadLine();
                    inputCompanyNameShipper.ValidateCompanyName();
                    Console.WriteLine("Actualice el telefono de contacto del Shipper:");
                    string inputPhoneShipper = Console.ReadLine();
                    inputPhoneShipper.ValidatePhone();

                    shipperUpdated.CompanyName = inputCompanyNameShipper;
                    shipperUpdated.Phone = inputPhoneShipper;
                    sl.Update(shipperUpdated);
                    Console.WriteLine($"\n\tSe actualizó con éxito el Registro Shipper #{inputIdShipper}");
                    inputsNotValidated = false;
                }
                catch (OutOfRangeStringException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (InvalidStringException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (InvalidPhoneException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //DBG Console.WriteLine(ex.GetType().FullName);
                }
            } while (inputsNotValidated);
            
        }

        public void DeleteShipperMenu()
        {
            bool inputNotValid = true;
            Console.WriteLine("Lista de shippers disponibles para eliminar:");
            ShowAllShippers();

            do
            {
                try
                {
                    Console.WriteLine("Ingrese la ID del Shipper que quiera eliminar");
                    int inputIdShipper = Convert.ToInt32(Console.ReadLine());
                    inputIdShipper.ValidateId();
                    Shippers shipperDeleted = sl.Get(inputIdShipper);
                    sl.Delete(shipperDeleted);
                    Console.WriteLine($"\n\tSe eliminó con éxito el Registro Shipper #{inputIdShipper}");
                    inputNotValid = false;
                }
                catch (InvalidIdException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Ingresó una letra en vez de un número. Solo se aceptan enteros positivos.");
                }
                catch (DbUpdateException ex) {
                    Console.WriteLine($"No puede eliminar la entidad Shipper porque una entidad Order está relacionada con esta.\nPrimero debe eliminar la relación o la tabla Order en cuestión.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (inputNotValid);
        }
    }
}
