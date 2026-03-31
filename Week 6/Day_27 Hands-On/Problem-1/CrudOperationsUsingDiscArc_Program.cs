using System;
using System.Data;
using Microsoft.Data.SqlClient;
namespace CrudOperationsUsingDiscArc
{

    class Program
    {
        static string conStr = "Data Source=LAPTOP-VKJ2NSAQ\\SQLEXPRESS;Initial Catalog=CRUDdb;Integrated Security=True;TrustServerCertificate=True";

        static void Main()
        {
            SqlConnection con = new SqlConnection(conStr);

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Products", con);

            SqlCommandBuilder builder = new SqlCommandBuilder(da);

            DataSet ds = new DataSet();

            // Fill DataSet
            da.Fill(ds, "Products");

            while (true)
            {
                Console.WriteLine("\n1. Insert\n2. Update\n3. Delete\n4. Display\n5. Get By Id\n6. Exit");
                Console.Write("Enter choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Insert(ds);
                        break;

                    case 2:
                        Update(ds);
                        break;

                    case 3:
                        Delete(ds);
                        break;

                    case 4:
                        Display(ds);
                        break;

                    case 5:
                        GetById(ds);  
                        break;

                    case 6:
                        da.Update(ds, "Products"); // Save all changes to DB
                        return;
                }
            }
        }

        static void Insert(DataSet ds)
        {
            DataRow row = ds.Tables["Products"].NewRow();

            Console.Write("Enter Product Id: ");
            row["ProductId"] = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Product Name: ");
            row["ProductName"] = Console.ReadLine();

            Console.Write("Enter Price: ");
            row["Price"] = Convert.ToDouble(Console.ReadLine());

            ds.Tables["Products"].Rows.Add(row);

            Console.WriteLine("Inserted in DataSet (not yet DB)");
        }

        static void Update(DataSet ds)
        {
            Console.Write("Enter Product Id to update: ");
            int id = Convert.ToInt32(Console.ReadLine());

            foreach (DataRow row in ds.Tables["Products"].Rows)
            {
                if ((int)row["ProductId"] == id)
                {
                    Console.Write("Enter New Name: ");
                    row["ProductName"] = Console.ReadLine();

                    Console.Write("Enter New Price: ");
                    row["Price"] = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Updated in DataSet");
                    return;
                }
            }

            Console.WriteLine("Product not found");
        }

        static void Delete(DataSet ds)
        {
            Console.Write("Enter Product Id to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            foreach (DataRow row in ds.Tables["Products"].Rows)
            {
                if ((int)row["ProductId"] == id)
                {
                    row.Delete();
                    Console.WriteLine("Deleted from DataSet");
                    return;
                }
            }

            Console.WriteLine("Product not found");
        }

        static void GetById(DataSet ds)
        {
            Console.Write("Enter Product Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            foreach (DataRow row in ds.Tables["Products"].Rows)
            {
                if (row.RowState != DataRowState.Deleted && (int)row["ProductId"] == id)
                {
                    Console.WriteLine("\nProduct Found:");
                    Console.WriteLine($"Id: {row["ProductId"]}");
                    Console.WriteLine($"Name: {row["ProductName"]}");
                    Console.WriteLine($"Price: {row["Price"]}");
                    return;
                }
            }

            Console.WriteLine("Product not found");
        }

        static void Display(DataSet ds)
        {
            foreach (DataRow row in ds.Tables["Products"].Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    Console.WriteLine($"{row["ProductId"]} - {row["ProductName"]} - {row["Price"]}");
                }
            }
        }
    }
}
