using Microsoft.AspNetCore.Mvc;
using ModelsLayer.Models;
using ServiceLayer.Classes;
using ServiceLayer.Interfaces;

namespace Grand.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/Events/[action]/{id?}")]
    public class EventsController : Controller
    {
        private readonly EventService _EventService;
        private readonly TicketService _TicketService;
        private readonly OrderService _OrderService;
        private readonly OrderDetailsService _OrderDetailsService;
        public EventsController(EventService eventService, TicketService ticketService, OrderService orderService, OrderDetailsService orderDetailsService)
        {
            _EventService = eventService;
            _TicketService = ticketService;
            _OrderService = orderService;
            _OrderDetailsService = orderDetailsService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            return View(_EventService.GetEntity(id));
        }
        public IActionResult PurchaseTicket(int id)
        {
            return View(_EventService.GetEntity(id));
        }
        [HttpPost]
        public IActionResult PurchaseTicket(int id, string ticketType, int seatNumber)
        {
            var eventDetails = _EventService.GetEntity(id);
            if (eventDetails == null)
            {
                return NotFound("Event not found.");
            }
            var ticket = _TicketService.GetTicketByEventAndType(id, ticketType);
            if (ticket == null || ticket.Quantity <= 0)
            {
                return RedirectToAction("Details", new { id, message = "Selected ticket type is unavailable." });
            }
            int userId = (int)TempData["UserId"];
            var order = _OrderService.GetAll().FirstOrDefault(o => o.UserId == userId);
            if (order == null)
            {
                order = new Order
                {
                    UserId = userId,
                };
                _OrderService.Add(order);
            }
            _OrderService.Save();
            var orderDetails = new OrderDetails
            {
                OrderId = order.Id,
                TicketId = ticket.Id,
                Price = ticket.Price,
                SeatNumber = seatNumber
            };
            _OrderDetailsService.Add(orderDetails);
            ticket.Quantity--;
            _TicketService.Update(ticket);
            _EventService.Save();
            return RedirectToAction("Details", new { id, message = "Ticket purchased successfully!" });
        }

    }
}
