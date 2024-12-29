using Microsoft.AspNetCore.Mvc;

namespace Grand.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
