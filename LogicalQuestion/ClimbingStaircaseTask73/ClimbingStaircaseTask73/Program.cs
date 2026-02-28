using System;

class ClimbingStairs
{
    static int ClimbStairs(int n)
    {
        if (n <= 2)
            return n;

        int first = 1;
        int second = 2;

        for (int i = 3; i <= n; i++)
        {
            int third = first + second;
            first = second;
            second = third;
        }

        return second;
    }

    static void Main()
    {
        Console.Write("Enter number of steps (n): ");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out int n))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return;
        }

        if (n < 1 || n > 45)
        {
            Console.WriteLine("Please enter a number between 1 and 45.");
            return;
        }

        int result = ClimbStairs(n);
        Console.WriteLine($"Number of distinct ways to climb {n} steps: {result}");
    }
}