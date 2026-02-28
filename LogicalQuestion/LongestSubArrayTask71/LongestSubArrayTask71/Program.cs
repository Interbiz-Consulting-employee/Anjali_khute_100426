using System;
using System.Collections.Generic;

class LongestZeroSumSubarray
{
    static void Main()
    {
        Console.WriteLine("Enter number of elements:");

        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive number:");
        }

        int[] nums = new int[n];

        Console.WriteLine("Enter elements:");
        for (int i = 0; i < n; i++)
        {
            while (!int.TryParse(Console.ReadLine(), out nums[i]))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer:");
            }
        }

        var result = FindLongestZeroSumSubarray(nums);

        Console.WriteLine("Length = " + result.length);
        Console.WriteLine("Start = " + result.start);
        Console.WriteLine("End = " + result.end);
    }

    static (int length, int start, int end) FindLongestZeroSumSubarray(int[] nums)
    {
        Dictionary<long, int> prefixMap = new Dictionary<long, int>();

        long prefixSum = 0;
        int maxLength = 0;
        int startIndex = -1;
        int endIndex = -1;

        
        prefixMap[0] = -1;

        for (int i = 0; i < nums.Length; i++)
        {
            prefixSum += nums[i];

            if (prefixMap.ContainsKey(prefixSum))
            {
                int prevIndex = prefixMap[prefixSum];
                int currentLength = i - prevIndex;

                if (currentLength > maxLength ||
                   (currentLength == maxLength && prevIndex + 1 < startIndex))
                {
                    maxLength = currentLength;
                    startIndex = prevIndex + 1;
                    endIndex = i;
                }
            }
            else
            {
                prefixMap[prefixSum] = i;
            }
        }

        return (maxLength, startIndex, endIndex);
    }
}
