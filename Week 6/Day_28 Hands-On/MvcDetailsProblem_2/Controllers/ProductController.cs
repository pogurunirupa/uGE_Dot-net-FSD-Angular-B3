using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using MvcAppDetails.Models;

namespace MvcAppDetails.Controllers
{

    public class ProductController : Controller
    {
        // Static product list (dummy data)
        private static List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name = "Laptop", Price = 50000, Category = "Electronics" },
            new Product { Id = 2, Name = "Mobile", Price = 20000, Category = "Electronics" },
            new Product { Id = 3, Name = "Shoes", Price = 3000, Category = "Fashion" }
        };

        // INDEX - Display all products
        public IActionResult Index()
        {
            return View(products);
        }

        // DETAILS - Display single product
        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}




