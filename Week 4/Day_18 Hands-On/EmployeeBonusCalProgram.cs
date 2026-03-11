using System;

namespace EmployeeBonusCal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            double salary;
            int experience;
            double bonus = 0;

            Console.Write("Enter Employee Name: ");
            name = Console.ReadLine();

            Console.Write("Enter Salary: ");
            salary = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Experience: ");
            experience = Convert.ToInt32(Console.ReadLine());

            if (salary < 0 || experience < 0)
            {
                Console.WriteLine("Invalid Input");
            }
            else
            {
                if (experience == 0)
                {
                    bonus = 0;
                }
                else if (experience < 2)
                {
                    bonus = salary * 0.05;
                }
                else if (experience <= 5)
                {
                    bonus = salary * 0.10;
                }
                else
                {
                    bonus = salary * 0.15;
                }

                Console.WriteLine("Employee: " + name);
                Console.WriteLine("Bonus: " + bonus);
                Console.WriteLine("Final Salary: " + (salary + bonus));
            }
        }
    }
}
