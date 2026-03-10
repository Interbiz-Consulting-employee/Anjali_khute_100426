// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter number of stones: ");

        if (long.TryParse(Console.ReadLine(), out long n))
        {
            if (n < 1 || n > 2147483647)
            {
                Console.WriteLine("Input must be between 1 and 2^31 - 1");
                return;
            }

            bool result = CanWinNim(n);

            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("Invalid input");
        }
    }

    static bool CanWinNim(long n)
    {
        return n % 4 != 0;
    }
}
