using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Crud.NorthW.App.Logic.Validation;
using Crud.NorthW.App.Common.Exceptions;

namespace ValidationInputTests
{
    [TestClass]
    public class ValidationsInputTest
    {
        [TestMethod, ExpectedException(typeof(InvalidOptionException))]
        public void ValidateOptionTest()
        {
            // Arrange
            int inputInvalid = 10;

            // Act
            inputInvalid.ValidateOption();
        }

        [TestMethod, ExpectedException(typeof(OutOfRangeStringException))]
        public void ValidateCompanyNameTest_OutOfRangeString()
        {
            // Arrange
            string invalidNameLength = "Lorem ipsum dolor sit amet, consectetuer simor";

            // Act
            invalidNameLength.ValidateCompanyName();
        }

        [TestMethod, ExpectedException(typeof(InvalidStringException))]
        public void ValidateCompanyNameTest_StringNumeric()
        {
            // Arrange
            string invalidNameLength = "223328";

            // Act
            invalidNameLength.ValidateCompanyName();
        }

        [TestMethod, ExpectedException(typeof(InvalidStringException))]
        public void ValidateCompanyNameTest_EmptyString()
        {
            // Arrange
            string invalidNameLength = "";

            // Act
            invalidNameLength.ValidateCompanyName();
        }

        [TestMethod, ExpectedException(typeof(OutOfRangeStringException))]
        public void ValidatePhoneTest_OutOfRangeString()
        {
            // Arrange
            string invalidPhoneLength = "12312312312312312312312333333";

            // Act
            invalidPhoneLength.ValidatePhone();
        }


        [TestMethod, ExpectedException(typeof(InvalidPhoneException))]
        public void ValidatePhoneTest_invalidPhone()
        {
            // Arrange
            string phoneWithCharacters = "asd";

            // Act
            phoneWithCharacters.ValidatePhone();
        }

        [TestMethod, ExpectedException(typeof(InvalidIdException))]
        public void ValidateIdTest()
        {
            // Arrange
            int idNegative = -99;

            // Act
            idNegative.ValidateId();
        }
    }
}
