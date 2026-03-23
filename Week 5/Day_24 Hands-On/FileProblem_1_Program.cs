using System;
using System.IO;
using System.Text;

namespace FilesProblem_1
{

    class Program
    {
        static void Main()
        {
            string filePath = "log.txt";

            try
            {
                Console.Write("Enter your message: ");
                string message = Console.ReadLine();

                // Append mode
                using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
                {
                    byte[] data = Encoding.UTF8.GetBytes(message + Environment.NewLine);
                    fs.Write(data, 0, data.Length);
                }

                Console.WriteLine("Message written successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
