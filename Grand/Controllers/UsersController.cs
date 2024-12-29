using AutoMapper;
using Grand.Views.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer.Models;
using ServiceLayer.Classes;

namespace Grand.Controllers
{
    public class UsersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserService _UserService;
        public UsersController(IMapper mapper, UserService userService)
        {
            _UserService = userService;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp([Bind(include: "Name, LastName, PhoneNumber, Password, ConfirmPassword")] SignUpViewModel model)
        {
            if(ModelState.IsValid)
            {
                var newUser = _mapper.Map<User>(model);
                newUser.Password = _UserService.HashPassword(newUser);
                _UserService.Add(newUser);
                TempData["UserId"] = newUser.Id;
                _UserService.Save();
                return RedirectToAction("Index", "Home", new { area = "User" });
            }

            return View(model);
        }
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn([Bind(include:"PhoneNumber, Password, RememberMe")]SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _UserService.Authenticate(model.PhoneNumber, model.Password);
                if (user == null)
                    ModelState.AddModelError("PhoneNumber", "نام کاربری یا رمز اشتباه است.");
                else
                {
                    if (!user.IsActive)
                        TempData["Suspended"] = "حساب کاربری شما مسدود شده است";
                    else
                    {
                        TempData["UserId"] = user.Id;
                        return RedirectToAction("Index", "Home", new { area = user.IsAdmin ? "Admin" : "User", id = (int)TempData["UserId"] });
                    }
                }
            }
            return View(model);
        }  
        
        public void Dispose()
        {
            _UserService.Dispose();
        }
    }
}
