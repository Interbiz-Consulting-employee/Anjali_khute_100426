//// See https://aka.ms/new-console-template for more information
////Console.WriteLine("Hello, World!");


using System;
using System.Collections.Generic;

class Program
{
    static int minCuts = -1;
    static List<string> bestPartition = new List<string>();

    static void Main()
    {
        Console.Write("Enter string: ");
        string s = Console.ReadLine();

        
        if (string.IsNullOrEmpty(s) || s.Length < 1 || s.Length > 500)
        {
            Console.WriteLine("Invalid input. Length must be between 1 and 500.");
            return;
        }

        
        foreach (char c in s)
        {
            if (c < 'a' || c > 'z')
            {
                Console.WriteLine("Invalid input. Only lowercase English letters allowed.");
                return;
            }
        }

        Backtrack(s, 0, new List<string>());

        Console.WriteLine("Cuts = " + minCuts);
        Console.WriteLine("Partition = [" + string.Join(", ", bestPartition) + "]");
    }

    static void Backtrack(string s, int start, List<string> current)
    {
        if (start == s.Length)
        {
            int cuts = current.Count - 1;

            if (minCuts == -1 || cuts < minCuts)
            {
                minCuts = cuts;
                bestPartition = new List<string>(current);
            }

            return;
        }

        for (int end = start; end < s.Length; end++)
        {
            string part = s.Substring(start, end - start + 1);

            if (IsPalindrome(part))
            {
                current.Add(part);
                Backtrack(s, end + 1, current);
                current.RemoveAt(current.Count - 1);
            }
        }
    }

    static bool IsPalindrome(string str)
    {
        int left = 0;
        int right = str.Length - 1;

        while (left < right)
        {
            if (str[left] != str[right])
                return false;

            left++;
            right--;
        }

        return true;
    }
}