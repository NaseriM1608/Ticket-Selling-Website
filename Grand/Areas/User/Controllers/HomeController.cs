using Microsoft.AspNetCore.Mvc;

namespace Grand.Areas.User.Controllers
{
    [Area(nameof(ModelsLayer.Models.User))]
    [Route($"{nameof(ModelsLayer.Models.User)}/Home/")]
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
