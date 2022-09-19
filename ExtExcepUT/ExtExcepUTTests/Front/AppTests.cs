using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExtExcepUT.Front;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExtExcepUT.Excepciones;


namespace ExtExcepUT.Front.Tests
{
    [TestClass()]
    public class AppTests
    {
        [TestMethod(), ExpectedException(typeof(DivideByZeroException))]
        public void ArrojarEx()
        {
            // arrange
            var app = new App();

            // act
            app.ArrojarEx();
        }

        [TestMethod()]
        public void ArrojarIntTest()
        {
            // arrange
            var app = new App();
            int numEsperado = 2;
            int numObtenido;

            // act
            numObtenido = app.ArrojarInt();

            // assert

            Assert.AreEqual(numEsperado, numObtenido);
        }
    }
}