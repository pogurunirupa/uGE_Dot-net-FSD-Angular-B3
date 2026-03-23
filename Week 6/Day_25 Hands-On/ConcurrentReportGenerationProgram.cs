using System;
using System.Threading;
using System.Threading.Tasks;
namespace Level_1_problem_3
{
    class Program
    {
        static async Task GenerateSalesReport()
        {
            Console.WriteLine("Sales Report Started");
            await Task.Delay(3000);
            Console.WriteLine("Sales Report Completed");
        }

        static async Task GenerateInventoryReport()
        {
            Console.WriteLine("Inventory Report Started");
            await Task.Delay(2000);
            Console.WriteLine("Inventory Report Completed");
        }

        static async Task GenerateCustomerReport()
        {
            Console.WriteLine("Customer Report Started");
            await Task.Delay(2500);
            Console.WriteLine("Customer Report Completed");
        }

        static async Task Main()
        {
            Task t1 = GenerateSalesReport();
            Task t2 = GenerateInventoryReport();
            Task t3 = GenerateCustomerReport();

            await Task.WhenAll(t1, t2, t3);

            Console.WriteLine("\nAll Reports Generated!");
        }
    }
}
