using System;
using System.Collections.Generic;
using System.Linq;
namespace LinqProblems
{
    class Product
    {
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public double Mrp { get; set; }
    }

    class Program
    {
        static void Main()
        {
            List<Product> products = new List<Product>()
            {
                new Product{ ProductCode=101, ProductName="Soap", Category="FMCG", Mrp=25 },
                new Product{ ProductCode=102, ProductName="Rice", Category="Grain", Mrp=50 },
                new Product{ ProductCode=103, ProductName="Oil", Category="FMCG", Mrp=120 },
                new Product{ ProductCode=104, ProductName="Wheat", Category="Grain", Mrp=40 },
                new Product{ ProductCode=105, ProductName="Shampoo", Category="FMCG", Mrp=30 }
            };

            // 1) FMCG (Query Syntax)
            var fmcg = from p in products
                       where p.Category == "FMCG"
                       select p;

            // 2) Grain (Query Syntax)
            var grainProducts = from p in products
                                where p.Category == "Grain"
                                select p;

            // 3) Sort by ProductCode (Query Syntax)
            var sortCode = from p in products
                           orderby p.ProductCode
                           select p;

            // 4) Sort by Category (Query Syntax)
            var sortCategory = from p in products
                               orderby p.Category
                               select p;

            // 5) Sort by MRP Asc (Query Syntax)
            var sortMrpAsc = from p in products
                             orderby p.Mrp
                             select p;

            // 6) Sort by MRP Desc (Query Syntax)
            var sortMrpDesc = from p in products
                              orderby p.Mrp descending
                              select p;

            // 7) Group by Category (Query Syntax)
            var groupCategory = from p in products
                                group p by p.Category;


            // Remaining (Method Syntax)

            // 8) Group by MRP
            var groupMrp = products.GroupBy(p => p.Mrp);

            // 9) Max FMCG product
            var maxFmcg = products
                .Where(p => p.Category == "FMCG")
                .OrderByDescending(p => p.Mrp)
                .FirstOrDefault();

            // 10) Count total
            int totalCount = products.Count();

            // 11) Count FMCG
            int fmcgCount = products.Count(p => p.Category == "FMCG");

            // 12) Max price
            double maxPrice = products.Max(p => p.Mrp);

            // 13) Min price
            double minPrice = products.Min(p => p.Mrp);

            // 14) All below 30
            bool allBelow30 = products.All(p => p.Mrp < 30);

            // 15) Any below 30
            bool anyBelow30 = products.Any(p => p.Mrp < 30);


            Console.WriteLine("FMCG Products:");
            foreach (var p in fmcg)
                Console.WriteLine(p.ProductName);

            Console.WriteLine("\nGrain Products:");
            foreach (var p in grainProducts)
                Console.WriteLine(p.ProductName);

            Console.WriteLine("\nSorted by Code:");
            foreach (var p in sortCode)
                Console.WriteLine(p.ProductName);

            Console.WriteLine("\nSorted by Category:");
            foreach (var p in sortCategory)
                Console.WriteLine(p.ProductName);

            Console.WriteLine("\nSorted by MRP Asc:");
            foreach (var p in sortMrpAsc)
                Console.WriteLine(p.ProductName);

            Console.WriteLine("\nSorted by MRP Desc:");
            foreach (var p in sortMrpDesc)
                Console.WriteLine(p.ProductName);

            Console.WriteLine("\nGroup by Category:");
            foreach (var g in groupCategory)
            {
                Console.WriteLine("Category: " + g.Key);
                foreach (var p in g)
                    Console.WriteLine(p.ProductName);
            }

            Console.WriteLine("\nGroup by MRP:");
            foreach (var g in groupMrp)
            {
                Console.WriteLine("MRP: " + g.Key);
                foreach (var p in g)
                    Console.WriteLine(p.ProductName);
            }

            Console.WriteLine("\nMax FMCG Product:");
            if (maxFmcg != null)
                Console.WriteLine(maxFmcg.ProductName + " " + maxFmcg.Mrp);

            Console.WriteLine("\nTotal Products: " + totalCount);
            Console.WriteLine("\nFMCG Count: " + fmcgCount);
            Console.WriteLine("\nMax Price: " + maxPrice);
            Console.WriteLine("\nMin Price: " + minPrice);
            Console.WriteLine("\nAll below 30: " + allBelow30);
            Console.WriteLine("\nAny below 30: " + anyBelow30);


        }
    }
}
