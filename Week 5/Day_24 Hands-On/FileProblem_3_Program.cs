using System;
namespace FileProblem_3
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Sales Amount: ");
            double sales = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Rating (1-5): ");
            int rating = Convert.ToInt32(Console.ReadLine());

            var result = GetPerformance(sales, rating);

            string performance = result switch
            {
                ( >= 100000, >= 4) => "High Performer",
                ( >= 50000, >= 3) => "Average Performer",
                _ => "Needs Improvement"
            };

            Console.WriteLine("\n--- Employee Details ---");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Sales: {result.Item1}");
            Console.WriteLine($"Rating: {result.Item2}");
            Console.WriteLine($"Performance: {performance}");
        }

        static (double, int) GetPerformance(double sales, int rating)
        {
            return (sales, rating);
        }
    }
}
