// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");



using System;

class Program
{
    static void Main()
    {
        int n = 5;

        // Upper 
        for (int i = 1; i <= n; i++)
        {
        
            for (int j = 1; j <= i - 1; j++)
            {
                Console.Write(" ");
            }

         
            for (int k = 1; k <= i; k++)
            {
                Console.Write("*");
            }

            Console.WriteLine();
        }


        // Lower 
        for (int i = n - 1; i >= 1; i--)
        {
          
            for (int j = 1; j <= i - 1; j++)
            {
                Console.Write(" ");
            }

          
            for (int k = 1; k <= i; k++)
            {
                Console.Write("*");
            }

            Console.WriteLine();
        }
    }
}

