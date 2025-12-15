// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using System;

class Program
{
    static void Main()
    {

        Console.WriteLine("Enter a string:");
        string s = Console.ReadLine().ToLower();

        char[] arr = s.ToCharArray();

        foreach (char c in arr)
        {
            if (s.IndexOf(c) == s.LastIndexOf(c))
            {
                Console.WriteLine(c);
                return;
            }
        }

        Console.WriteLine('0');

    }
}

