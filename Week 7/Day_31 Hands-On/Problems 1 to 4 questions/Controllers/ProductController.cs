using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Problem_1.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        static List<dynamic> products = new List<dynamic>();

        [HttpGet("index")]
        public IActionResult Index()
        {
            ViewBag.Products = products;
            return View();
        }

        [HttpPost("add")]
        public IActionResult Add(string name, int price, int qty)
        {
            products.Add(new { Name = name, Price = price, Qty = qty });

            ViewBag.Products = products;
            return View("Index");
        }
    }
}
