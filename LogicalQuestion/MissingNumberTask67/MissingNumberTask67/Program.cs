using System;

class Program
{
    static int MissingID(int[] studentList)
    {
        int sl = studentList.Length;
        int expected = sl * (sl + 1) / 2;
        int actual = 0;

        foreach (int num in studentList)
        {
            actual += num;
        }

        return expected - actual;
    }

    static void Main()
    {
        int[] studentList1 = { 3, 0, 1 };
        Console.WriteLine(MissingID(studentList1)); 

        int[] studentList2 = { 0, 1 };
        Console.WriteLine(MissingID(studentList2)); 

        int[] studentList3 = { 9, 6, 4, 2, 3, 5, 7, 0, 1 };
        Console.WriteLine(MissingID(studentList3)); 

        int[] studentList4 = { 0 };
        Console.WriteLine(MissingID(studentList4));

        int[] studentList5 = { 1 };
        Console.WriteLine(MissingID(studentList5)); 
    }
}
