using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer.Context;
using ServiceLayer.Classes;

namespace Grand.Areas.User.Controllers
{
    [Area("User")]
    public class TicketsController : Controller
    {
        private readonly TicketService _TicketService;

        // Inject TicketService into the constructor
        public TicketsController(TicketService ticketService)
        {
            _TicketService = ticketService;
        }
        public ActionResult Index()
        {
            return View(_TicketService.GetAll());
        }

        public ActionResult Details(int id)
        {
            return View(_TicketService.GetEntity(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(_TicketService.Update(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            return View(_TicketService.Delete(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
