// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using System;

class KokoEatingBananas
{
    static int MinEatingSpeed(int[] nums, long h)
    {
        int left = 1;
        int right = 0;

        // Find maximum pile (upper bound)
        foreach (int pile in nums)
        {
            right = Math.Max(right, pile);
        }

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (CanFinish(nums, h, mid))
                right = mid;
            else
                left = mid + 1;
        }

        return left;
    }

    static bool CanFinish(int[] nums, long h, int k)
    {
        long totalHours = 0;  // use long (important)

        foreach (int pile in nums)
        {
            totalHours += (long)(pile + k - 1) / k;

            if (totalHours > h)
                return false;
        }

        return totalHours <= h;
    }

    static void Main()
    {
        Console.Write("Enter number of piles (1 to 10^4): ");
        int n = int.Parse(Console.ReadLine());

        if (n < 1 || n > 10000)
        {
            Console.WriteLine("Invalid n. Must be between 1 and 10^4.");
            return;
        }

        int[] nums = new int[n];

        Console.WriteLine("Enter bananas in each pile (1 to 10^9):");

        for (int i = 0; i < n; i++)
        {
            nums[i] = int.Parse(Console.ReadLine());

            if (nums[i] < 1 || nums[i] > 1000000000)
            {
                Console.WriteLine("Invalid pile size. Must be between 1 and 10^9.");
                return;
            }
        }

        Console.Write("Enter number of hours (n to 10^9): ");
        long h = long.Parse(Console.ReadLine());

        if (h < n || h > 1000000000)
        {
            Console.WriteLine("Invalid h. Must satisfy n <= h <= 10^9.");
            return;
        }

        int result = MinEatingSpeed(nums, h);

        Console.WriteLine("Minimum eating speed: " + result);
    }
}