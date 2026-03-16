using System;
namespace Problem_2
{
    class Employee
    {
        public string Name { get; set; }
        public double BaseSalary { get; set; }

        public virtual double CalculateSalary()
        {
            return BaseSalary;
        }
    }

    class Manager : Employee
    {
        public override double CalculateSalary()
        {
            return BaseSalary + (BaseSalary * 0.20);
        }
    }

    class Developer : Employee
    {
        public override double CalculateSalary()
        {
            return BaseSalary + (BaseSalary * 0.10);
        }
    }

    class Program
    {
        static void Main()
        {
            double salary;

            Console.Write("Enter Base Salary: ");
            salary = Convert.ToDouble(Console.ReadLine());

            Employee emp;

            emp = new Manager();
            emp.BaseSalary = salary;
            Console.WriteLine("Manager Salary = " + emp.CalculateSalary());

            emp = new Developer();
            emp.BaseSalary = salary;
            Console.WriteLine("Developer Salary = " + emp.CalculateSalary());
            Console.ReadKey();
        }
    }
}
