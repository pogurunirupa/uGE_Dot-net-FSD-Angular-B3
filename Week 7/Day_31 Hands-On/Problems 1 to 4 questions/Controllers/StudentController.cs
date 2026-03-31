using Microsoft.AspNetCore.Mvc;

namespace Problem_1.Controllers
{
    [Route("student")]
    public class StudentController : Controller
    {
       
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

       
        [HttpPost("register")]
        public IActionResult Register(string name, int age, string course)
        {
            ViewBag.Name = name;
            ViewBag.Age = age;
            ViewBag.Course = course;

            return RedirectToAction("Display", new { name, age, course });
        }

       
        [HttpGet("display")]
        public IActionResult Display(string name, int age, string course)
        {
            ViewBag.Name = name;
            ViewBag.Age = age;
            ViewBag.Course = course;

            return View();
        }
    }
}
