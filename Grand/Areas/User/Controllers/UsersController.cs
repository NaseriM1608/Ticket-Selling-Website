using AutoMapper;
using Grand.Views.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Classes;
using ModelsLayer.Models;

namespace Grand.Areas.User.Controllers
{
    
    public class UsersController : Controller
    {
        private readonly IMapper _Mapper;
        private readonly UserService _UserService;
        public UsersController(UserService userService, IMapper mapper)
        {
            _UserService = userService;
            _Mapper = mapper;
        }
        public IActionResult Details(int id)
        {
            return View(_Mapper.Map<ModelsLayer.Models.User, UserViewModel>(_UserService.GetEntity(id)));
        }
    }
}
