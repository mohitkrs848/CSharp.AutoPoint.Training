﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.AutoPoint.Training.Utilities
{
    internal static class Logger
    {
        public static void Log(string message)
        {
            Console.WriteLine($"\n[{DateTime.Now}] {message}");
        }
    }
}
