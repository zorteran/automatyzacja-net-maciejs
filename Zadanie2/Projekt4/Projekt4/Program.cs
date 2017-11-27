using System;

namespace Zadanie4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("y = a * (x * x) + b  * y + c");
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

            // napisz obliczanie rozwiązań (miejsc zerowych) funkcji kwadratowej 
            // jeśli nie pamiętasz jak to się liczy to tutaj jest ściąga
            // http://matma.prv.pl/kwadratowa.php
            // postaraj się napisac to samodzielnie a nie googlując implementację
            // powodzenia :)
            
            Console.WriteLine(x1);
            Console.WriteLine(x2);
        }
    }
}