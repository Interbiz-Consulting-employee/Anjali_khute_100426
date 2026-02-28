using System;

class InterleavingString
{
    static bool IsInterleave(string s1, string s2, string s3, int i, int j)
    {
        if (i + j == s3.Length)
            return i == s1.Length && j == s2.Length;

        return
            (i < s1.Length && s1[i] == s3[i + j] && IsInterleave(s1, s2, s3, i + 1, j)) ||
            (j < s2.Length && s2[j] == s3[i + j] && IsInterleave(s1, s2, s3, i, j + 1));
    }

    static void Main()
    {
        Console.Write("s1 = ");
        string s1 = Console.ReadLine();

        Console.Write("s2 = ");
        string s2 = Console.ReadLine();

        Console.Write("s3 = ");
        string s3 = Console.ReadLine();

        Console.WriteLine(
            s1.Length + s2.Length == s3.Length &&
            IsInterleave(s1, s2, s3, 0, 0)
        );
    }
}
