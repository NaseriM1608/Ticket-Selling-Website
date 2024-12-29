using Microsoft.EntityFrameworkCore;
using ModelsLayer.Context;
using ModelsLayer.Models;
using RepositoryLayer.Classes;
using RepositoryLayer.Interfaces;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Classes
{
    public class TicketService : EntityService<Ticket>, ITicketService
    {
        private readonly TicketRepository _TicketRepository;
        public TicketService(ApplicationDbContext context, TicketRepository ticketRepository) : base(context)
        {
            _TicketRepository = ticketRepository;
        }
        public Ticket GetTicketByEventAndType(int eventId, string ticketType)
        {
            return _TicketRepository.GetAll()
                .FirstOrDefault(t => t.EventId == eventId && t.Type.Equals(ticketType, StringComparison.OrdinalIgnoreCase));
        }
    }
}
