using System;
using System.Collections.Generic;

class MissingDivisor
{
    static void Main()
    {
       
        Console.Write("Enter n: ");
        long n;
        while (!long.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.WriteLine("Please enter a valid positive number:");
        }

        Console.WriteLine("Enter divisors separated by space:");
        string[] input = Console.ReadLine().Split(' ');

        HashSet<long> arrSet = new HashSet<long>();

        foreach (string s in input)
        {
            if (long.TryParse(s, out long value))
                arrSet.Add(value);
        }

        long missingDivisor = -1;

        for (long i = 1; i * i <= n; i++)
        {
            if (n % i == 0)
            {
                long pair = n / i;

                if (!arrSet.Contains(i))
                {
                    missingDivisor = i;
                    break;
                }

                if (!arrSet.Contains(pair))
                {
                    missingDivisor = pair;
                    break;
                }
            }
        }

        Console.WriteLine("Missing Divisor: " + missingDivisor);
    }
}