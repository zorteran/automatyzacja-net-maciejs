using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Witaj świecie!");
            TryExit();
        }

        private static void TryExit()
        {
            string answer = "";
            do
            {
                Console.WriteLine("Aby zamknąć aplikację wpisz 'exit'");
                answer = Console.ReadLine();
            } while (answer != "exit");
        }
    }
}
