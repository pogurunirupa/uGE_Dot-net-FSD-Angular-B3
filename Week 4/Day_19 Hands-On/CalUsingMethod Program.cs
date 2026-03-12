using System;
namespace CalUsingMethod
{
    class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }
    }

    class Program
    {
        static void Main()
        {
            int num1, num2;

            Console.Write("Enter first number: ");
            num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number: ");
            num2 = Convert.ToInt32(Console.ReadLine());

            Calculator c = new Calculator();

            int addResult = c.Add(num1, num2);
            int subResult = c.Subtract(num1, num2);

            Console.WriteLine("Addition = " + addResult);
            Console.WriteLine("Subtraction = " + subResult);
        }
    }
}
