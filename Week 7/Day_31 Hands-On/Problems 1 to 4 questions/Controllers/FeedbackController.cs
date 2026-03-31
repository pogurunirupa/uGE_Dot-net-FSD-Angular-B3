using Microsoft.AspNetCore.Mvc;

namespace Problem_1.Controllers
{
    [Route("feedback")]
    public class FeedbackController : Controller
    {
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("submit")]
        public IActionResult Submit(string name, string comments, int rating)
        {
            if (rating >= 4)
                ViewData["Message"] = "Thank You!";
            else
                ViewData["Message"] = "We will improve!";

            return View("Index");
        }
    }
}
