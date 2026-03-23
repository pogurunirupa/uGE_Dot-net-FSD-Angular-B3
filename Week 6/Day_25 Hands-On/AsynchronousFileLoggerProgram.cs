using System;
using System.Threading.Tasks;
namespace Level_1_problem_1
{
    class Program
    {
        static async Task WriteLogAsync(string message)
        {
            Console.WriteLine($"Start Writing: {message}");
            await Task.Delay(2000);
            Console.WriteLine($"Completed Writing: {message}");
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("Logging started...\n");

            Task t1 = WriteLogAsync("User Logged In");
            Task t2 = WriteLogAsync("File Uploaded");
            Task t3 = WriteLogAsync("Error Occurred");

            await Task.WhenAll(t1, t2, t3);

            Console.WriteLine("\nAll logs written successfully!");
        }
    }

}
