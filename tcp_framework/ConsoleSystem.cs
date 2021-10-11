using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcp_framework
{
    class ConsoleSystem
    {
        public static void Log(string input, string output = "", bool writeline = true, ConsoleColor baseColor = ConsoleColor.Red)
        {
            if (writeline)
            {
                Console.ForegroundColor = baseColor; Console.Write("["); Console.ForegroundColor = ConsoleColor.Gray; Console.Write("+");
                Console.ForegroundColor = baseColor; Console.Write("]"); Console.ForegroundColor = ConsoleColor.White; Console.Write(" - "); Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(input); if (output != "") { Console.ForegroundColor = baseColor; Console.Write(" -> "); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine(output); }
            }
            else
            {
                Console.ForegroundColor = baseColor; Console.Write("["); Console.ForegroundColor = ConsoleColor.Gray; Console.Write("+");
                Console.ForegroundColor = baseColor; Console.Write("]"); Console.ForegroundColor = ConsoleColor.White; Console.Write(" - "); Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(input); if (output != "") { Console.ForegroundColor = baseColor; Console.Write(" -> "); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine(output); }
            }
        }
    }
}
