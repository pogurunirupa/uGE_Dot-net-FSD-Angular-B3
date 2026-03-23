using System;
using System.Diagnostics;
using System.IO;
namespace Level_2_Problem_2
{
    class Program
    {
        static void Main()
        {
            // Create log file
            Trace.Listeners.Add(new TextWriterTraceListener("traceLog.txt"));
            Trace.AutoFlush = true;

            Console.WriteLine("Order Processing Started...\n");

            Trace.WriteLine("Step 1: Validate Order");
            ValidateOrder();

            Trace.TraceInformation("Step 2: Process Payment");
            ProcessPayment();

            Trace.WriteLine("Step 3: Update Inventory");
            UpdateInventory();

            Trace.TraceInformation("Step 4: Generate Invoice");
            GenerateInvoice();

            Console.WriteLine("Order Processing Completed!");
        }

        static void ValidateOrder()
        {
            Trace.WriteLine("Order Validated");
        }

        static void ProcessPayment()
        {
            Trace.WriteLine("Payment Successful");
        }

        static void UpdateInventory()
        {
            Trace.WriteLine("Inventory Updated");
        }

        static void GenerateInvoice()
        {
            Trace.WriteLine("Invoice Generated");
        }
    }
}
