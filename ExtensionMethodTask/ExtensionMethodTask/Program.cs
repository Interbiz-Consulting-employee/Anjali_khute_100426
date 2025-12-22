// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;

public static class NumberExtensions
{
    public static double TenPercent(this int number)
    {
        return number * 0.10;
    }
}


class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine());

        double result = num.TenPercent();

        Console.WriteLine(result);


    }
}

