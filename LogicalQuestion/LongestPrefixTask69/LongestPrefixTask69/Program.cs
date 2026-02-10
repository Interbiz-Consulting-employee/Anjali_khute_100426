// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using System;

class LongestCommonPrefix
{
    static void Main()
    {
        Console.WriteLine("Enter number of strings:");
        int n = int.Parse(Console.ReadLine());

        // Constraint check
        if (n < 1 || n > 200)
        {
            Console.WriteLine("Invalid input size.");
            return;
        }

        string[] strs = new string[n];

        Console.WriteLine("Enter strings:");
        for (int i = 0; i < n; i++)
        {
            strs[i] = Console.ReadLine();

            if (strs[i].Length > 200)
            {
                Console.WriteLine("String length exceeds constraint.");
                return;
            }
        }

        string result = FindLongestCommonPrefix(strs);
        Console.WriteLine("Longest Common Prefix: \"" + result + "\"");
    }

    static string FindLongestCommonPrefix(string[] strs)
    {
        if (strs == null || strs.Length == 0)
            return "";

        string prefix = strs[0];

        for (int i = 1; i < strs.Length; i++)
        {
            while (!strs[i].StartsWith(prefix))
            {
                prefix = prefix.Substring(0, prefix.Length - 1);

                if (prefix == "")
                    return "";
            }
        }

        return prefix;
    }
}
