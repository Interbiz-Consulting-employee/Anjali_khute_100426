class Program
{
    static void Main()
    {
        StudentService service = new StudentService();

        while (true)
        {
            Console.WriteLine("\n----- Student Management Menu -----");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Show All Students");
            Console.WriteLine("3. Filter Students (By Name/Class/.....)");   
            Console.WriteLine("4. Filter Age (15–25)");
            Console.WriteLine("5. Find Topper of Class");
            Console.WriteLine("6. Find Nth Topper (N > 1)");
            Console.WriteLine("7. Show Classes Every 10 Seconds");
            Console.WriteLine("8. Exit");

            Console.Write("Enter choice: ");
            string ch = Console.ReadLine();

            service.StopClassDisplay();

            switch (ch)
            {
                case "1":
                    service.AddStudent();
                    break;

                case "2":
                    service.DisplayAllStudents();
                    break;

                case "3":
                    service.FilterStudentsMenu();
                    break;

                case "4":
                    service.FilterStudents(s => s.Age >= 15 && s.Age <= 25);
                    break;

                case "5":
                    service.FindTopperOfClass();
                    break;

                case "6":
                    service.FindNthTopper();
                    break;

                case "7":
                    service.ShowClassesEvery10Seconds();
                    break;

                case "8":
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
