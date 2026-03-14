// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;

class Program
{
    static int FindEquilibriumIndex(int[] arr)
    {
        int totalSum = 0;
        int leftSum = 0;

    
        foreach (int num in arr)
        {
            totalSum += num;
        }

      
        for (int i = 0; i < arr.Length; i++)
        {
            int rightSum = totalSum - leftSum - arr[i];

            if (leftSum == rightSum)
            {
                return i;
            }

            leftSum += arr[i];
        }

        return -1;
    }

    static void Main()
    {
        int n;
        Console.Write("Enter size of array: ");
        string sizeInput = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(sizeInput) || !int.TryParse(sizeInput, out n) || n <= 0)
        {
            Console.WriteLine("Invalid array size.");
            return;
        }

        int[] arr = new int[n];

        Console.WriteLine("Enter array elements:");

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out arr[i]))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                i--; 
            }
        }

        int result = FindEquilibriumIndex(arr);

        Console.WriteLine("Equilibrium Index: " + result);
    }
}
