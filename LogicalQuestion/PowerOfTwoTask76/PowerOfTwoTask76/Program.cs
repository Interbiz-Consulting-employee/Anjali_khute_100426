using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter an integer: ");

        if (!long.TryParse(Console.ReadLine(), out long n))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            return;
        }

  
        if (n < -2147483648 || n > 2147483647)
        {
            Console.WriteLine("Input is outside the allowed constraint range.");
            return;
        }

        bool result = IsPowerOfTwo((int)n);

        Console.WriteLine(result);
    }

    static bool IsPowerOfTwo(int n)
    {
        if (n <= 0)
            return false;

        return (n & (n - 1)) == 0;
    }
}