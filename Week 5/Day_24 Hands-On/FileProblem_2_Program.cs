using System;
using System.IO;
namespace FilesProblem_2
{
 
    class Program
    {
        static void Main()
        {
            Console.Write("Enter folder path: ");
            string path = Console.ReadLine();

            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);

                if (!dir.Exists)
                {
                    Console.WriteLine("Directory not found!");
                    return;
                }

                FileInfo[] files = dir.GetFiles();
                int count = 0;

                foreach (FileInfo file in files)
                {
                    Console.WriteLine($"Name: {file.Name}");
                    Console.WriteLine($"Size: {file.Length} bytes");
                    Console.WriteLine($"Created: {file.CreationTime}");
                    Console.WriteLine("----------------------");
                    count++;
                }

                Console.WriteLine($"Total Files: {count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
