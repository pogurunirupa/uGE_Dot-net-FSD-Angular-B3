using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductApp.Controllers
{
    public class ProductController : Controller
    {
        // Temporary data (instead of DB)
        static List<Product> products = new List<Product>();

        // READ (Display all products)
        public IActionResult Index()
        {
            return View(products);
        }

        // CREATE - GET
        public IActionResult Create()
        {
            return View();
        }

        // CREATE - POST
        [HttpPost]
        public IActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                products.Add(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }

        // EDIT - GET
        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(x => x.ProductId == id);
            return View(product);
        }

        // EDIT - POST
        [HttpPost]
        public IActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                var product = products.FirstOrDefault(x => x.ProductId == p.ProductId);

                product.ProductName = p.ProductName;
                product.Price = p.Price;
                product.Category = p.Category;

                return RedirectToAction("Index");
            }
            return View(p);
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(x => x.ProductId == id);
            products.Remove(product);
            return RedirectToAction("Index");
        }

        // DETAILS
        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(x => x.ProductId == id);
            return View(product);
        }
    }
}