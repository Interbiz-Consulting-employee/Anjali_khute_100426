public static class StudentExtensions
{
    public static void Print(this Student s)
    {
        Console.WriteLine($"\nRoll No.: {s.RollNo}");
        Console.WriteLine($"Name: {s.FirstName} {s.MiddleName} {s.LastName}");
        Console.WriteLine($"Age: {s.Age}");
        Console.WriteLine($"Class: {s.ClassName}");
        Console.WriteLine($"Address: {s.Address}");

        Console.WriteLine("Subject wise Marks:");
        foreach (var m in s.Marks)
            Console.WriteLine($"{m.Key} : {m.Value}");

        Console.WriteLine($"Total: {s.TotalMarks()}");
        Console.WriteLine($"Percentage: {s.GetPercentage():0.00}%");

        Console.WriteLine("Hobbies:");
        foreach (string h in s.Hobbies)
            Console.WriteLine("- " + h);

        Console.WriteLine($"Added On : {s.AddedDateTime}");

        Console.WriteLine("-----------------------");
    }
}
