﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crud.NorthW.App.Entities;
using Crud.NorthW.App.Logic;

namespace Crud.NorthW.App.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            var app = new App();
            app.Run();
            Console.ReadKey();
        }
    }
}
