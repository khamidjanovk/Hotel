using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hotel.Services
{
    internal class CatchErrors
    {
        public static void InputError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nInput Error! Please try again!");
            Console.ForegroundColor = ConsoleColor.White;
            
            Thread.Sleep(2000);
        }
        public static void ConfirmError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nUsername and Password are wrong!");
            Console.ForegroundColor = ConsoleColor.White;

            Thread.Sleep(2000);
        }

    }
}
