using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExtExcepUT.Extensiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtExcepUT.Extensiones.Tests
{
    [TestClass()]
    public class DivisionExtensionsTests
    {
        [TestMethod(), ExpectedException(typeof(DivideByZeroException))]
        public void DividirPorTestExceptionDbz()
        {
            // arrange
            decimal dividendo = 99;

            // act
            decimal resultado = dividendo.DividirPor(0);
        }
    }
}