using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LabPOOTransporte;
using LabPOOTransporte.Excepciones;

namespace LabPOOTransporte.Tests
{
    [TestClass()]
    public class AppTests
    {
        [TestMethod()]
        public void TransporteElegidoValidoTaxiTest()
        {
            // arrange
            int transporteInput = 1;
            bool transporteOutput;

            // act
            App app = new App();
            transporteOutput = app.TransporteElegidoValido(transporteInput);

            // assert
            Assert.IsTrue(transporteOutput);
        }

        [TestMethod()]
        public void TransporteElegidoValidoOmnibusTest()
        {
            // arrange
            int transporteInput = 2;
            bool transporteOutput;

            // act
            App app = new App();
            transporteOutput = app.TransporteElegidoValido(transporteInput);

            // assert
            Assert.IsTrue(transporteOutput);
        }

        [TestMethod()]
        public void TransporteElegidoInvalido()
        {
            // arrange
            int transporteInput = 666;
            bool transporteOutput;

            // act
            App app = new App();
            transporteOutput = app.TransporteElegidoValido(transporteInput);

            // assert
            Assert.IsFalse(transporteOutput);
        }

        [TestMethod()]
        public void CantPasajerosTaxiValidaTest()
        {
            // arrange
            int tipoTransporte = 1;
            int inputPasajeros = 4;
            bool cantidadPasajerosValida;

            // act

            App app = new App();
            cantidadPasajerosValida = app.CantPasajerosValida(inputPasajeros, tipoTransporte);
            
            // assert
            Assert.IsTrue(cantidadPasajerosValida);
        }

        [TestMethod()]
        public void CantPasajerosValidaFallaTest()
        {
            // arrange
            int tipoTransporte = 1;
            int inputPasajeros = 5;
            bool cantidadPasajerosValida;

            // act

            App app = new App();
            cantidadPasajerosValida = app.CantPasajerosValida(inputPasajeros, tipoTransporte);

            // assert
            Assert.IsFalse(cantidadPasajerosValida);
        }

        [TestMethod()]
        public void CantPasajerosValidaOmnibusTest()
        {
            // arrange
            int tipoTransporte = 2;
            int inputPasajeros = 100;
            bool cantidadPasajerosValida;

            // act

            App app = new App();
            cantidadPasajerosValida = app.CantPasajerosValida(inputPasajeros, tipoTransporte);

            // assert
            Assert.IsTrue(cantidadPasajerosValida);
        }

        [TestMethod()]
        public void CantPasajerosValidaOmnibusFallaTest()
        {
            // arrange
            int tipoTransporte = 2;
            int inputPasajeros = 101;
            bool cantidadPasajerosValida;

            // act

            App app = new App();
            cantidadPasajerosValida = app.CantPasajerosValida(inputPasajeros, tipoTransporte);

            // assert
            Assert.IsFalse(cantidadPasajerosValida);
        }
    }
}