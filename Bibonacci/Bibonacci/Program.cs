using System;
using System.Collections.Generic;

namespace Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese el límite para la serie Fibonacci: ");
            int limite = Convert.ToInt32(Console.ReadLine());

            List<int> resultado = GenerarFibonacci(limite);

            Console.Write($"Serie Fibonacci hasta {limite}: ");
            foreach (int num in resultado)
            {
                Console.Write(num + " ");
            }

            Console.ReadLine(); 
        }

        static List<int> GenerarFibonacci(int limite)
        {
            List<int> fibonacci = new List<int>();
            int a = 0, b = 1, c;

            while (a <= limite)
            {
                fibonacci.Add(a);
                c = a + b;
                a = b;
                b = c;
            }

            return fibonacci;
        }
    }
}
