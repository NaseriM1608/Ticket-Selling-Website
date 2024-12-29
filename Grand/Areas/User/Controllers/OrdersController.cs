using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.Context;
using ModelsLayer.Models;
using ServiceLayer.Classes;
using ServiceLayer.Interfaces;

namespace Grand.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/Orders")]
    public class OrdersController : Controller
    {
        private readonly OrderDetailsService _OrderDetailsService;
        private readonly OrderService _OrderService;
        private readonly TicketService _TicketService;

        public OrdersController(OrderService orderService, TicketService ticketService, OrderDetailsService orderDetailsService, ApplicationDbContext context)
        {
            _OrderService = orderService;
            _TicketService = ticketService;
            _OrderDetailsService = orderDetailsService;
        }

        // GET: User/Orders
        public ActionResult Index()
        {
            //var userOrders = _OrderService.
            return View(_OrderService.GetAll());
        }

        // GET: User/Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order =  _OrderService.GetAll()
                .FirstOrDefault(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpGet("PurchaseTicket")]
        public IActionResult PurchaseTicket()
        {
            Console.WriteLine("PurchaseTicket action called");
            return View();
        }

        [HttpPost("PurchaseTicket")]
        [ValidateAntiForgeryToken]
        public IActionResult PurchaseTicket(int EventId, int UserId, string TicketType, int SeatNumber)
        {
            var ticket = _TicketService.GetTicketByEventAndType(EventId, TicketType);

            if (ticket == null || ticket.Quantity <= 0)
            {
                return RedirectToAction("Error", "Home", new { message = "Ticket not available." });
            }
            int userId = (int)TempData["UserId"];
            var existingOrder = _OrderService.GetOrderByUserId(userId);

            if (existingOrder == null)
            {
                existingOrder = new Order
                {
                    UserId = userId
                };
                _OrderService.Add(existingOrder);
            }
            var orderDetails = new OrderDetails
            {
                OrderId = existingOrder.Id,
                TicketId = ticket.Id,
                Price = ticket.Price,
                SeatNumber = SeatNumber
            };
            _OrderDetailsService.Add(orderDetails);
            ticket.Quantity--;
            _TicketService.Update(ticket);

            return RedirectToAction("Success", "Home", new { message = "Ticket purchased successfully!" });
        }

    }
}
