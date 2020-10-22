using System;
using System.Diagnostics.CodeAnalysis;

namespace AD
{
    public class Opgave2
    {
        static long calls = 0;

        private static long FibonacciRecursiveInternal(int n)
        {
            calls++;
            if (n <= 2) return 1;
            return FibonacciRecursiveInternal( n - 1 ) + FibonacciRecursiveInternal( n - 2 );
        }

        public static long FibonacciRecursive(int n)
        {
            calls = 0;
            return FibonacciRecursiveInternal(n);
        }

        private static long FibonacciIterativeInternal(int n)
        {
            if (n == 1) return 1;

            int t1 = 0;
            int t2 = 1;
            int sum = 0;
            
            for (int i = 1; i < n; i++)
            {
                sum = t1 + t2;
                t1 = t2;
                t2 = sum;
            }

            return sum;
        }

        public static long FibonacciIterative(int n)
        {
            calls = 0;
            return FibonacciIterativeInternal(n);
        }

        public static void Run()
        {
            int MAX = 35;

            System.Console.WriteLine("Recursief:");
            for (int n = 1; n <= MAX; n++)
            {
                System.Console.WriteLine("          Fibonacci({0,2}) = {1,8} ({2,9} calls)", n, FibonacciRecursive(n), calls);
            }
            System.Console.WriteLine("Iteratief:");
            for (int n = 1; n <= MAX; n++)
            {
                System.Console.WriteLine("          Fibonacci({0,2}) = {1,8} ({2,9} loops)", n, FibonacciIterative(n), calls);
            }
        }
    }
}
