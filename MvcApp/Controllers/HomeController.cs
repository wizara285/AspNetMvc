using Microsoft.AspNetCore.Mvc;

namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string Index(string username, string password)
        {
            return $"User Name: {username} \nUser Password: {password}";
        }

        public IActionResult About()
        {
            return View();
        }

    }
}
