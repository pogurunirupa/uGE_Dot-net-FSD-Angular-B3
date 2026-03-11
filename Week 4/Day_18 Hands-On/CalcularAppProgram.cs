namespace CalculatorApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            char op;

            Console.Write("Enter First Number: ");
            a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Second Number: ");
            b = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Operator (+,-,*,/): ");
            op = Convert.ToChar(Console.ReadLine());

            switch (op)
            {
                case '+':
                    Console.WriteLine("Result: " + (a + b));
                    break;

                case '-':
                    Console.WriteLine("Result: " + (a - b));
                    break;

                case '*':
                    Console.WriteLine("Result: " + (a * b));
                    break;

                case '/':
                    Console.WriteLine("Result: " + (a / b));
                    break;

                default:
                    Console.WriteLine("Invalid Operator");
                    break;
            }

           

        }
    }
}
