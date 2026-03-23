using System;
using System.IO;
namespace FileProblem_5
{

    class Program
    {
        static void Main()
        {
            try
            {
                DriveInfo[] drives = DriveInfo.GetDrives();

                foreach (DriveInfo drive in drives)
                {
                    if (drive.IsReady)
                    {
                        Console.WriteLine($"Drive: {drive.Name}");
                        Console.WriteLine($"Type: {drive.DriveType}");
                        Console.WriteLine($"Total Size: {drive.TotalSize / (1024 * 1024 * 1024)} GB");
                        Console.WriteLine($"Free Space: {drive.AvailableFreeSpace / (1024 * 1024 * 1024)} GB");

                        double freePercent = (double)drive.AvailableFreeSpace / drive.TotalSize * 100;

                        if (freePercent < 15)
                        {
                            Console.WriteLine("WARNING: Low Disk Space!");
                        }

                        Console.WriteLine("----------------------");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
