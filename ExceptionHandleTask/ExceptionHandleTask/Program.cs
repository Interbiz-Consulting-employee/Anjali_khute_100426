using System;

class AgeException : Exception
{
    public AgeException(string message) : base(message)
    {
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the Age :");
        int age = int.Parse(Console.ReadLine());

        try
        {
            if (age < 18)
            {
                throw new AgeException("Person is under 18 years");
            }
            else if (age > 75)
            {
                throw new AgeException("Person is above 75 years");
            }
            else
            {
                Console.WriteLine("Age is valid");
            }
        }
        catch (AgeException ex)
        {
            Console.WriteLine("Custom error: " + ex.Message);
        }
    }
}
