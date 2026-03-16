using System;
namespace HR_Project
{
    public class Employee
    {
        // Private Fields (Data Hiding)
        private string fullName;
        private int age;
        private decimal salary;
        private string employeeId;

        // FullName Property
        public string FullName
        {
            get { return fullName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                fullName = value.Trim();
            }
        }

        // Age Property
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 18 || value > 80)
                {
                    throw new ArgumentException("Age must be between 18 and 80");
                }
                age = value;
            }
        }

        // Salary Property (Private set)
        public decimal Salary
        {
            get { return salary; }
            private set
            {
                if (value < 1000)
                {
                    throw new ArgumentException("Salary must be at least 1000");
                }
                salary = value;
            }
        }

        // EmployeeId Property Read Only
        public string EmployeeId
        {
            get { return employeeId; }
        }

        // Constructor
        public Employee(string name, decimal startSalary, int empAge)
        {
            employeeId = "E" + new Random().Next(1000, 9999);

            FullName = name;
            Age = empAge;
            Salary = startSalary;
        }

        // Method to increase salary
        public void GiveRaise(decimal percentage)
        {
            if (percentage <= 0 || percentage > 30)
            {
                throw new ArgumentException("Raise must be between 1 and 30%");
            }

            decimal increase = salary * percentage / 100;
            Salary = salary + increase;

            Console.WriteLine("Salary increased. New Salary: " + Salary);
        }

        // Method to deduct penalty
        public bool DeductPenalty(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid amount");
                return false;
            }

            if (salary - amount < 1000)
            {
                Console.WriteLine("Cannot deduct. Salary cannot go below 1000.");
                return false;
            }

            Salary = salary - amount;
            Console.WriteLine("Penalty deducted. New Salary: " + Salary);
            return true;
        }
    }
   

    class Program
    {
        static void Main()
        {
            Employee emp = new Employee("Poguru Nirupa", 4000, 22);

            Console.WriteLine("Employee ID: " + emp.EmployeeId);
            Console.WriteLine("Name: " + emp.FullName);
            Console.WriteLine("Age: " + emp.Age);
            Console.WriteLine("Salary: " + emp.Salary);

            emp.GiveRaise(10);

            emp.DeductPenalty(500);

            emp.FullName = "P Nirupa";

            Console.WriteLine("Updated Name: " + emp.FullName);
        }
    }

}
