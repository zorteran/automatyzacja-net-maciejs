using System;

namespace Zadanie4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("y = a * (x * x) + b  * x + c");
            Console.Write("podaj wartośc a = ");
            var a = Convert.ToDouble(Console.ReadLine());

            Console.Write("podaj wartośc b = ");
            var b = Convert.ToDouble(Console.ReadLine());

            Console.Write("podaj wartośc c = ");
            var c = Convert.ToDouble(Console.ReadLine());

            Calculate(a, b, c);

            Console.WriteLine("Brawo! Czwarte zadanie zrobione :)");
            Console.WriteLine("Naciśnij jakikolwiek klawisz aby zakończyć...");
            Console.ReadKey();
        }

        private static void Calculate(double a, double b, double c)
        {
            double x1 = 0;
            double x2 = 0;
            double delta = b * b - (4 * a * c);
            if (delta<0)
            {
                Console.WriteLine("Funkcja nie ma miejsc zerowych");
                return;
            }
            if (delta == 0) //jedno miejsce
            {
                x1 = (-1 * b ) / (2 * a);
                Console.WriteLine(x1);
                return;
            }
            x1 = (-1 * b + Math.Sqrt(delta)) / (2 * a);
            x2 = (-1 * b - Math.Sqrt(delta)) / (2 * a);
            Console.WriteLine(x1);
            Console.WriteLine(x2);
        }
    }
}