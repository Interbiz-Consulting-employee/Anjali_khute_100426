// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Collections.Generic;

class LongestConsecutiveSequence
{
    static void Main()
    {
        Console.WriteLine("Enter number of elements:");
        int n = int.Parse(Console.ReadLine());

        if (n <= 0)
        {
            Console.WriteLine("Array must contain at least one element.");
            return;
        }

        int[] nums = new int[n];

        Console.WriteLine("Enter elements:");
        for (int i = 0; i < n; i++)
        {
            nums[i] = int.Parse(Console.ReadLine());
        }

        var result = FindLongestConsecutive(nums);

        Console.WriteLine("Length = " + result.length);
        Console.WriteLine("Start from element = " + result.start);
    }

    static (int length, int start) FindLongestConsecutive(int[] nums)
    {
        HashSet<int> set = new HashSet<int>(nums);

        int maxLength = 0;
        int minStart = 0;

        foreach (int num in set)
        {
           
            if (!set.Contains(num - 1))
            {
                int currentNum = num;
                int currentLength = 1;

                while (set.Contains(currentNum + 1))
                {
                    currentNum++;
                    currentLength++;
                }

                if (currentLength > maxLength ||
                   (currentLength == maxLength && num < minStart))
                {
                    maxLength = currentLength;
                    minStart = num;
                }
            }
        }

        return (maxLength, minStart);
    }
}
