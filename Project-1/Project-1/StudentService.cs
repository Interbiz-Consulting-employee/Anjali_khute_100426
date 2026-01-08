using System;
using System.Collections.Generic;
using System.Threading;

public class StudentService
{
    private List<Student> students = new List<Student>();

    public void AddStudent()
    {
        try
        {
            Student s = new Student();

            Console.Write("First Name: "); 
            s.FirstName = Console.ReadLine();


            Console.Write("Middle Name: ");
            s.MiddleName = Console.ReadLine();


            Console.Write("Last Name: ");
            s.LastName = Console.ReadLine();


            //Console.Write("Age: ");
            //s.Age = int.Parse(Console.ReadLine());

            Console.Write("Age: ");
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                throw new Exception("Age must be a valid number");
            }

            if (age < 4 || age > 65)
            {
                //throw new Exception("Age must be between 4 and 65");
                //throw new ArgumentOutOfRangeException("Age must be between 4 and 65");
                throw new ArgumentOutOfRangeException("Age","Age must be between 4 and 65");

            }

            s.Age = age;



            Console.WriteLine("Available Classes:");
            foreach (Classes c in Enum.GetValues(typeof(Classes)))
            {
                Console.WriteLine(c);
            }

            //Console.Write("Enter Class: ");
            //s.ClassName = (Classes)Enum.Parse(
            //    typeof(Classes),
            //    Console.ReadLine(),
            //    true
            //);

            //if (!Enum.TryParse(Console.ReadLine(), true, out Classes cls))
            //    throw new ArgumentException("Invalid class selected");
            ////throw new Exception("Invalid class selected");

            //s.ClassName = cls;


            while (true)
            {
                Console.Write("Enter Class: ");
                string input = Console.ReadLine();

                if (Enum.TryParse(input, true, out Classes cls)
                    && Enum.IsDefined(typeof(Classes), cls))
                {
                    s.ClassName = cls;
                    break; 
                }
                else
                {
                    Console.WriteLine("Invalid class. Please enter Class1–Class12 only.");
                }
            }



            Console.WriteLine("\nAvailable Subjects:");
            foreach (Subject sub in Enum.GetValues(typeof(Subject)))
            {
                Console.WriteLine(sub);
            }

            Console.WriteLine("\nEnter subjects with marks (min 4, max 6). Type 'done' to finish:");

            while (true)
            {
                if (s.Marks.Count == 6)
                {
                    Console.WriteLine("Maximum 6 subjects allowed");
                    break;
                }

                Console.Write("Enter Subject: ");
                string input = Console.ReadLine();

                if (input.Equals("done", StringComparison.OrdinalIgnoreCase))
                    break;

                if (!Enum.TryParse(input, true, out Subject subject)
                    || !Enum.IsDefined(typeof(Subject), subject))
                {
                    Console.WriteLine("Invalid subject. Choose from the available list.");
                    continue;
                }

                if (s.Marks.ContainsKey(subject))
                {
                    Console.WriteLine("Subject already added");
                    continue;
                }

                Console.Write($"Enter marks for {subject}: ");
                if (!int.TryParse(Console.ReadLine(), out int marks))
                {
                    Console.WriteLine("Invalid marks");
                    continue;
                }

                if (marks < 0 || marks > 100)
                {
                    Console.WriteLine("Marks must be between 0 and 100");
                    continue;
                }

                s.Marks.Add(subject, marks);
            }

            if (s.Marks.Count < 4)
                throw new InvalidOperationException("At least 4 subjects are required");



            Console.Write("Address: ");
            s.Address = Console.ReadLine();



            Console.WriteLine("Enter hobbies (min 1, max 7, type done):");
            while (true)
            {
                string h = Console.ReadLine();
                if (h.ToLower() == "done") break;
                s.AddHobby(h);
            }

            if (s.Hobbies.Count == 0)
                //throw new Exception("At least one hobby required");
                throw new InvalidOperationException("At least one hobby required");

            students.Add(s);
            Console.WriteLine("Student Added Successfully");

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

  

    public void DisplayAllStudents()
    {
        foreach (Student s in students)
            s.Print();
    }


    public void FilterStudents(StudentFilter filter)
    {
        bool found = false;

        foreach (Student s in students)
        {
            if (filter(s))
            {
                s.Print();
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("No matching students found");
    }


    public void FindTopperOfClass()
    {
        Console.WriteLine("Available Classes:");
        foreach (Classes c in Enum.GetValues(typeof(Classes)))
            Console.WriteLine(c);

        Console.Write("Enter Class: ");
        Classes cls = (Classes)Enum.Parse(typeof(Classes), Console.ReadLine(), true);

        Student topper = null;
        double max = -1;

        foreach (Student s in students)
        {
            if (s.ClassName == cls)
            {
                double p = s.GetPercentage();
                if (p > max)
                {
                    max = p;
                    topper = s;
                }
            }
        }

        if (topper != null)
            topper.Print();
        else
            Console.WriteLine("No student found");
    }


    //public void ShowClassesEvery10Seconds()
    //{
    //    new Thread(() =>
    //    {
    //        while (true)
    //        {
    //            foreach (Student s in students)
    //                Console.WriteLine(s.ClassName);

    //            Thread.Sleep(10000);
    //        }
    //    }).Start();
    //}

    private bool showClassesRunning = false;

    public void ShowClassesEvery10Seconds()
    {
        showClassesRunning = true;

        new Thread(() =>
        {
            while (showClassesRunning)
            {
                Console.WriteLine("\nClasses:");
                foreach (Student s in students)
                    Console.WriteLine(s.ClassName);

                Thread.Sleep(10000);
            }
        }).Start();
    }

    public void StopClassDisplay()
    {
        showClassesRunning = false;
    }


    public void FilterStudentsMenu()
    {
        Console.WriteLine("\nFilter By:");
        Console.WriteLine("1. First Name");
        Console.WriteLine("2. Middle Name");
        Console.WriteLine("3. Last Name");
        Console.WriteLine("4. Class");
        Console.WriteLine("5. Subject");
        Console.WriteLine("6. Address");
        Console.WriteLine("7. Hobby");
        Console.WriteLine("8. Date");
        Console.Write("Choice: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Write("Enter First Name: ");
                string fn = Console.ReadLine();
                FilterStudents(s =>
                    s.FirstName.Equals(fn, StringComparison.OrdinalIgnoreCase));
                break;


            case "2":
                Console.Write("Enter Middle Name: ");
                string mn = Console.ReadLine();
                FilterStudents(s =>
                    s.MiddleName.Equals(mn, StringComparison.OrdinalIgnoreCase));
                break;


            case "3":
                Console.Write("Enter Last Name: ");
                string ln = Console.ReadLine();
                FilterStudents(s =>
                    s.LastName.Equals(ln, StringComparison.OrdinalIgnoreCase));
                break;


            case "4":
                Console.WriteLine("Available Classes:");
                foreach (Classes c in Enum.GetValues(typeof(Classes)))
                    Console.WriteLine(c);

                Console.Write("Enter Class: ");
                Classes cls = (Classes)Enum.Parse(typeof(Classes), Console.ReadLine(), true);

                FilterStudents(s => s.ClassName == cls);
                break;


            // -------- SUBJECT FILTER --------
            //case "5":
            //    Console.WriteLine("Available Subjects:");
            //    foreach (Subject sub in Enum.GetValues(typeof(Subject)))
            //        Console.WriteLine(sub);

            //    Console.Write("Enter Subject: ");
            //    Subject subject = (Subject)Enum.Parse(typeof(Subject), Console.ReadLine(), true);

            //    FilterStudents(s => s.Marks.ContainsKey(subject));
            //    break;


            case "5":
                Console.WriteLine("Available Subjects:");
                foreach (Subject sub in Enum.GetValues(typeof(Subject)))
                    Console.WriteLine(sub);

                Console.Write("Enter Subject: ");
                Subject subject = (Subject)Enum.Parse(
                    typeof(Subject),
                    Console.ReadLine(),
                    true
                );

                FilterStudents(s => s.Marks.ContainsKey(subject));
                break;


            case "6":
                Console.Write("Enter Address: ");
                string add = Console.ReadLine();
                FilterStudents(s =>
                    s.Address.Equals(add, StringComparison.OrdinalIgnoreCase));
                break;


            // -------- HOBBY FILTER --------
            case "7":
                Console.Write("Enter Hobby: ");
                string hb = Console.ReadLine();

                FilterStudents(delegate (Student s)
                {
                    foreach (string h in s.Hobbies)
                    {
                        if (h.Equals(hb, StringComparison.OrdinalIgnoreCase))
                            return true;
                    }
                    return false;
                });
                break;


            // -------- DATE FILTER --------
            case "8":
                Console.Write("Enter Date (yyyy-mm-dd): ");
                DateTime dt = DateTime.Parse(Console.ReadLine());

                FilterStudents(s => s.AddedDateTime.Date == dt.Date);
                break;

            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }



    public void FindNthTopper()
    {
        Console.WriteLine("Available Classes:");
        foreach (Classes c in Enum.GetValues(typeof(Classes)))
            Console.WriteLine(c);

        Console.Write("Enter Class: ");
        Classes cls = (Classes)Enum.Parse(typeof(Classes), Console.ReadLine(), true);

        Console.Write("Enter N (greater than 1): ");
        int n = int.Parse(Console.ReadLine());

        List<double> percentages = new List<double>();

        foreach (Student s in students)
        {
            if (s.ClassName == cls)
            {
                double p = s.GetPercentage();

                bool exists = false;
                foreach (double val in percentages)
                {
                    if (val == p)
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                    percentages.Add(p);
            }
        }

        if (percentages.Count < n)
        {
            Console.WriteLine("Not enough students");
            return;
        }

        // sort descending
        for (int i = 0; i < percentages.Count; i++)
        {
            for (int j = i + 1; j < percentages.Count; j++)
            {
                if (percentages[j] > percentages[i])
                {
                    double temp = percentages[i];
                    percentages[i] = percentages[j];
                    percentages[j] = temp;
                }
            }
        }

        double nthPercent = percentages[n - 1];

        Console.WriteLine($"Roll Numbers at position {n}:");
        foreach (Student s in students)
        {
            if (s.ClassName == cls && s.GetPercentage() == nthPercent)
            {
                Console.WriteLine("Roll No: " + s.RollNo);
            }
        }
    }


}
