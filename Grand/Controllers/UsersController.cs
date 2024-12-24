using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer.Models;
using ServiceLayer.Classes;

namespace Grand.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserService _UserService;
        public UsersController(UserService userService)
        {
            _UserService = userService;
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp([Bind(include: "Name, LastName, PhoneNumber, Password, ConfirmPassword")] User newUser)
        {
            if(ModelState.IsValid)
            {
                _UserService.Add(newUser);
                _UserService.Save();
                return RedirectToAction("Index", "Home", new { area = "User" });
            }

            return View(newUser);
        }
        public ActionResult Index()
        {
            return View(_UserService.GetAll());
        }

        public ActionResult Details(int id)
        {
            return View(_UserService.GetEntity(id));
        }
        public ActionResult Create()
        {
            return View();
        }

        
        public ActionResult Edit(int id)
        {
            return View();
        }

        
        public ActionResult Delete(int id)
        {
            return View();
        }
        
    }
}
