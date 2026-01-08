using System;
using System.Collections.Generic;

public class Student
{
    private static int rollCounter = 1;

    public int RollNo { get; private set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public Classes ClassName { get; set; }
    public string Address { get; set; }
    public Dictionary<Subject, int> Marks { get; set; }
    public List<string> Hobbies { get; private set; }
    public DateTime AddedDateTime { get; set; }

    public Student()
    {
        RollNo = rollCounter++;
        AddedDateTime = DateTime.Now;
        Marks = new Dictionary<Subject, int>();
        Hobbies = new List<string>();
    }

    public void AddHobby(string hobby)
    {
        if (Hobbies.Count >= 7)
            throw new Exception("Maximum 7 hobbies allowed");

        Hobbies.Add(hobby);
    }

    public int TotalMarks()
    {
        int total = 0;
        foreach (int m in Marks.Values)
            total += m;

        return total;
    }

    public double GetPercentage()
    {
        //return (TotalMarks() * 100.0) / (Marks.Count * 100);
        return (TotalMarks() / Marks.Count);
    }
}
