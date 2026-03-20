using System;
namespace StudentManagement
{ 
    public record Student(int RollNo, string Name, string Course, int Marks);

    class Program
    {
        static void Main()
        {
            Console.Write("Enter number of students: ");
            int n = int.Parse(Console.ReadLine());
            Student[] students = new Student[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nEnter details for Student {i + 1}");

                int roll;
                while (true)
                {
                    Console.Write("Enter Roll Number: ");
                    if (int.TryParse(Console.ReadLine(), out roll))
                        break;
                    else
                        Console.WriteLine("Invalid Roll Number! Try again.");
                }

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Course: ");
                string course = Console.ReadLine();

                int marks;
                while (true)
                {
                    Console.Write("Enter Marks: ");
                    if (int.TryParse(Console.ReadLine(), out marks))
                        break;
                    else
                        Console.WriteLine("Invalid Marks! Try again.");
                }

                students[i] = new Student(roll, name, course, marks);
            }

          
            Console.WriteLine("\n--- Student Records ---");
            foreach (var s in students)
            {
                Console.WriteLine($"Roll No: {s.RollNo} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
            }

            // Search functionality
            Console.Write("\nEnter Roll Number to search: ");
            int searchRoll = int.Parse(Console.ReadLine());

            bool found = false;

            foreach (var s in students)
            {
                if (s.RollNo == searchRoll)
                {
                    Console.WriteLine("\nStudent Found:");
                    Console.WriteLine($"Roll No: {s.RollNo} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Student record not found!");
            }
        }
    }
}
