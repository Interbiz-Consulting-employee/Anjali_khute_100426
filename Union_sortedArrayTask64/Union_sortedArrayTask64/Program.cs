// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System.Collections;

class Program
{
    static void Main()
    {
        int[] arr1 = { 1, 2, 3, 4, 5 };
        int[] arr2 = { 2, 3, 4, 5 };


        // -- with union method

        //var unionResult = arr1.Union(arr2);
        //foreach (var r in unionResult)
        //    Console.Write(r + " ");



        // -- with hashset collection

        HashSet<int> hs = new HashSet<int>();

        foreach (int ar in arr1)
        {
            hs.Add(ar);
        }

        foreach (int ar in arr2)
        {
            hs.Add(ar);
        }

        List<int> l = new List<int>(hs);
        l.Sort();

        foreach (int ar in l)
            Console.Write(ar + " ");
    }
}