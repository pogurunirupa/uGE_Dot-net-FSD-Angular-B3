using System;
using ADO.NET_Problem.Data_Access_Class;
using ADO.NET_Problem.Model;
namespace ADO.NET_Problem
{
    class Program
    {
        static void Main()
        {
            ProductData dal = new ProductData();

            Console.WriteLine("1.Insert  2.View  3.Update  4.Delete  5.GetById");
            int choice = Convert.ToInt32(Console.ReadLine());

            try
            {
                if (choice == 1)
                {
                    Product p = new Product();

                    Console.Write("Name: ");
                    p.ProductName = Console.ReadLine();

                    Console.Write("Category: ");
                    p.Category = Console.ReadLine();

                    Console.Write("Price: ");
                    p.Price = Convert.ToDecimal(Console.ReadLine());

                    dal.InsertProduct(p);
                    Console.WriteLine("Inserted Successfully");
                }
                else if (choice == 2)
                {
                    var list = dal.GetAllProducts();

                    foreach (var item in list)
                    {
                        Console.WriteLine($"{item.ProductId} {item.ProductName} {item.Category} {item.Price}");
                    }
                }
                else if (choice == 3)
                {
                    Product p = new Product();

                    Console.Write("Id: ");
                    p.ProductId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Name: ");
                    p.ProductName = Console.ReadLine();

                    Console.Write("Category: ");
                    p.Category = Console.ReadLine();

                    Console.Write("Price: ");
                    p.Price = Convert.ToDecimal(Console.ReadLine());

                    dal.UpdateProduct(p);
                    Console.WriteLine("Updated Successfully");
                }
                else if (choice == 4)
                {
                    Console.Write("Id: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    dal.DeleteProduct(id);
                    Console.WriteLine("Deleted Successfully");
                }
                else if (choice == 5)
                {
                    Console.Write("Enter Product Id: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    var product = dal.GetProductById(id);

                    if (product != null)
                    {
                        Console.WriteLine($"{product.ProductId} {product.ProductName} {product.Category} {product.Price}");
                    }
                    else
                    {
                        Console.WriteLine("Product not found");
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
