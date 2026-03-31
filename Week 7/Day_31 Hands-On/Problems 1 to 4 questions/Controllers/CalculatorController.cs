using Microsoft.AspNetCore.Mvc;

namespace Problem_1.Controllers
{
    [Route("calc")]
    public class CalculatorController : Controller
    {
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("add")]
        public IActionResult Add(int num1, int num2)
        {
            int result = num1 + num2;
            ViewData["Result"] = result;

            return View("Index");
        }
    }
}
