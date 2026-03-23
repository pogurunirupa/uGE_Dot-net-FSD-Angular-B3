using System;
using System.IO;
namespace FilesProblem_4
{ 
    class Program
    {
        static void Main()
        {
            Console.Write("Enter root directory path: ");
            string path = Console.ReadLine();

            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);

                if (!dir.Exists)
                {
                    Console.WriteLine("Directory not found!");
                    return;
                }

                DirectoryInfo[] subDirs = dir.GetDirectories();

                foreach (DirectoryInfo subDir in subDirs)
                {
                    FileInfo[] files = subDir.GetFiles();

                    Console.WriteLine($"Folder: {subDir.Name}");
                    Console.WriteLine($"File Count: {files.Length}");
                    Console.WriteLine("----------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
