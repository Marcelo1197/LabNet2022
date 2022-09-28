using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Crud.NorthW.App.Common.Exceptions;

namespace Crud.NorthW.App.Logic.Validation
{
    public static class ValidationInputExtensions
    {
        public static void ValidateOption(this int input)
        {
            int keepRunning = 1;
            int exit = 5;

            if (input != keepRunning && input != exit)
            {
                throw new InvalidOptionException();
            }
        }

        public static void ValidateCompanyName(this string input) //max length 40
        {
            bool nameIsEmpty = String.IsNullOrWhiteSpace(input);
            bool nameLengthExceeded = input.Length > 40;
            bool nameIsNumeric = Double.TryParse(input, out double result);
            
            if (nameLengthExceeded)
            {
                throw new OutOfRangeStringException(40);
            }
            if (nameIsNumeric || nameIsEmpty)
            {
                throw new InvalidStringException();
            }
        }

        public static void ValidatePhone(this string input)
        {
            bool phoneLengthExceeded = input.Length > 24;
            bool phoneContainsCharacters = Regex.IsMatch(input, @"^[a-zA-Z]+$");

            if (phoneContainsCharacters)
            {
                throw new InvalidPhoneException();
            }
            if (phoneLengthExceeded)
            {
                throw new OutOfRangeStringException(24);
            }

        }

        public static void ValidateId(this int inputId)
        {
            bool isIdNegative = inputId < 0;

            if (isIdNegative)
            {
                throw new InvalidIdException();
            }
        }
    }
}
